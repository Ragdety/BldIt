# BldIt - Continuous Integration System

**BldIt** is a continuous integration system that allows developers to automate test cases, builds, code merging, and process execution. This project started as a hobby with the intention to combine the Software Development and DevOps industries into 1 project. As time passed, this project became my senior project for my last semester in university. And in the future, this can become an actual ci-cd system for people and companies to use to automate their development processes.

This system is made with a **microservice** architecture using the following technologies:

- C# with ASP.NET (.NET 6)
- GitHub Actions & Azure DevOps for continuous integration/delivery
- MongoDB for data storage
- RabbitMQ as a message broker for microservices
- SignalR for real-time log monitoring
- Docker/Docker-Compose for microservice containers
- Azure Pipelines to deploy to custom Nuget Artifact storage service
- JFrog to store custom nuget packages & BldIt libraries 
- xUnit for Unit/Integration testing of REST API
- Postman to test the microservices
- ANTLR for pipeline language

# BldIt CI-CD Pipeline Domain Specific Language
BldIt DSL was moved to its own GitHub repository: https://github.com/Ragdety/BldIt.Language

## Steps to run the application (Windows)
### .NET 6
Make sure you have .NET 6 installed first: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

### Authorization
You will need to ask for permission to be added to the JFrog artifactory in order to build the project with BldIt custom libraries.
(You can raise an issue for this).
I will only need your email and I will take care of giving you the auth details for your account.
I will give you the following information for the nuget artifactory: url, username, password.

> **Warning**: While I find a way to securely automate getting the credentials, new people will have to ask and I will manually add them to the artifactory and give it to them. Remember, this is just a senior project. The code and scripts are not production ready yet.

### NuGet Config
Once I give you the credentials and url, you will need to run the following script:
* [`AddBldItNugetSource.bat`](src/ci-cd/scripts/nuget/AddBldItNugetSource.bat) asks for the credentials and adds them to the default NuGet.Config file. If 
your NuGet.Config is located in a different folder, modify the configFile variable in the script accordingly:
```batch
set configFile=your/path/here/NuGet.Config
```

## Running with Docker

You must install Docker & Docker compose first (I recommend Docker Desktop: https://www.docker.com/products/docker-desktop/)
* [`infra.yml`](src/ci-cd/scripts/docker/infra.yml) has the infrastructure configuration (MongoDB & RabbitMQ instances).
* [`app.yml`](src/ci-cd/scripts/docker/app.yml) has the microservices configuration.

The scripts for windows are located under the docker folder: [`src/ci-cd/scripts/docker`](src/ci-cd/scripts/docker)
(Linux scripts - WIP)

### Running the infrastructure
```batch
./infra-run.bat
```

### Building the microservice containers
```batch
./app-build.bat
```

### Running the microservice containers
```batch
./app-run.bat
```

### App logs
```batch
./app-logs.bat
```
