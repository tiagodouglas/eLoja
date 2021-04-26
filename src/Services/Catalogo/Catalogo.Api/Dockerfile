FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Catalogo/Catalogo.Api/Catalogo.Api.csproj", "Services/Catalogo/Catalogo.Api/"]
RUN dotnet restore "Services/Catalogo/Catalogo.Api/Catalogo.Api.csproj"
COPY . .
WORKDIR "/src/Services/Catalogo/Catalogo.Api"
RUN dotnet build "Catalogo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalogo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalogo.Api.dll"]