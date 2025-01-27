# Usa la imagen oficial de .NET para compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de proyecto y restaura dependencias
COPY *.sln ./
COPY legacy_api/*.csproj ./legacy_api/
RUN dotnet restore legacy_api/legacy_api.csproj

# Copia el resto de los archivos y construye la aplicación
COPY legacy_api/. ./legacy_api/
WORKDIR /src/legacy_api
RUN dotnet publish -c Release -o /app/publish

# Usa una imagen ligera para la ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Expone el puerto 80 para la aplicación
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "legacy_api.dll"]
