#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClientRegistry/ClientRegistry.API.csproj", "ClientRegistry/"]
COPY ["Client.DBO/Client.DBO.csproj", "Client.DBO/"]
COPY ["Common/Client.Common.csproj", "Common/"]
RUN dotnet restore "ClientRegistry/ClientRegistry.API.csproj"
COPY . .
WORKDIR "/src/ClientRegistry"
RUN dotnet build "ClientRegistry.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientRegistry.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientRegistry.API.dll"]