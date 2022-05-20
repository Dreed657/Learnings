#!/bin/bash

echo "Install firewall module"
puppet module install puppetlabs-firewall
puppet module install puppet-selinux