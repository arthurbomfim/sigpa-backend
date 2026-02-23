FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copia todo o backend
COPY . .

# entra na pasta da API
WORKDIR /src/SIGPA_Backend.API


RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SIGPA_Backend.API.dll"]