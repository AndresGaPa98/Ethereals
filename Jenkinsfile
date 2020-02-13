pipeline{
    agent any
    stages{
      stage('Restore PACKAGES') {
          steps {
                    echo 'Restoring packages'
                    bat "dotnet restore"
                    echo 'Packages restored'
          }
        }
        
        stage('Clean'){
            steps{
                    echo 'Cleanning...'
                    bat "dotnet clean"
                    echo '-------------------------------------------------------------------------------------'
            
            }
        }
        stage('Build'){
            steps{
                    echo 'Building...'
                    bat "dotnet build"
                    echo '-------------------------------------------------------------------------------------'
            
            }
        }
        
        stage('Unit Test'){
               steps{
                      echo 'Changing folder...'
                      bat 'cd Ethereals.Test'
                      echo 'Running Unit Test'
                      bat 'dotnet test'
                      echo '----------------------------------------------------------------------------------'
                      
               }
        }
        stage('Version'){
            steps{
                    echo 'The version is:'
                    bat "dotnet --version"
                    echo '-------------------------------------------------------------------------------------'
            
            }
        }
    }
}
