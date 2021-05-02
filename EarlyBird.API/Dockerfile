#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EarlyBird.API/EarlyBird.API.csproj", "EarlyBird.API/"]
COPY ["EarlyBird.BusinessLogic/EarlyBird.BusinessLogic.csproj", "EarlyBird.BusinessLogic/"]
COPY ["EarlyBird.DataAccess/EarlyBird.DataAccess.csproj", "EarlyBird.DataAccess/"]
RUN dotnet restore "EarlyBird.API/EarlyBird.API.csproj"
COPY . .
WORKDIR "/src/EarlyBird.API"
RUN dotnet build "EarlyBird.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EarlyBird.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "EarlyBird.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApi.dll
