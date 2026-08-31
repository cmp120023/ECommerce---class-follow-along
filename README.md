# eCommerce Web Application
This is an ASP.NET MVC application that tracks and handles products and their prices.

## Prerequisites

Before you begin, ensure you have the following installed:
* Visual Studio 2022 (v17.12 or later for .NET 10 support)
* .NET 10 SDK 
* SQL Server LocalDB (included automatically with the Visual Studio *ASP.NET

### Step 1: Clone the repository

Clone the project files to your local environment:
bash
git clone https://github.com
cd Ecommerce


### Step 2: Install required packages

The project relies on Entity Framework Core to communicate with the database. Open your terminal or the 
Package Manager Console in Visual Studio and verify that the following dependencies are restored:

powershell
# Core Entity Framework dependencies
Install-Package Microsoft.EntityFrameworkCore -Version 10.0.11
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 10.0.11

# Tooling package required for database migrations
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 10.0.11


### Step 3: Configure the database connection

The application uses SQL Server LocalDB for local development. You do not need to manually create the database. 

1. Open the appsettings.json file in the root directory.
2. Verify or add the following ConnectionStrings configuration block:

json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "AllowedHosts": "*"
}


### Step 4: Apply database migrations

Entity Framework Core tracks database changes via migrations. Execute these commands inside the Package Manager Console:

powershell
# Registers the initial table layouts based on application models
Add-Migration Initial

# Creates the local database and generates the tables
Update-Database


