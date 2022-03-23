#!/bin/bash

# Change these two (remove the <> as well)
CRED_NAME=dreed657
CRED_PASS=8eb76f1c-87bc-4b78-a391-434a048d0bf1

systemctl stop jenkins

sed -i 's/# arguments to pass to java/JAVA_OPTS="-Djenkins.install.runSetupWizard=false"/' /etc/default/jenkins

mkdir /var/lib/jenkins/init.groovy.d
cp /vagrant/jenkins/*.groovy /var/lib/jenkins/init.groovy.d/
chown -R jenkins:jenkins /var/lib/jenkins/init.groovy.d/

systemctl start jenkins

wget https://github.com/jenkinsci/plugin-installation-manager-tool/releases/download/2.12.3/jenkins-plugin-manager-2.12.3.jar

java -jar jenkins-plugin-manager-*.jar --war /usr/share/java/jenkins.war --plugin-file /vagrant/jenkins/plugins.txt -d /var/lib/jenkins/plugins --verbose

systemctl restart jenkins

wget http://192.168.56.201:8080/jnlpJars/jenkins-cli.jar

/vagrant/jenkins/add-jenkins-credentials.sh vagrant vagrant vagrant

/vagrant/jenkins/add-jenkins-credentials.sh docker-hub $CRED_NAME $CRED_PASS

/vagrant/jenkins/add-jenkins-slave.sh containers.do1.exam vagrant

/vagrant/jenkins/add-jenkins-job.sh
