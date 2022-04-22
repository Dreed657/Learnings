variable "mode" { 
  description = "mode: prod or dev"
}

variable "v_image" {
  description = "Image"
  type = map
}

variable "v_con_name" {
  description = "Container name"
  type = map
}

variable "v_int_port" {
  description = "Internal port"
  type = map
}

variable "v_ext_port" {
  description = "External port"
  type = map
}
