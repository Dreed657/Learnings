#!/bin/bash

echo "Add EPEL repo ..."
dnf install -y epel-release

echo "Install python3 ..."
dnf install -y python3

echo "Install python docker module ..."
pip3 install docker

