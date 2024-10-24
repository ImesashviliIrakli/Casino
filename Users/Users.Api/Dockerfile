#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Users/Users.Api/Users.Api.csproj", "Users/Users.Api/"]
COPY ["BuildingBlocks/BuildingBlocks.Applictaion/BuildingBlocks.Applictaion.csproj", "BuildingBlocks/BuildingBlocks.Applictaion/"]
COPY ["BuildingBlocks/BuildingBlocks.Domain/BuildingBlocks.Domain.csproj", "BuildingBlocks/BuildingBlocks.Domain/"]
COPY ["Users/Users.Persistence/Users.Persistence.csproj", "Users/Users.Persistence/"]
COPY ["Users/Users.Application/Users.Application.csproj", "Users/Users.Application/"]
COPY ["Users/Users.Domain/Users.Domain.csproj", "Users/Users.Domain/"]
RUN dotnet restore "./Users/Users.Api/Users.Api.csproj"
COPY . .
WORKDIR "/src/Users/Users.Api"
RUN dotnet build "./Users.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Users.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Users.Api.dll"]