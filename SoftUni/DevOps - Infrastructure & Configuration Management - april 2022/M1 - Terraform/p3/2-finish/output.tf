output "public_ip" {
  value = aws_instance.do2-server.*.public_ip
}
