#!/bin/bash

echo "* Add Jenkins repository key"
curl -fsSL https://pkg.jenkins.io/debian/jenkins.io.key | tee /usr/share/keyrings/jenkins-keyring.asc > /dev/null

echo "* Add Jenkins repository"
echo deb [signed-by=/usr/share/keyrings/jenkins-keyring.asc] https://pkg.jenkins.io/debian binary/ | tee /etc/apt/sources.list.d/jenkins.list > /dev/null

echo "* Install Jenkins"
apt-get update
apt-get install -y jenkins

echo "* Adjust jenkins user"
usermod -s /bin/bash jenkins
echo -e 'Password1\nPassword1' | passwd jenkins

echo "* Adjust group membership"
usermod -aG docker jenkins

echo "* Restart the service to reflect the mmembership change"
systemctl restart jenkins

echo "* admin password is:"
cat /var/lib/jenkins/secrets/initialAdminPassword