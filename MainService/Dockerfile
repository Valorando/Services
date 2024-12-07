# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Базовый образ для запуска (используется в рабочей среде или при обычном запуске из VS)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Образ для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем файл решения и проект
COPY ["Services.sln", "."]
COPY ["MainService/MainService.csproj", "MainService/"]

# Восстанавливаем зависимости
RUN dotnet restore "./MainService/MainService.csproj"

# Копируем остальные файлы проекта
COPY . .

# Сборка проекта
WORKDIR "/src/MainService"
RUN dotnet build "./MainService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этап публикации
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MainService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MainService.dll"]
