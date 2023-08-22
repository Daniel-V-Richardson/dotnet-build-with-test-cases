pipeline {
    agent any
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
            }
        }
    }
}