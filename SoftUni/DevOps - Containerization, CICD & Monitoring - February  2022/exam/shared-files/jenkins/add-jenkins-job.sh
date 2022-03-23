#!/bin/bash

# 
# Create Jenkins job
# 

java -jar /home/vagrant/jenkins-cli.jar -s http://192.168.56.201:8080/ -http -auth admin:admin create-job exam-job < /vagrant/jenkins/exam-job.xml
