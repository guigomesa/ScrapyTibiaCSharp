FROM mcr.microsoft.com/dotnet/runtime:6.0.1-alpine3.14-amd64 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0.101-focal-amd64 AS build
WORKDIR /src
COPY ["TibiaApi/TibiaApi.Web.csproj", "TibiaApi/"]
COPY ["Tibia.Comum/TibiaApi.Comum.csproj", "Tibia.Comum/"]
COPY ["TibiaApi.Service/TibiaApi.Service.csproj", "TibiaApi.Service/"]
COPY ["TibiaApi.Repository/TibiaApi.Repository.csproj", "TibiaApi.Repository/"]
COPY ["TibiaApi.Database/TibiaApi.Database.csproj", "TibiaApi.Database/"]
COPY ["TibiaApi.BotWeb/TibiaApi.BotWeb.csproj", "TibiaApi.BotWeb/"]
RUN dotnet restore "TibiaApi/TibiaApi.Web.csproj"
COPY . .
WORKDIR "/src/TibiaApi"
RUN dotnet build "TibiaApi.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TibiaApi.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TibiaApi.Web.dll"]