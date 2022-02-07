#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ResortForecaster.Api/ResortForecaster.Api.csproj", "ResortForecaster.Api/"]
COPY ["ResortForecaster.ApiClients/ResortForecaster.ApiClients.csproj", "ResortForecaster.ApiClients/"]
COPY ["ResortForecaster.Models/ResortForecaster.Models.csproj", "ResortForecaster.Models/"]
COPY ["ResortForecaster.Enums/ResortForecaster.Enums.csproj", "ResortForecaster.Enums/"]
COPY ["ResortForecaster.GraphQL/ResortForecaster.GraphQL.csproj", "ResortForecaster.GraphQL/"]
COPY ["ResortForecaster.Repos/ResortForecaster.Repos.csproj", "ResortForecaster.Repos/"]
COPY ["ResortForecaster.Services/ResortForecaster.Services.csproj", "ResortForecaster.Services/"]
COPY ["ResortForecaster.Utilities/ResortForecaster.Utilities.csproj", "ResortForecaster.Utilities/"]
COPY ["ResortForecaster.Migrations/ResortForecaster.Migrations.csproj", "ResortForecaster.Migrations/"]
RUN dotnet restore "ResortForecaster.Api/ResortForecaster.Api.csproj"
COPY . .
WORKDIR "/src/ResortForecaster.Api"
RUN dotnet build "ResortForecaster.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResortForecaster.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME /var/opt/mssql/data/resort-forecaster-db-volume
ENTRYPOINT ["dotnet", "ResortForecaster.Api.dll"]
