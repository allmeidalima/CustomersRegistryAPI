#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClientRegistry/CustomerRegistry.API.csproj", "ClientRegistry/"]
COPY ["Client.DBO/Customer.DBO.csproj", "Client.DBO/"]
COPY ["Common/Customer.Common.csproj", "Common/"]
RUN dotnet restore "ClientRegistry/CustomerRegistry.API.csproj"
COPY . .
WORKDIR "/src/ClientRegistry"
RUN dotnet build "CustomerRegistry.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerRegistry.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerRegistry.API.dll"]