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
        stage('Publish'){
            steps{
                bat 'dotnet publish -o C:\\inetpub\\wwwroot\\Ethereals'
            }
        }
        stage('Run'){
           tools {
               Windows_Exe "cmd"
            }   
            steps{
                bat 'C:\\inetpub\\wwwroot\\Ethereals\\Ethereals.exe'
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
    post{
              failure{
                       mail bcc: '', body: 'Hubo un error.', cc: '', from: 'andresgarcia7960@gmail.com', replyTo: '', subject: 'Resultado del programa', to: 'andresgarciapacheco7@gmail.com'
                     }
             success{
                      mail bcc: '', body: 'El programa ha sido compilado y ejecutado de manera exitosa', cc: '', from: 'andresgarcia7960@gmail.com', replyTo: '', subject: 'Resultado del programa', to: 'andresgarciapacheco7@gmail.com'
                     }
            }
}
