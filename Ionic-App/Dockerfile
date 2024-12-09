# Stage 1: Build the Angular application
FROM node:18 AS build

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install dependencies (Install Ionic CLI locally or globally)
RUN npm install -g @ionic/cli@6.20.4
RUN npm install

# Copy the application code
COPY . .

# Build the Angular app with production settings
RUN ionic build --prod

# Stage 2: Serve the built application with NGINX
FROM nginx:alpine

# Copy the built Angular app to the NGINX directory
COPY --from=build /app/www /usr/share/nginx/html

# Expose the NGINX port
EXPOSE 80

# Start NGINX
CMD ["nginx", "-g", "daemon off;"]
