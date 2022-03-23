#!/bin/bash

# Install node extractor 
wget https://github.com/prometheus/node_exporter/releases/download/v1.3.1/node_exporter-1.3.1.linux-amd64.tar.gz
tar xvfz node_exporter-1.3.1.linux-amd64.tar.gz
mv ./node_exporter-1.3.1.linux-amd64 ./node_exporter
chmod +x ./node_exporter/node_exporter
./node_exporter/node_exporter &

# Prometheus
sudo groupadd --system prometheus
sudo useradd -s /sbin/nologin --system -g prometheus prometheus
sudo usermod -aG prometheus vagrant

mkdir /var/lib/prometheus
for i in rules rules.d files_sd; do sudo mkdir -p /etc/prometheus/${i}; done

sudo apt update
sudo apt -y install wget curl vim

mkdir -p /tmp/prometheus && cd /tmp/prometheus
curl -s https://api.github.com/repos/prometheus/prometheus/releases/latest | grep browser_download_url | grep linux-amd64 | cut -d '"' -f 4 | wget -qi -

tar xvf prometheus*.tar.gz
cd prometheus*/

mv prometheus promtool /usr/local/bin/

sudo cat /vagrant/prometheus.yml > /etc/prometheus/prometheus.yml
sudo cat /vagrant/prometheus.service > /etc/systemd/system/prometheus.service

for i in rules rules.d files_sd; do sudo chown -R prometheus:prometheus /etc/prometheus/${i}; done
for i in rules rules.d files_sd; do sudo chmod -R 775 /etc/prometheus/${i}; done
sudo chown -R prometheus:prometheus /var/lib/prometheus/

cd ~/

# Grafana
sudo apt-get install -y apt-transport-https
sudo apt-get install -y software-properties-common
wget -q -O - https://packages.grafana.com/gpg.key | apt-key add -

echo "deb https://packages.grafana.com/oss/deb stable main" | tee -a /etc/apt/sources.list.d/grafana.list

sudo apt-get update
sudo apt-get install -y grafana

sudo cat /vagrant/grafana/datasource.yaml > /etc/grafana/provisioning/datasources/sample.yaml
sudo cat /vagrant/grafana/dashboards.yaml > /etc/grafana/provisioning/dashboards/sample.yaml

# start
systemctl daemon-reload

systemctl start prometheus
systemctl enable prometheus

systemctl start grafana-server
systemctl enable grafana-server

sleep 5

# initial grafana user

curl -XPOST -H "Content-Type: application/json" -d '{
  "name":"exam",
  "email":"exam@localhost",
  "login":"exam",
  "password":"exam"
}' http://admin:admin@localhost:3000/api/admin/users
