$packages = [ 'httpd', 'php', 'php-mysqlnd' ]

package { $packages: }

file { '/etc/httpd/conf.d/vhost-app1.conf':
    ensure => present,
    source => "/vagrant/config/vhost-app1.conf"
}

file { '/etc/httpd/conf.d/vhost-app2.conf':
    ensure => present,
    source => "/vagrant/config/vhost-app2.conf"
}

file { '/var/www/app1':
    ensure => 'directory',
    recurse => true,
    source => "/vagrant/apps/app1/web"
}

file { '/var/www/app2' :
    ensure => 'directory',
    recurse => true,
    source => "/vagrant/apps/app2/web"
}

class { 'firewall': }

firewall { '000 accept 8081/tcp': 
    action => 'accept',
    dport => 8081,
    proto => 'tcp',
}

firewall { '000 accept 8082/tcp': 
    action => 'accept',
    dport => 8082,
    proto => 'tcp',
}

class { selinux: 
    mode => 'permissive',
}

file_line { 'hosts-db':
    ensure => present,
    path => '/etc/hosts',
    line => '192.168.56.102 db.do2.exam db',
    match => '^192.168.56.102',
}

service { httpd: 
    ensure => running, 
    enable => true,
}
