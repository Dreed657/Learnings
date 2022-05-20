# Exam softuni devops advanced 29/05/2022

### Disclamer

    You can find photos of proof in screenshots folder.

    Docker vm:
        Shell 1:
            Install python3 and ansible docker module

        Ansible:
            Provisioned docker from geerlingguy.docker and added vagrant user to docker user group

        Shell 2:
            Create docker network
            Install terraform
            Use terraform to init the configuration and apply it
                I did create a single tf module to make it easy to run with single apply

        Terraform 1 starts prom + grafana (configured)
        Terraform 2 starts rabbitmq
        Terraform 3 starts producer and consumar based on provided images

        Grafana dashboard used:
            https://grafana.com/grafana/dashboards/10991

    Web vm:
        Shell 1:
            Install puppet agent

        Shell 2:
            Install nessasary modules

        Using vagrant puppet provisioner to run manifests

        Puppet actions:
            Copy virtualhost configs to httpd configs
            Copy all contents to /var/www/app*
            Update firewall rules for 8081 & 8082
            Change selinux mode
            Update /etc/hosts
            Ensures that https service is started

    Db vm:
        Shell 1:
            Install puppet agent

        Shell 2:
            Install nessasary modules

        Using vagrant puppet provisioner to run manifests

        Puppet actions:
            Configures mysql server
            Creating 2 databases for both apps
            Updating firewall rules
