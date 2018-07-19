pipeline{
    agent any

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
						return
                    }                 
                }                
            }   
        }
        stage('Teste'){
            steps{
                echo 'Test...'
            }   
        }
        stage('Deploy'){
            steps{
				echo 'Deploy...'
				bat 'call "C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe" /t:publish "C:\\Users\\lucas.beck\\Documents\\Visual Studio 2015\\Projects\\TesteGitHub\\TesteGitHub\\TesteGitHubWF\\TesteGitHubWF.csproj" /p:Configuration=Release /p:BuildEnvironment=TesteGitHubWF'
            }   
        }
    }
    
}


