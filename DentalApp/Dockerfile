# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["DentalApp/DentalApp.Api.csproj", "DentalApp/"]
COPY ["DentalApp.Application/DentalApp.Application.csproj", "DentalApp.Application/"]
COPY ["DentalApp.Data/DentalApp.Data.csproj", "DentalApp.Data/"]
COPY ["DentalApp.Domain/DentalApp.Domain.csproj", "DentalApp.Domain/"]
COPY ["DentalApp.Infra/DentalApp.Infra.csproj", "DentalApp.Infra/"]

RUN dotnet restore "DentalApp/DentalApp.Api.csproj"

# Copy everything and build
COPY . .
WORKDIR /src/DentalApp
RUN dotnet publish "DentalApp.Api.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "DentalApp.Api.dll"]
