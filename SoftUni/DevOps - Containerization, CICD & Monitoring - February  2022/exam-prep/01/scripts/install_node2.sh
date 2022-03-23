#!/bin/bash

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

sudo usermod -aG docker vagrant

systemctl status docker

# Create docker network
docker network create app-net

docker-compose -f /vagrant/gitea-compose.yml up -d