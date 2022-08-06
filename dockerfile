FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

WORKDIR /build
COPY . ./

ARG artifactoryUsername
ARG artifactoryPassword

RUN dotnet nuget add source https://farmer.jfrog.io/artifactory/api/nuget/core-nuget-local  -n Artifactory --username $artifactoryUsername --password $artifactoryPassword --store-password-in-clear-text 

RUN dotnet restore ./AmazingGame3.sln 
RUN dotnet test ./AmazingGame3.sln 
RUN dotnet publish ./AmazingGame3.Host.csproj -c Release -o /build/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS release

EXPOSE 80
WORKDIR /app
COPY --from=build /build/publish ./

CMD ["dotnet", "AmazingGame3.Host.dll"]