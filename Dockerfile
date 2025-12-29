FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "PortfolioApi.csproj"
RUN dotnet publish "PortfolioApi.csproj" -c Release -o /app/out

FROM base AS final
WORKDIR /app
COPY --from=build /app/out .
# Verify the DLL exists
RUN ls -la && \
    if [ ! -f "PortfolioApi.dll" ]; then \
    echo "ERROR: PortfolioApi.dll not found!" && exit 1; \
    fi
ENTRYPOINT ["dotnet", "PortfolioApi.dll"]