package 'Install Apache web server and dependencies' do
  package_name [ "httpd", "php", "php-mysqlnd" ]
end

service 'Start and Enable Apache web server' do
  service_name "httpd"
  action [ :enable, :start ]
end

['bulgaria-map.png', 'index.php'].each do |file|
  cookbook_file "/var/www/html/#{file}" do
    source "#{file}"
    mode "0644"
  end
end

firewalld_service 'http'

selinux_state 'permissive' do
  action :permissive
end

ruby_block "insert_line" do
  block do
    file = Chef::Util::FileEdit.new("/etc/hosts")
    file.insert_line_if_no_match("^192.168.99.101", "192.168.99.101  web.do2.lab  web")
    file.insert_line_if_no_match("^192.168.99.102", "192.168.99.102  db.do2.lab  db")
    file.write_file
  end
end
