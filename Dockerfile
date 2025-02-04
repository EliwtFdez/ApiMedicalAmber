# Usa la imagen base de .NET SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia los archivos del proyecto y restaura las dependencias
COPY ["ApiMedicalAmber.csproj", "./"]
RUN dotnet restore

# Copia el resto de los archivos del proyecto
COPY . .

# Compila la aplicación
RUN dotnet publish -c Release -o /app/publish

# Usa la imagen base de .NET Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copia los archivos publicados desde la etapa de compilación
COPY --from=build /app/publish .

# Expone el puerto en el que la aplicación escuchará
EXPOSE 80

# Define el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "ApiMedicalAmber.dll"]