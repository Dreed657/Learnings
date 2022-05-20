docker_installation 'default'

docker_service 'default' do
  action [:create, :start]
end
