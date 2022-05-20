terraform {
    required_providers {
        docker = {
            source = "kreuzwerker/docker"
        }
    }
}

resource "docker_image" "img-rabbitmq" {
  name = "rabbitmq:3.10-management"
}

resource "docker_container" "rabbitmq" {
  name = "rabbitmq"
  hostname = "rabbitmq"
  image = docker_image.img-rabbitmq.latest
  ports {
      internal = 5672
      external = 5672
  }
  ports {
      internal = 15672
      external = 15672
  }
  ports {
      internal = 15692
      external = 15692
  }
  networks_advanced {
      name = "appnet"
  }
}