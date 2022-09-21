#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RentBizu.Locatario.API/RentBizu.Locatario.API.csproj", "RentBizu.Locatario.API/"]
RUN dotnet restore "RentBizu.Locatario.API/RentBizu.Locatario.API.csproj"
COPY . .
WORKDIR "/src/RentBizu.Locatario.API"
RUN dotnet build "RentBizu.Locatario.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentBizu.Locatario.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentBizu.Locatario.API.dll"]