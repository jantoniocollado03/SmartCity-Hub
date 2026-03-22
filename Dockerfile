# Etapa 1: Construcción (SDK)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiamos los archivos de los proyectos
COPY ["SmartCity.App/SmartCity.App.csproj", "SmartCity.App/"]
COPY ["SmartCity.Core/SmartCity.Core.csproj", "SmartCity.Core/"]

# Restauramos dependencias
RUN dotnet restore "SmartCity.App/SmartCity.App.csproj"

# Copiamos todo el código fuente y publicamos
COPY . .
WORKDIR "/src/SmartCity.App"
RUN dotnet publish "SmartCity.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
WORKDIR /app
COPY --from=build /app/publish .

# Comando de inicio
ENTRYPOINT ["dotnet", "SmartCity.App.dll"]