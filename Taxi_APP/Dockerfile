# Stage 1: Build the application using the .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY Taxi_APP/Taxi_APP.csproj ./
RUN dotnet restore

# Copy the rest of the application files and build
COPY . .
RUN dotnet publish -c Release -o /publish

# Stage 2: Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /publish .

# Expose the port the application will run on
EXPOSE 80

# Set the entry point to run the .NET Core application
ENTRYPOINT ["dotnet", "Taxi_APP.dll"]
