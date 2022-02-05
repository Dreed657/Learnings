#!/bin/bash

echo "* Add hosts ..."
echo "192.168.56.100 web.do1.lab web" >> /etc/hosts
echo "192.168.56.101 db.do1.lab db" >> /etc/hosts

echo "* Install Software ..."
sudo apt upgrade -y
sudo apt install -y mariadb-server ufw

echo "* Firewall - open port 3306 ..."
sudo ufw allow 3306
sudo ufw enable

echo "* Create and load the database ..."
mysql -u root < /vagrant/db_setup.sql

echo "* Update mariadb config and started mariadb service ..."
sudo cat /vagrant/50-server.conf > /etc/mysql/mariadb.conf.d/50-server.cnf
sudo systemctl start mariadb
sudo systemctl enable mariadb