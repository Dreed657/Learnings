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

resource "google_compute_instance" "vm1" {
  name         = "vm1"
  machine_type = "e2-micro"

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