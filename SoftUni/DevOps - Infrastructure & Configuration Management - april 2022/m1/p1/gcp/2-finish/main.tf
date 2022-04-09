terraform {
  required_providers {
    google = {
      source = "hashicorp/google"
    }
  }
}

provider "google" {
  credentials = file("<FILE_NAME>")

  project = "<PROJECT_ID>"
  region  = "europe-north1"
  zone    = "europe-north1-b"
}

resource "google_compute_network" "vnet" {
  name = "vnet"
}

resource "google_compute_firewall" "allow_ssh" {
  name    = "allow-ssh"
  network = google_compute_network.vnet.name
  source_ranges = ["0.0.0.0/0"]

  allow {
    protocol = "tcp"
    ports    = ["22"]
  }
}

resource "google_compute_instance" "vm1" {
  name         = "vm1"
  machine_type = "e2-micro"

  metadata = {
    ssh-keys = "dimitar:${file("~/.ssh/id_rsa.pub")}"
  }

  boot_disk {
    initialize_params {
      image = "debian-cloud/debian-11"
    }
  }

  network_interface {
    network = google_compute_network.vnet.name
    access_config {
    }
  }
}

output "public_ip" {
  value = google_compute_instance.vm1.network_interface[0].access_config[0].nat_ip
}
