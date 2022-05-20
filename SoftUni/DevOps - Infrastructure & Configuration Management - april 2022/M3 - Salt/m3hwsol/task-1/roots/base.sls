download.get.docker:
  cmd.run:
    - name: curl -fsSL https://get.docker.com -o /tmp/get-docker.sh
    
install.docker:
  cmd.run:
    - name: bash /tmp/get-docker.sh
    
run.docker.service:
  service.running:
    - name: docker
    
modify.user:
  user.present:
    - name: vagrant
    - groups: 
      - docker
 
mynginx:
  docker_container.running:
    - image: nginx:latest
    - port_bindings:
      - 8000:80
