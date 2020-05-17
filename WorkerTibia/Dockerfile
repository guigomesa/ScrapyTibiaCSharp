FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
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