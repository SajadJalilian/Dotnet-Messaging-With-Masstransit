FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DidarMessagingTask/DidarMessagingTask.csproj", "DidarMessagingTask/"]
RUN dotnet restore "DidarMessagingTask/DidarMessagingTask.csproj"
COPY . .
WORKDIR "/src/DidarMessagingTask"
RUN dotnet build "DidarMessagingTask.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DidarMessagingTask.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DidarMessagingTask.dll"]
