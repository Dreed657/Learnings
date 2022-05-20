class { '::mysql::server': 
  root_password => '12345',
  remove_default_accounts => true,
  restart => true,
  override_options => {
    mysqld => { bind-address => '0.0.0.0' }
  },
}

mysql::db { 'votingtime' : 
  user => "voter",
  password => "Password1",
  dbname => 'votingtime',
  host => '%',
  sql =>  '/vagrant/apps/app1/db/db_setup.sql',
  enforce_sql => true,
}

mysql::db { 'bulgaria' : 
  user => "web_user",
  password => "Password1",
  dbname => 'bulgaria',
  host => '%',
  sql =>  '/vagrant/apps/app2/db/db_setup.sql',
  enforce_sql => true,
}

file_line { 'hosts-web':
    ensure => present,
    path => '/etc/hosts',
    line => '192.168.56.101 web.do2.exam web',
    match => '^192.168.56.101',
}

class { 'firewall': }

firewall { '000 accept 3306/tcp': 
    action => 'accept',
    dport => 3306,
    proto => 'tcp',
}
