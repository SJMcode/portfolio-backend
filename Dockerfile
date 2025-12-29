FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["PortfolioApi.csproj", "./"]
RUN dotnet restore "PortfolioApi.csproj"
COPY . .
RUN dotnet build "PortfolioApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortfolioApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set to listen on port 3000 to match Railway's setting
ENV ASPNETCORE_URLS=http://+:3000

ENTRYPOINT ["dotnet", "PortfolioApi.dll"]