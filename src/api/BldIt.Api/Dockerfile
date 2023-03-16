FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

ARG NUGET_FEED_URL
ARG NUGET_FEED_USERNAME
ARG NUGET_FEED_PASSWORD

WORKDIR /src
COPY . .
COPY ./NuGet.Config ./

RUN dotnet restore "BldIt.Api/BldIt.Api.csproj" --disable-parallel --configfile ./NuGet.Config
RUN dotnet publish "BldIt.Api/BldIt.Api.csproj" -c Release -o /app --no-restore

RUN rm ./NuGet.Config

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS runtime
WORKDIR /app

COPY --from=build /app ./

EXPOSE 80
ENTRYPOINT ["dotnet", "BldIt.Api.dll"]