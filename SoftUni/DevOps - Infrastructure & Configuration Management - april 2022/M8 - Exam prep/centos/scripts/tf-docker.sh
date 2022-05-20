#!/bin/bash

echo 'Add docker network'
docker network create appnet

echo "Install terraform ..."
yum install -y yum-utils
yum-config-manager --add-repo https://rpm.releases.hashicorp.com/RHEL/hashicorp.repo
yum -y install terraform

echo 'Change directory to tf'
cd /vagrant/tf

echo 'Terraform init'
terraform init

echo 'Terraform apply'
terraform apply -auto-approve