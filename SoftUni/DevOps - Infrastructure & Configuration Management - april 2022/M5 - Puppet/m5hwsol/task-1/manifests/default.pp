include 'docker'
 
docker::image { 'nginx': }
 
docker::run { 'nginx':
  image            => 'nginx',
  ports            => ['8080:80'],
}
