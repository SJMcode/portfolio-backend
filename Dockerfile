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
RUN ls -la PortfolioApi.dll
EXPOSE 3000
ENV ASPNETCORE_URLS=http://+:3000
ENTRYPOINT ["dotnet", "PortfolioApi.dll"]