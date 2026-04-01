# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy sln and csproj files for layer caching
COPY mxaddress.slnx .
COPY src/mxaddress.Api/mxaddress.Api.csproj src/mxaddress.Api/
COPY src/mxaddress.Application/mxaddress.Application.csproj src/mxaddress.Application/
COPY src/mxaddress.Domain/mxaddress.Domain.csproj src/mxaddress.Domain/
COPY src/mxaddress.Infrastructure/mxaddress.Infrastructure.csproj src/mxaddress.Infrastructure/
COPY tests/mxaddress.Tests/mxaddress.Tests.csproj tests/mxaddress.Tests/
RUN dotnet restore mxaddress.slnx

# Copy all source and publish
COPY src/ src/
COPY tests/ tests/
RUN dotnet publish src/mxaddress.Api/mxaddress.Api.csproj -c Release --no-restore -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "mxaddress.Api.dll"]
