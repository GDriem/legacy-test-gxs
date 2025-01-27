# Usar una imagen base de .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Usar la imagen base de SDK para compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos de proyecto y restaurar las dependencias
COPY ["legacy_api/legacy_api.csproj", "legacy_api/"]
RUN dotnet restore "legacy_api/legacy_api.csproj"

# Copiar el resto del código y construir el proyecto
COPY . .
WORKDIR "/src/legacy_api"
RUN dotnet build "legacy_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "legacy_api.csproj" -c Release -o /app/publish

# Definir la etapa de ejecución
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "legacy_api.dll"]
