FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/TimeTracker.Client/TimeTracker.Client.csproj", "src/TimeTracker.Client/"]
COPY ["src/TimeTracker.Shared/TimeTracker.Shared.csproj", "src/TimeTracker.Shared/"]
RUN dotnet restore "src/TimeTracker.Client/TimeTracker.Client.csproj"
COPY . .
WORKDIR "/src/src/TimeTracker.Client"
RUN dotnet build "TimeTracker.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeTracker.Client.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY src/TimeTracker.Client/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
EXPOSE 443 