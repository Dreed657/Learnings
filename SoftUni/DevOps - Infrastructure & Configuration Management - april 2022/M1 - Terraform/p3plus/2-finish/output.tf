output public_ip {
  description = "Public IP"
  value = module.ec2.public_ip
}

output public_dns {
  description = "Public DNS"
  value = module.ec2.public_dns
}