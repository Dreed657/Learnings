# Variables
# Some sensitive information
variable "v-access-key" {}
variable "v-secret-key" {}

# Shareable information
variable "v-ami-image" {
    description = "AMI image"
    default = "ami-0dcc0ebde7b2e00db"
}
variable "v-instance-type" {
    description = "EC2 instance type"
    default = "t2.micro"
}
variable "v-instance-key" {
    description = "Instance key"
    default = "terraform-key"
}
variable "v-count" {
    description = "Resource count"
    default = "2"
}
data "aws_availability_zones" "do2-avz" {}
variable "do2-cidr" {
    type = list
    default = ["10.10.10.0/24", "10.10.11.0/24"] 
}
