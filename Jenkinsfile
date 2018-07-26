pipeline{
    agent any
		
	environment {
		VERSION_NUMBER = "1.0.${env.BUILD_ID}"
		AUTHOR_NAME = bat(script: "git show -s --format='%%an' HEAD", returnStdout: true).split('\r\n')[2].trim().replace("'","")
	}
	
	options{
            buildDiscarder(logRotator(artifactDaysToKeepStr: '', artifactNumToKeepStr: '5', daysToKeepStr: '', numToKeepStr: '5'))
    }
	
    stages{
	
        stage('Build'){
            steps {
                echo 'Building...'
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
		
        stage('Unit Tests'){
			when {
				expression {env.BRANCH_NAME == 'master' || env.BRANCH_NAME == 'develop'}
			}
            steps{
                echo 'Testing...'
				bat 'call "C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MsBuild.exe" "C:\\Users\\lucas.beck\\Documents\\Visual Studio 2015\\Projects\\TesteGitHub\\TesteGitHub\\TesteGitHubTests\\TesteGitHubTests.csproj" /p:Configuration=Release /p:BuildEnviroment=TesteGitHubTests'
				bat 'call "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\Common7\\IDE\\MSTest.exe" /testcontainer:"C:\\Users\\lucas.beck\\Documents\\Visual Studio 2015\\Projects\\TesteGitHub\\TesteGitHub\\TesteGitHubTests\\bin\\Release\\TesteGitHubTests.dll" /nologo'
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
			emailext body: 'SUCCESSFUL: Job \'${env.JOB_NAME}\' by \'@${env.AUTHOR_NAME}\'', subject: 'Build and Publish SUCCESSFUL', to: 'lucas.bona.beck@gmail.com'			
		}
		
		aborted {
			emailext body: 'SUCCESSFUL: Job \'${env.JOB_NAME}\' by \'@${env.AUTHOR_NAME}\'', subject: 'Build and Publish SUCCESSFUL', to: 'lucas.bona.beck@gmail.com'
		}
		
		failure {
			emailext body: 'FAILED: Job \'${env.JOB_NAME}\' by \'@${env.AUTHOR_NAME}\'', subject: 'Build and Publish FAILED', to: 'lucas.bona.beck@gmail.com'
		}
	}    
}


