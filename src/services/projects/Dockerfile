FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

# Pass as build argument: "docker-compose build --build-arg NUGET_FEED_URL=EXAMPLE"
# Name of the ARGs is made available as an environment variable during the scope of the build
# These will be used inside the Nuget.Config as env vars
ARG NUGET_FEED_URL
ARG NUGET_FEED_USERNAME
ARG NUGET_FEED_PASSWORD

# Set the working dir and copy necessary files
WORKDIR /src
COPY ./projects ./
COPY ./NuGet.Config ./

# Restore dependencies and publish binaries into /app
RUN dotnet restore "BldIt.Projects.Api/BldIt.Projects.Api.csproj" --disable-parallel --configfile ./NuGet.Config 
RUN dotnet publish "BldIt.Projects.Api/BldIt.Projects.Api.csproj" -c Release -o /app --no-restore

RUN rm ./NuGet.Config

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS runtime
WORKDIR /app

# So it takes the appsettings.Docker.json into consideration 
ENV ASPNETCORE_ENVIRONMENT Docker
ENV ASPNETCORE_URLS http://+:5001

COPY --from=build /app ./

# Run app in port:
EXPOSE 5001
ENTRYPOINT ["dotnet", "BldIt.Projects.Api.dll"]