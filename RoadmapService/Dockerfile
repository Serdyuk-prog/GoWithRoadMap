FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RoadmapService.csproj", "./"]
RUN dotnet restore "RoadmapService.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RoadmapService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoadmapService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoadmapService.dll"]
