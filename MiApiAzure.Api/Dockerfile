# Etapa 1: Build
# Usamos la imagen oficial del SDK de .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos los archivos de proyecto y restauramos dependencias
COPY MiApiAzure.Api/MiApiAzure.Api.csproj MiApiAzure.Api/
RUN dotnet restore MiApiAzure.Api/MiApiAzure.Api.csproj

# Copiamos el resto del código fuente y construimos la app
COPY . .
WORKDIR "/src/MiApiAzure.Api"
RUN dotnet build "MiApiAzure.Api.csproj" -c Release -o /app/build

# Etapa 2: Publish
FROM build AS publish
RUN dotnet publish "MiApiAzure.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: Final
# Usamos la imagen ligera de ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# App Service buscará el puerto 8080 por defecto si no se especifica.
# Es una buena práctica exponerlo explícitamente.
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Punto de entrada
ENTRYPOINT ["dotnet", "MiApiAzure.Api.dll"]