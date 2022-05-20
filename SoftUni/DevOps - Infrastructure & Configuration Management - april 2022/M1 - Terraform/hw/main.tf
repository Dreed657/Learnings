provider "docker" {
  host = "tcp://192.168.56.100:2375"
}

terraform {
  required_providers {
    docker = {
      source = "kreuzwerker/docker"
    }
  }
}

resource "docker_image" "bgapp-web" {
  name = "shekeriev/bgapp-web:latest"
}

resource "docker_image" "bgapp-db" {
  name = "shekeriev/bgapp-db:latest"
}

resource "docker_network" "private_network" {
  name = "app-net"
}

resource "docker_container" "con-web" {
  name  = "web"
  image = docker_image.bgapp-web.latest
  networks_advanced {
    name = "app-net"
  }
  ports {
    internal = 80
    external = 8080
  }
}

resource "docker_container" "con-db" {
  name  = "db"
  image = docker_image.bgapp-db.latest
  env   = ["MYSQL_ROOT_PASSWORD=12345"]
  networks_advanced {
    name = "app-net"
  }
}
