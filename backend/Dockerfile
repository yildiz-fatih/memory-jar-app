# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
# Copy the solution and each project’s .csproj first…
COPY MemoryJar.sln .  
COPY MemoryJar.Data/MemoryJar.Data.csproj MemoryJar.Data/
COPY MemoryJar.Business/MemoryJar.Business.csproj MemoryJar.Business/
COPY MemoryJar.API/MemoryJar.API.csproj MemoryJar.API/
# …so that `dotnet restore` only reruns when those files change.
RUN dotnet restore
# Bring in everything else and publish the API
COPY . .
WORKDIR /src/MemoryJar.API
RUN dotnet publish -c Release -o /app

# --- Runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim AS runtime
WORKDIR /app
# Copy only the published output from the build stage
COPY --from=build /app .
# The app just needs the DLL at runtime
ENTRYPOINT ["dotnet", "MemoryJar.API.dll"]
