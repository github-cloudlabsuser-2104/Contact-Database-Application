# Use the official Microsoft ASP.NET image for .NET Framework and IIS
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS base
WORKDIR /inetpub/wwwroot

# Copy the application files from your project folder
COPY . .

# Expose the port used by IIS Express (adjust if necessary)
EXPOSE 44300

# Set the entry point to run IIS Express with your application
ENTRYPOINT ["C:\\Program Files (x86)\\IIS Express\\iisexpress.exe", "/config:C:\\.vs\\config\\applicationhost.config", "/site:CRUD application 2"]
