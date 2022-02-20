#!/bin/bash

echo "* Update repositories information ..."
apt-get update -y

echo "* Install additional software ..."
apt-get install -y apt-transport-https ca-certificates curl gnupg-agent software-properties-common git

echo "* Install the Docker repository key ..."
curl -fsSL https://download.docker.com/linux/debian/gpg | apt-key add -

echo "* Add the Docker repository ..."
add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/debian $(lsb_release -cs) stable"

echo "* Install the Docker software ..."
apt-get update -y
apt-get install -y docker-ce docker-ce-cli containerd.io

echo "* Disable and stop the Docker daemon ..."
systemctl disable --now docker

echo "* Adjust Docker configuration ..."
cp /vagrant/support/daemon.json /etc/docker/daemon.json
mkdir -p /etc/systemd/system/docker.service.d/
cp /vagrant/support/docker.conf /etc/systemd/system/docker.service.d/docker.conf

echo "* Enable and start the Docker daemon ..."
systemctl enable --now docker

echo "* Add the vagrant user to the docker group ..."
usermod -aG docker vagrant
