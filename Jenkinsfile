pipeline {
    agent any
    environment {
        DOCKER_IMAGE_VERSION = "1.1.${BUILD_ID}"
        DOCKER_IMAGE_NAME = "danielshloklabs/dotnetbuild"
    }
    stages {
        stage('PR Build'){
            stages {
                stage('Test') {
                    tools {
                        dotnetsdk 'dotnet-sdk-6.0'
                    }
                    steps {
                        dir('TestProject') {
                            sh '''
                                dotnet test Test.csproj --collect:"XPlat Code Coverage"
                            '''
                        }
                    }
                }
                stage('Code Analysis') {
                    tools {
                        dotnetsdk 'dotnet-sdk-6.0'
                    }
                    steps {
                        dir('Addition') {
                            sh '''
                                dotnet build Jenkins-build.sln
                            '''
                        }
                    }
                }
                stage('Debug') {
    steps {
        sh 'ls -l /var/jenkins_home/workspace/dotnet-build/Addition'
    }
}
                stage('Build Docker Image') {
                    steps {
                        script {
                   
                            sh "docker build -t ${DOCKER_IMAGE_NAME}:${DOCKER_IMAGE_VERSION} -f /var/jenkins_home/workspace/dotnet-build/Addition/Dockerfile ."
                        }
                    }
                }
                stage('Push Docker Image') {
                    steps {
                        script {
                           
                            sh "docker login -u danielshloklabs -p Hisgrace2001"
                      
                            sh "docker push ${DOCKER_IMAGE_NAME}:${DOCKER_IMAGE_VERSION}"
                        }
                    }
                }
                      stage('Deploy to Minikube') {
            steps {
                script {
                    def appLabel = 'my-app'
                    def namespace = 'default'
                    def dockerImage = "${DOCKER_IMAGE_NAME}:${DOCKER_IMAGE_VERSION}"
                    sh 'minikube start' // Start Minikube cluster
                    // Set Docker environment to use Minikube's Docker daemon
                    sh 'eval $(minikube docker-env)'
                    sh "kubectl apply -f deploymentservice.yaml -n ${namespace}" // Apply your Kubernetes deployment YAML
                    // Update the deployment's image to your built Docker image
                    sh "kubectl set image deployment/${appLabel} ${appLabel}=${dockerImage} -n ${namespace}"
                    sh 'minikube service my-app-service -n ${namespace}' // Open the service in a browser
                    sh 'minikube stop' // Stop Minikube cluster
                }
            }
        }
        }
    }
    }
    post {
        always {
            echo 'Pipeline completed'
        }
        success {
            echo 'Pipeline successful!'
        }
        failure {
            echo 'Pipeline failed'
        }
    }
}