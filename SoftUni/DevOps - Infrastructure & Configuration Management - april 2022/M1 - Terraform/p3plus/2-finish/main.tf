# Configure the provider. This can be omitted if matches the configuration made with "aws configure"
provider "aws" {
  access_key = "<ACCESS-KEY>"
  secret_key = "<SECRET-KEY>"
  region     = "eu-central-1"
}

# Collect and store data about the default VPC
data "aws_vpc" "default" {
  default = true
}

# Collect and store data about the subnets in the default VPC
data "aws_subnets" "all" {
  filter {
    name   = "vpc-id"
    values = [data.aws_vpc.default.id]
  }
} 

# Get the latest AMI with Amazon Linux 2
data "aws_ami" "amazon_linux" {
  most_recent = true
  owners = ["amazon"]
  filter {
    name = "name"
    values = [
      "amzn2-ami-hvm-*-x86_64-gp2",
    ]
  }
  filter {
    name = "owner-alias"
    values = [
      "amazon",
    ]
 }
}

# Invoke the Security Group module and create one with a few rules
module "security_group" {
  source      = "terraform-aws-modules/security-group/aws"
  name        = "do2-aws-modules-sg"
  description = "Security group made using an AWS module"
  vpc_id      = data.aws_vpc.default.id
  ingress_cidr_blocks = ["0.0.0.0/0"]
  ingress_rules       = ["http-80-tcp", "all-icmp", "ssh-tcp"]
  egress_rules        = ["all-all"]
}

# Invoke the EC2 module and create an instance
module "ec2" {
  source = "terraform-aws-modules/ec2-instance/aws"
  name                        = "do2-aws-modules-ec2"
  ami                         = data.aws_ami.amazon_linux.id
  instance_type               = "t2.micro"
  key_name                    = "terraform-key"
  subnet_id                   = tolist(data.aws_subnets.all.ids)[0]
  vpc_security_group_ids      = [module.security_group.security_group_id]
  associate_public_ip_address = true
  user_data                   = file("./nginx.sh")
}
