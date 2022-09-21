#See https://aka.ms/planoContainerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RentBizu.Locador.API/RentBizu.Locador.API.csproj", "RentBizu.Locador.API/"]
RUN dotnet restore "RentBizu.Locador.API/RentBizu.Locador.API.csproj"
COPY . .
WORKDIR "/src/RentBizu.Locador.API"
RUN dotnet build "RentBizu.Locador.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentBizu.Locador.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentBizu.Locador.API.dll"]