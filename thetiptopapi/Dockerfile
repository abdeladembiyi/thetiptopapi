# Utiliser l'image SDK .NET Core 8.0 pour la construction
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Définir le répertoire de travail dans le conteneur
WORKDIR /app

# Copier le fichier csproj et restaurer les dépendances (cela permettra une construction plus rapide en utilisant le cache)
COPY *.csproj ./
RUN dotnet restore

# Copier tout le reste du code source dans le conteneur
COPY . .

# Publier l'application en utilisant le profil de publication Release
RUN dotnet publish -c Release -o out

# Utiliser une image légère ASP.NET Core pour exécuter l'application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Définir le répertoire de travail dans le conteneur
WORKDIR /app

# Copier les fichiers publiés depuis l'étape précédente dans ce conteneur
COPY --from=build /app/out .

# Définir l'URL à laquelle l'application écoutera (par défaut, c'est http://*:80)
ENV ASPNETCORE_URLS http://*:80

# Exposer le port 80 sur le conteneur
EXPOSE 80

# Démarrer l'application lorsqu'un conteneur basé sur cette image est lancé
ENTRYPOINT ["dotnet", "thetiptopapi.dll"]
