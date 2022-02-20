#!/bin/bash

echo "* Login to Docker Hub ..."
cat /vagrant/support/docker-hub-cred.txt | docker login --username shekeriev --password-stdin

echo "* Clone the repository ..."
cd /vagrant/application && git clone https://github.com/shekeriev/bgapp

echo "* Buld the web (php+nginx) image ..."
docker build -t shekeriev/hw3-web -f /vagrant/application/Dockerfile.web /vagrant/application/.

echo "* Build the db image ..."
docker build -t shekeriev/hw3-db -f /vagrant/application/Dockerfile.db /vagrant/application/.

echo "* Push the web image ..."
docker image push shekeriev/hw3-web

echo "* Push the db image ..."
docker image push shekeriev/hw3-db

echo "* Start the stack ..."
docker -H 192.168.99.100 stack up -c /vagrant/docker-compose.yaml hw3

echo "* Show services in the stack ..."
docker -H 192.168.99.100 stack ps hw3