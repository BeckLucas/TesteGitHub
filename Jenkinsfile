pipeline{
    agent any
	
	options{
            buildDiscarder(logRotator(artifactDaysToKeepStr: '', artifactNumToKeepStr: '5', daysToKeepStr: '', numToKeepStr: '5'))
    }
	
    stages{
	
        stage('Build'){
            steps {
                echo 'Building..'
                script{
                    try{
                        bat 'call "C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MsBuild.exe" "C:\\Users\\lucas.beck\\Documents\\Visual Studio 2015\\Projects\\TesteGitHub\\TesteGitHub\\TesteGitHubWF\\TesteGitHubWF.csproj" /p:Configuration=Release /p:BuildEnviroment=TesteGitHub'                
                    }
                    catch (error) {
                        currentBuild.result = 'FAILURE'
						error("Ocorreu um erro no build!")
                    }                 
                }                
            }   
        }
		
        stage('Test'){
			when {
				expression {env.BRANCH_NAME == 'master' || env.BRANCH_NAME == 'develop'}
			}
            steps{
                echo 'Testing...'
            }   
        }
		
		stage('Confirm Deploy'){
			when {
				expression {env.BRANCH_NAME == 'master' || env.BRANCH_NAME == 'develop'}
			}
			steps{
				timeout(time:1, unit:'HOURS') {
                    input message:'Continuar com o Deploy?'
                }     
			}
		}
		
        stage('Deploy'){
			when {
				expression {env.BRANCH_NAME == 'master' || env.BRANCH_NAME == 'develop'}
			}
            steps{
				echo 'Deploy...'
				bat 'call "C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe" /t:publish "C:\\Users\\lucas.beck\\Documents\\Visual Studio 2015\\Projects\\TesteGitHub\\TesteGitHub\\TesteGitHubWF\\TesteGitHubWF.csproj" /p:Configuration=Release /p:BuildEnvironment=TesteGitHubWF'
            }   
        }
    }
	
	post {
		success {
			emailext body: 'SUCCESSFUL: Job JOBNAME by AUTORNAME', subject: 'Build and Publish SUCCESSFUL', to: 'lucas.bona.beck@gmail.com'
		}
		
		aborted {
			emailext body: 'SUCCESSFUL: Job JOBNAME by AUTORNAME', subject: 'Build and Publish SUCCESSFUL', to: 'lucas.bona.beck@gmail.com'
		}
		
		failure {
			emailext body: 'FAILED: Job JOBNAME by AUTORNAME', subject: 'Build and Publish FAILED', to: 'lucas.bona.beck@gmail.com'
		}
	}    
}


