#!/bin/bash

echo "* Add hosts ..."
echo "192.168.56.100 web.do1.lab web" >> /etc/hosts
echo "192.168.56.101 db.do1.lab db" >> /etc/hosts

echo "* Install Software ..."
sudo apt upgrade -y
sudo apt install -y apache2 php php-mysqlnd ufw

echo "* Firewall - open port 80..."
sudo ufw allow 'WWW'
sudo ufw enable

echo "* Start HTTP ..."
sudo systemctl start apache2
sudo systemctl enable apache2

echo "* Copy web site files to /var/www/html/ ..."
rm -rdf /var/www/html/index.html
cp /vagrant/* /var/www/html
