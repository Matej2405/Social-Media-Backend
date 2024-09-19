# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy and restore dependencies
COPY facebook-clone/*.csproj ./facebook-clone/
WORKDIR /app/facebook-clone
RUN dotnet restore

# Copy the rest of the application and publish
COPY facebook-clone/. .
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/facebook-clone/out .

# Expose port 80
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# Set the entry point
ENTRYPOINT ["dotnet", "facebook-clone.dll"]