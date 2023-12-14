pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                // Récupérer le code source depuis un référentiel Git
                checkout scm
            }
        }

        stage('Build and Publish') {
            steps {
                // Utiliser une image Docker avec SDK .NET Core 8.0 pour la construction
                script {
                    docker.image('mcr.microsoft.com/dotnet/sdk:8.0').inside('-v $PWD:/app') {
                        sh '''
                            # Définir le répertoire de travail dans le conteneur
                            cd /app

                            # Copier le fichier csproj et restaurer les dépendances
                            cp *.csproj ./
                            dotnet restore

                            # Copier tout le reste du code source dans le conteneur
                            cp -r . .

                            # Publier l'application en utilisant le profil de publication Release
                            dotnet publish -c Release -o out
                        '''
                    }
                }
            }
        }

        stage('Docker Build') {
            steps {
                // Utiliser Docker pour créer une image de l'application
                script {
                    docker.build("votre_image_docker:tag")
                }
            }
        }

        stage('Deploy') {
            steps {
                // Utiliser Docker pour exécuter l'application dans un conteneur
                script {
                    docker.image("votre_image_docker:tag").withRun('-p 8080:80 -d') {
                        // L'application est maintenant déployée et accessible sur le port 8080
                    }
                }
            }
        }
    }

    post {
        always {
            // Nettoyer les ressources, par exemple, supprimer les conteneurs temporaires
            sh 'docker system prune -f'
        }
    }
}
