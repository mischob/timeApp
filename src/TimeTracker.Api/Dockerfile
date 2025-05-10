FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/TimeTracker.Api/TimeTracker.Api.csproj", "src/TimeTracker.Api/"]
COPY ["src/TimeTracker.Shared/TimeTracker.Shared.csproj", "src/TimeTracker.Shared/"]
RUN dotnet restore "src/TimeTracker.Api/TimeTracker.Api.csproj"
COPY . .
WORKDIR "/src/src/TimeTracker.Api"
RUN dotnet build "TimeTracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeTracker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeTracker.Api.dll"] 