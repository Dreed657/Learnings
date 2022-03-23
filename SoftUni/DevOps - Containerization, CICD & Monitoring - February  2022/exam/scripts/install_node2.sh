#!/bin/bash

sudo cat /vagrant/sshd_config > /etc/ssh/sshd_config
sudo systemctl restart sshd.service

# Install node extractor 
wget https://github.com/prometheus/node_exporter/releases/download/v1.3.1/node_exporter-1.3.1.linux-amd64.tar.gz
tar xvfz node_exporter-1.3.1.linux-amd64.tar.gz
mv ./node_exporter-1.3.1.linux-amd64 ./node_exporter
chmod +x ./node_exporter/node_exporter
./node_exporter/node_exporter &

# Install docker
sudo apt-get update
sudo apt-get install -y ca-certificates curl gnupg lsb-release

curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg
echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu \
  $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

sudo apt-get update

sudo apt-get install -y docker-ce docker-ce-cli containerd.i docker-compose openjdk-11-jre
chown -R vagrant:vagrant /home/vagrant/.docker

sudo usermod -aG docker vagrant
sudo cp /vagrant/daemon.json /etc/docker/

systemctl status docker

# Create docker network
docker network create app-net

docker run \
  --volume=/:/rootfs:ro \
  --volume=/var/run:/var/run:ro \
  --volume=/sys:/sys:ro \
  --volume=/var/lib/docker/:/var/lib/docker:ro \
  --volume=/dev/disk/:/dev/disk:ro \
  --publish=9999:8080 \
  --detach=true \
  --name=cadvisor \
  --privileged \
  --device=/dev/kmsg \
  gcr.io/cadvisor/cadvisor:latest

docker-compose -f /vagrant/gitea-compose.yml up -d