#!/bin/sh 
sudo amazon-linux-extras install -y nginx1
sudo systemctl start nginx
sudo systemctl enable nginx 
echo '<h1>Hello from NGINX running on AWS EC2 instance</h1>' > /usr/share/nginx/html/index.html