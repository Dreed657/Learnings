package 'Install MariaDB server and dependencies' do
  package_name [ "mariadb-client", "mariadb-server" ]
end

ruby_block "replace_line" do
  block do
    file = Chef::Util::FileEdit.new("/etc/mysql/mariadb.conf.d/50-server.cnf")
    file.search_file_replace_line("^bind-address", "bind-address = 0.0.0.0")
    file.write_file
  end
end

cookbook_file "/tmp/db_setup.sql" do
  source "db_setup.sql"
  mode "0644"
end

execute 'initialize db' do
  command "mysql -u root --default-character-set='utf8' < /tmp/db_setup.sql"
end

ruby_block "insert_line" do
  block do
    file = Chef::Util::FileEdit.new("/etc/hosts")
    file.insert_line_if_no_match("^192.168.99.101", "192.168.99.101  web.do2.lab  web")
    file.insert_line_if_no_match("^192.168.99.102", "192.168.99.102  db.do2.lab  db")
    file.write_file
  end
end

service 'Stop MariaDB server' do
  service_name "mariadb"
  action [ :stop ]
end

service 'Start MariaDB server' do
  service_name "mariadb"
  action [ :start ]
end
