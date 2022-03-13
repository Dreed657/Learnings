#!/bin/bash

# 
# Create Jenkins job
# 

java -jar /home/vagrant/jenkins-cli.jar -s http://192.168.56.101:8080/ -http -auth admin:admin create-job homework < /vagrant/jenkins/job.xml
