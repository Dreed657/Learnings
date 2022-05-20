install.apache:
  pkg.installed:
    - pkgs:
      - httpd
      - php
      - php-mysqlnd
      - policycoreutils
      - policycoreutils-python-utils
    
selinux_mode:
  selinux.mode:
    - name: permissive
    
allow.port:
  firewalld.present:
    - name: public
    - ports:
      - 80/tcp
      
/var/www/html:
  file.recurse:
    - source: salt://app/

web.host:
  file.line:
    - name: /etc/hosts
    - content: '192.168.99.101  web.do2.lab web'
    - mode: insert
    - after: 127.0.1.1
    
db.host:
  file.line:
    - name: /etc/hosts
    - content: '192.168.99.102  db.do2.lab db'
    - mode: insert
    - after: 192.168.99.101
    
start.httpd.service:
  service.running:
    - name: httpd
