  
# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
# COPY *.sln .
# COPY TemplateDotnetcoreApplication.Api/*.csproj ./TemplateDotnetcoreApplication.Api/
# COPY TemplateDotnetcoreApplication.Domain/*.csproj ./TemplateDotnetcoreApplication.Domain/
# COPY TemplateDotnetcoreApplication.Infrastructure/*.csproj ./TemplateDotnetcoreApplication.Infrastructure/
# RUN dotnet restore -r linux-x64

COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
# COPY TemplateDotnetcoreApplication.Api/. ./TemplateDotnetcoreApplication.Api/
# COPY TemplateDotnetcoreApplication.Domain/. ./TemplateDotnetcoreApplication.Domain/
# COPY TemplateDotnetcoreApplication.Infrastructure/. ./TemplateDotnetcoreApplication.Infrastructure/
# WORKDIR /source/TemplateDotnetcoreApplication.Api
# RUN dotnet publish -c release -o /app -r linux-x64 --self-contained false --no-restore

COPY . ./
RUN dotnet publish -c release -o /app -r linux-x64 --self-contained false --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet"]