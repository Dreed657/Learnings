docker_image 'nginx' do
  action :pull
end

docker_container 'hw_nginx' do
  repo 'nginx'
  tag 'latest'
  port [ '8080:80' ]
  host_name 'www'
end
