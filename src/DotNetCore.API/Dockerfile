#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DotNetCore.API/DotNetCore.API.csproj", "src/DotNetCore.API/"]
COPY ["libraries/LoggerService/LoggerService.csproj", "libraries/LoggerService/"]
COPY ["libraries/Fiver.Security.Bearer.Helpers/Fiver.Security.Bearer.Helpers.csproj", "libraries/Fiver.Security.Bearer.Helpers/"]
RUN dotnet restore "src/DotNetCore.API/DotNetCore.API.csproj"
COPY . .
WORKDIR "/src/src/DotNetCore.API"
RUN dotnet build "DotNetCore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNetCore.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNetCore.API.dll"]