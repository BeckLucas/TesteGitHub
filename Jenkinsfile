pipeline{
    agent any
		
	environment {
		VERSION_NUMBER = "1.0.${env.BUILD_ID}"
		AUTHOR_NAME = bat(script: "git show -s --format='%%an' HEAD", returnStdout: true).split('\r\n')[2].trim().replace("'","")
	}
	
	options{
            buildDiscarder(logRotator(artifactDaysToKeepStr: '', artifactNumToKeepStr: '10', daysToKeepStr: '', numToKeepStr: '10'))
    }
	
    stages{
	
		stage('Checkout') {
			steps {
				
				echo 'Checkout...'
							
			}
		}
	
        stage('Build'){
            steps {
                echo 'Building...'
                script{
                    try{
                        bat 'call "C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe" "C:\\Portocred\\Git\\portosis\\Portosis\\PSFinanceiro.csproj" /t:Clean,Rebuild /p:Configuration=Release'
                    }
                    catch (error) {
                        currentBuild.result = 'FAILURE'
						error("Ocorreu um erro no build!")
                    }                 
                }                
            }   
        }       
			
        stage('Deploy'){
            steps{
				echo 'Deploy...'
				bat 'call "C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe" /t:publish "C:\\Portocred\\Git\\portosis\\Portosis\\PSFinanceiro.csproj" /p:Configuration=Release /p:BuildEnvironment=PSFinanceiro'
            }   
        }
    }
	
	post {
		always {
			echo 'Limpando diretórios do workspace'
		}
	
		success {
			echo 'Sucesso...'
		}
		
		aborted {
			echo 'Abortado...'
		}
		
		failure {
			echo 'Erro...'			
		}
	}    
}
