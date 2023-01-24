FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

ARG NUGET_FEED_URL
ARG NUGET_FEED_USERNAME
ARG NUGET_FEED_PASSWORD

WORKDIR /src
COPY ./buildWorker ./
COPY ./NuGet.Config ./

RUN dotnet restore "BldIt.BuildWorker.Api/BldIt.BuildWorker.Api.csproj" --disable-parallel --configfile ./NuGet.Config 
RUN dotnet publish "BldIt.BuildWorker.Api/BldIt.BuildWorker.Api.csproj" -c Release -o /app --no-restore

RUN rm ./NuGet.Config

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS runtime
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT Docker
ENV ASPNETCORE_URLS http://+:5005

COPY --from=build /app ./

EXPOSE 5005
USER root
ENTRYPOINT ["dotnet", "BldIt.BuildWorker.Api.dll"]