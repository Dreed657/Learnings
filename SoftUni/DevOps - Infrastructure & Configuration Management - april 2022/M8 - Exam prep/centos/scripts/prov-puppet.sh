#!/bin/bash

echo "Install puppet ..."
rpm -Uvh https://yum.puppet.com/puppet6-release-el-8.noarch.rpm
dnf install -y puppet-agent