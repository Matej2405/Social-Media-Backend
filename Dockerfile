FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy solution + project files
COPY Solution1.sln ./
COPY SocialMediaApp.Application/SocialMediaApp.Application.csproj SocialMediaApp.Application/
COPY SocialMediaApp.Domain/SocialMediaApp.Domain.csproj SocialMediaApp.Domain/
COPY SocialMediaApp.Infrastructure/SocialMediaApp.Infrastructure.csproj SocialMediaApp.Infrastructure/
COPY SocialMediaApp.Web/SocialMediaApp.Web.csproj SocialMediaApp.Web/
COPY SocialMediaApp.Tests/SocialMediaApp.Tests.csproj SocialMediaApp.Tests/

RUN dotnet restore

# copy everything else
COPY . .
WORKDIR /src/SocialMediaApp.Web

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
USER app
COPY --from=build /app/publish .
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "SocialMediaApp.Web.dll"]
