#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["VehicleFleetManagement.Api/VehicleFleetManagement.Api.csproj", "VehicleFleetManagement.Api/"]
COPY ["VehicleFleetManagement.Application/VehicleFleetManagement.Application.csproj", "VehicleFleetManagement.Application/"]
COPY ["VehicleFleetManagement.Domain/VehicleFleetManagement.Domain.csproj", "VehicleFleetManagement.Domain/"]
COPY ["VehicleFleetManagement.Infrastructure/VehicleFleetManagement.Infrastructure.csproj", "VehicleFleetManagement.Infrastructure/"]
COPY ["VehicleFleetManagement.Tests/VehicleFleetManagement.Tests.csproj", "VehicleFleetManagement.Tests/"]

RUN dotnet restore "VehicleFleetManagement.Api/VehicleFleetManagement.Api.csproj"
RUN dotnet restore "VehicleFleetManagement.Application/VehicleFleetManagement.Application.csproj"
RUN dotnet restore "VehicleFleetManagement.Domain/VehicleFleetManagement.Domain.csproj"
RUN dotnet restore "VehicleFleetManagement.Infrastructure/VehicleFleetManagement.Infrastructure.csproj"
RUN dotnet restore "VehicleFleetManagement.Tests/VehicleFleetManagement.Tests.csproj"

COPY . .
WORKDIR "/src/VehicleFleetManagement.Api"
RUN dotnet build "VehicleFleetManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehicleFleetManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleFleetManagement.Api.dll"]