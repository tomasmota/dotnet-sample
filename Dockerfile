FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY src/*.csproj .
RUN dotnet restore

# Copy everything else and build
COPY src/. .
WORKDIR /source
RUN dotnet publish -c release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5050
ENV ASPNETCORE_URLS=http://+:5050
ENTRYPOINT ["dotnet", "dotnet-sample.dll"]
