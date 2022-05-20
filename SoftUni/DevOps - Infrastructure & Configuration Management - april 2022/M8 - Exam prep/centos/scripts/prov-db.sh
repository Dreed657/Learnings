#!/bin/bash

echo "Install modules"
puppet module install puppetlabs-firewall
puppet module install puppetlabs/mysql