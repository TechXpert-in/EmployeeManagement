pipeline {
    agent any

    environment {
        PROJECT_PATH = 'C:\\inetpub\\EmployeeManagement'       // Update if your csproj is in subfolders
        DEPLOY_PATH = 'C:\\inetpub\\Published\\EmpMangmnt'
    }

    stages {
         stage('Update Project') {
                steps {
                    script {
                        def repoDir = 'C:\\inetpub\\EmployeeManagement'
                        if (fileExists("${repoDir}\\.git")) {
                            dir(repoDir) {
                                bat 'git pull origin main'
                            }
                        } else {
                            dir('C:\\inetpub') {
                                bat 'git clone https://github.com/TechXpert-in/EmployeeManagement.git'
                            }
                        }
                    }
              }
            }

       
        stage('Build') {
            steps {
                bat "dotnet clean"
                bat "dotnet build %PROJECT_PATH% --configuration Release"
            }
        }
        stage('Stop IIS Site') {
            steps {
                echo "🛑 Stopping IIS Site..."
                bat 'powershell.exe Stop-WebSite -Name "EmpMangmnt"'
                bat 'ping -n 10 127.0.0.1 > nul'

            }
        }
        stage('Kill Processes Holding DLLs') {
            steps {
                bat 'taskkill /F /IM w3wp.exe || echo No w3wp running'
                bat 'taskkill /F /IM dotnet.exe || echo No dotnet running'
            }
        }
         
        stage('Publish') {
            steps {
                bat "dotnet publish %PROJECT_PATH% -c Release -o %DEPLOY_PATH%"
            }
        }

        stage('Restart IIS') {
            steps {
                bat "iisreset"
            }
        }
    }

    post {
        success {
            echo '✅ Application published and deployed to IIS successfully!'
        }
        failure {
            echo '❌ Deployment failed. Please check the logs.'
        }
    }
}
