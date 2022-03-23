#!/bin/bash

# Install node extractor 
wget https://github.com/prometheus/node_exporter/releases/download/v1.3.1/node_exporter-1.3.1.linux-amd64.tar.gz
tar xvfz node_exporter-1.3.1.linux-amd64.tar.gz
mv ./node_exporter-1.3.1.linux-amd64 ./node_exporter
chmod +x ./node_exporter/node_exporter
./node_exporter/node_exporter &

# Install jenkins
curl -fsSL https://pkg.jenkins.io/debian-stable/jenkins.io.key | sudo tee \
  /usr/share/keyrings/jenkins-keyring.asc > /dev/null
echo deb [signed-by=/usr/share/keyrings/jenkins-keyring.asc] \
  https://pkg.jenkins.io/debian-stable binary/ | sudo tee \
  /etc/apt/sources.list.d/jenkins.list > /dev/null

sudo apt-get update
sudo apt-get install -y openjdk-11-jre jenkins

sudo systemctl enable jenkins
sudo systemctl start jenkins

usermod -s /bin/bash jenkins
echo -e 'pass1\npass1' | passwd jenkins
usermod -aG sudo jenkins

usermod -aG jenkins vagrant

systemctl restart jenkins
