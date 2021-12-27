FROM mcr.microsoft.com/dotnet/runtime:6.0.1-alpine3.14-amd64 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0.101-focal-amd64 AS build
WORKDIR /src
COPY ["Tibia.Comum/TibiaApi.Comum.csproj", "Tibia.Comum/"]
COPY ["TibiaApi.Service/TibiaApi.Service.csproj", "TibiaApi.Service/"]
COPY ["TibiaApi.Repository/TibiaApi.Repository.csproj", "TibiaApi.Repository/"]
COPY ["TibiaApi.Database/TibiaApi.Database.csproj", "TibiaApi.Database/"]
COPY ["TibiaApi.BotWeb/TibiaApi.BotWeb.csproj", "TibiaApi.BotWeb/"]
COPY ["WorkerTibia/WorkerTibia.csproj", "WorkerTibia/"]
RUN dotnet restore "WorkerTibia/WorkerTibia.csproj"
COPY . .
WORKDIR "/src/WorkerTibia"
RUN dotnet build "WorkerTibia.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkerTibia.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerTibia.dll"]