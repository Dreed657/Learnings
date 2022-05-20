$packages = [ 'httpd', 'php', 'php-mysqlnd' ]

package { $packages: }

service { httpd:
  ensure => running,
  enable => true,
}

file { '/var/www/html/index.php':
  ensure => present,
  source => "/vagrant/app/web/index.php",
}

file { '/var/www/html/bulgaria-map.png':
  ensure => present,
  source => "/vagrant/app/web/bulgaria-map.png",
}

class { 'firewall': }

firewall { '000 accept 80/tcp':
  action   => 'accept',
  dport    => 80,
  proto    => 'tcp',
}

selboolean { 'Apache SELinux':
  name       => 'httpd_can_network_connect', 
  persistent => true, 
  provider   => getsetsebool, 
  value      => on, 
} 

file_line { 'hosts-web':
    ensure => present,
    path   => '/etc/hosts',
    line   => '192.168.99.101  web.do2.lab  web',
    match  => '^192.168.99.101',
}

file_line { 'hosts-db':
    ensure => present,
    path   => '/etc/hosts',
    line   => '192.168.99.102  db.do2.lab  db',
    match  => '^192.168.99.102',
}
