pipeline 
{
    agent any

    stages 
    {
        stage('Clone the project') 
        {
            steps 
            {
                sh 'rm -rf bgapp || true'
                sh 'git clone https://github.com/shekeriev/bgapp.git'
            }
        }
        stage('Prepare the network')
        {
            steps
            {
                sh 'docker network ls | grep appnet || docker network create appnet'

            }
        }
        stage('Build the web image')
        {
            steps
            {
                sh 'cd bgapp && docker image build -t img-web -f Dockerfile.web .'

            }
        }
        stage('Run the web component')
        {
            steps
            {
                sh 'docker container rm -f web || true'
                sh 'docker container run -d --name web --net appnet -p 9090:80 -v $(pwd)/bgapp/web:/var/www/html:ro img-web'
            }
        }
        stage('Build the db image')
        {
            steps
            {
                sh 'cd bgapp && docker image build -t img-db -f Dockerfile.db .'

            }
        }
        stage('Run the db component')
        {
            steps
            {
                sh 'docker container rm -f db || true'
                sh 'docker container run -d --name db --net appnet -e MYSQL_ROOT_PASSWORD=12345 img-db'
            }
        }
    }
}