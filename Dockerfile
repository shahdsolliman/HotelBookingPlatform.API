# ----- Build Stage -----
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore, Build, Publish
RUN dotnet restore HotelBookingPlatform.APIs/HotelBookingPlatform.APIs.csproj
RUN dotnet build HotelBookingPlatform.APIs/HotelBookingPlatform.APIs.csproj -c Release -o /app/build
RUN dotnet publish HotelBookingPlatform.APIs/HotelBookingPlatform.APIs.csproj -c Release -o /app/publish


# ----- Runtime Stage -----
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# ✅ مهم لـ Railway: خلي الـ app يسمع على البورت اللي بيدهولك Railway
ENV ASPNETCORE_URLS=http://+:${PORT}

# Copy the published output
COPY --from=build /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "HotelBookingPlatform.APIs.dll"]
