pipeline{
    agent any

	
    stages{
		try{
			stage('Build'){
				steps{
					bat 'call "C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MsBuild.exe" "C:\\Users\\lucas.beck\\Documents\\Visual Studio 2015\\Projects\\TesteGitHub\\TesteGitHub\\TesteGitHubWF\\TesteGitHubWF.csproj" /p:Configuration=Release /p:BuildEnviroment=TesteGitHub'
					echo 'Build...'
				}   
			}
		}catch(err) {
			currentBuild.result = 'FAILURE'
			throw e
		}
        
        stage('Teste'){
            steps{
                echo 'Test...'
            }   
        }
        stage('Deploy'){
            steps{
				bat 'call "C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\MSBuild.exe" /t:publish "C:\\Users\\lucas.beck\\Documents\\Visual Studio 2015\\Projects\\TesteGitHub\\TesteGitHub\\TesteGitHubWF\\TesteGitHubWF.csproj" /p:Configuration=Release /p:BuildEnvironment=TesteGitHubWF'
                echo 'Deploy...'
            }   
        }
    }
    
}