install.mariadb:
  pkg.installed:
    - pkgs:
      - mariadb-client
      - mariadb-server
      
config.db:
  file.line:
    - name: /etc/mysql/mariadb.conf.d/50-server.cnf
    - content: 'bind-address = 0.0.0.0'
    - mode: replace
    - match: bind-address
      
/tmp:
  file.recurse:
    - source: salt://app/

import.db:
  cmd.run:
    - name: mysql -u root --default-character-set='utf8' < /tmp/db_setup.sql

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
    
stop.mariadb.service:
  service.dead:
    - name: mariadb
    
start.mariadb.service:
  service.running:
    - name: mariadb
