#!/bin/bash

# This file is modified version of file from exercues

while true; do 
  echo 'Trying to connect to http://containers.do1.exam:3000 ...'; 
  if [ $(curl -s -o /dev/null -w "%{http_code}" http://containers.do1.exam:3000) == "200" ]; then 
    echo '... connected.'; 
    break; 
  else 
    echo '... no success. Sleep for 5s and retry.'; 
    sleep 5; 
  fi 
done

docker container exec -u 1000 gitea gitea admin user create --username vagrant --password vagrant --email vagrant@containers.do1.exam

git clone https://github.com/shekeriev/fun-facts /tmp/fun-facts

cd /tmp/fun-facts && git push -o repo.private=false http://vagrant:vagrant@containers.do1.exam:3000/vagrant/exam

curl -X 'POST' 'http://containers.do1.exam:3000/api/v1/repos/vagrant/exam/hooks' \
  -H 'accept: application/json' \
  -H 'authorization: Basic '$(echo -n 'vagrant:vagrant' | base64) \
  -H 'Content-Type: application/json' \
  -d '{
  "active": true,
  "branch_filter": "*",
  "config": {
    "content_type": "json",
    "url": "http://pipelines.do1.exam:8080/gitea-webhook/post",
    "http_method": "post"
  },
  "events": [
    "push"
  ],
  "type": "gitea"
}'
