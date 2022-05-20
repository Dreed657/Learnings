terraform {
    required_providers {
        docker = {
            source = "kreuzwerker/docker"
        }
    }
}

resource "docker_image" "img-rabbit-prod" {
  name = "shekeriev/rabbit-prod"
}

resource "docker_image" "img-rabbit-cons" {
  name = "shekeriev/rabbit-cons"
}

resource "docker_container" "rabbit-producer" {
  name = "rabbit-producer"
  image = docker_image.img-rabbit-prod.latest
  env = ["BROKER=rabbitmq"]
  networks_advanced {
      name = "appnet"
  }
}

resource "docker_container" "rabbit-consumer-cpu" {
  name = "rabbit-consumer-cpu"
  image = docker_image.img-rabbit-cons.latest
  env = ["BROKER=rabbitmq", "TOPICS=cpu.*"]
  networks_advanced {
      name = "appnet"
  }
}

resource "docker_container" "rabbit-consumer-ram" {
  name = "rabbit-consumer-ram"
  image = docker_image.img-rabbit-cons.latest
  env = ["BROKER=rabbitmq", "TOPICS=ram.*"]
  networks_advanced {
      name = "appnet"
  }
}