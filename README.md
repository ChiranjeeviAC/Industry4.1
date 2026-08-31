# Industry 4.0 Operations Management Platform

A manufacturing operations management REST API built with **C#, ASP.NET
Core Web API, Entity Framework Core, and SQL Server** for managing
users, machines, shifts, production entries, and production analytics.

## Overview

The **Industry 4.0 Operations Management Platform** is a backend
application designed to support manufacturing-floor operations and
production monitoring.

The platform manages core manufacturing entities such as
**operators/users, machines, shifts, and production entries**, while
providing analytical APIs for production performance across machines,
operators, shifts, cycles, and time periods.

The project was developed incrementally. The initial implementation
focused on building the core functionality, with business logic
initially handled within controllers. The application was subsequently
refactored into a **layered architecture** to improve separation of
concerns, maintainability, and code organization.

## Key Features

### User & Operator Management

-   User/operator creation and management
-   User login and authentication
-   Update user information
-   Activate and deactivate users
-   Delete users
-   Filter users by role
-   Retrieve user status
-   Retrieve total number of users
-   Retrieve machine information associated with a user

### Machine Management

-   Add machines
-   Retrieve all machines
-   Retrieve machine by ID
-   Retrieve active machines
-   Activate and deactivate machines
-   Delete machines
-   Retrieve machine status
-   Associate production entries with specific machines

### Shift Management

-   Create shifts
-   Retrieve all shifts
-   Retrieve shift by ID
-   Update shift details
-   Update shift name
-   Update shift start time
-   Update shift end time
-   Delete shifts
-   Generate shift-based production summaries

### Production Management

-   Create production entries using Job IDs
-   Retrieve production entries
-   Retrieve production by Shift ID
-   Retrieve production by Production Entry ID
-   Delete production entries by Job ID
-   Retrieve production for a specific machine and operator
-   Retrieve production over a specified date/time range
-   Track OK parts, NC parts, and total production
-   Retrieve production per machine/operator per cycle

### Production Analytics

-   Production analysis APIs
-   Production totals for specific machines and dates
-   Production totals for specific date/time ranges
-   Full shift production reports
-   Machine production performance analysis
-   Top operator performance analysis
-   Shift-based production summaries
-   Role-based production summaries
-   Production comparison across machines, operators, and shifts

### Authentication & Security

-   JWT-based authentication
-   Login API
-   Password reset functionality
-   Forgot-password flow using a temporary key
-   Authentication logic separated into dedicated services and
    interfaces

## Architecture

The final implementation follows a **layered architecture** that
separates API responsibilities, business logic, abstractions, and data
access.

``` text
Client
   |
   v
Controllers
   |
   v
Services
   |
   v
Data Access
   |
   v
Entity Framework Core
   |
   v
SQL Server
```

### Project Structure

``` text
Industry4.1/
│
├── Controllers/
├── DTOs/
├── Data/
├── Interfaces/
├── Migrations/
├── Model/
├── Services/
├── Properties/
├── Program.cs
├── appsettings.json
└── Industry4.1.csproj
```

## Technology Stack

  Technology              Purpose
  ----------------------- --------------------------------
  C#                      Primary programming language
  ASP.NET Core Web API    REST API development
  Entity Framework Core   ORM and database access
  SQL Server              Relational database
  JWT                     Authentication
  LINQ                    Data querying and processing
  Dependency Injection    Dependency management
  DTOs                    API request/response contracts
  Layered Architecture    Separation of responsibilities
  Code-First Migrations   Database schema management

## Core Manufacturing Flow

``` text
User / Operator
       |
       v
    Machine
       |
       v
     Shift
       |
       v
Production Entry
       |
       v
Production Analytics
```

Production can be analyzed using:

-   Machine
-   Operator/User
-   Shift
-   Job
-   Production cycle
-   Date
-   Date/time range
-   OK parts
-   NC parts
-   Total production

## Architecture Evolution

The project was developed in two major stages.

### Initial Development

The first stage focused on implementing and validating the core
manufacturing APIs:

-   User management
-   Machine management
-   Shift management
-   Production entry management
-   Production reporting
-   Production analytics
-   Status management

### Architectural Refactoring

The later stage introduced a more maintainable application structure:

-   Controllers for HTTP/API handling
-   Services for business logic
-   Interfaces for abstractions
-   DTOs for API contracts
-   Dedicated data-access components
-   Entity Framework Core migrations
-   JWT authentication service
-   Dependency Injection

This evolution demonstrates the transition from an initial functional
implementation to a more structured backend architecture.

## API Capabilities

``` text
Authentication
├── Login
├── JWT Authentication
├── Reset Password
└── Forgot Password

Users
├── Create
├── Update
├── Delete
├── Activate / Deactivate
├── Filter by Role
└── Get Status

Machines
├── Create
├── Get All
├── Get By ID
├── Get Active Machines
├── Activate / Deactivate
└── Delete

Shifts
├── Create
├── Get All
├── Get By ID
├── Update
├── Update Start / End Time
└── Delete

Production
├── Create Production Entry
├── Get Production
├── Delete Production
├── Machine / Operator Production
└── Date / Time Based Production

Analytics
├── Production Totals
├── Shift Reports
├── Machine Performance
├── Operator Performance
├── Shift-Based Summary
└── Role-Based Summary
```

## Getting Started

### Prerequisites

-   .NET SDK
-   SQL Server
-   Visual Studio or another .NET-compatible IDE

### Clone the Repository

``` bash
git clone https://github.com/ChiranjeeviAC/Industry-4.0-Operations-Management-Platform.git
cd Industry-4.0-Operations-Management-Platform
```

### Configure the Database

Update the SQL Server connection string in:

``` text
appsettings.json
```

Use your local SQL Server configuration and database credentials.

### Restore Dependencies

``` bash
dotnet restore
```

### Build

``` bash
dotnet build
```

### Apply Entity Framework Core Migrations

``` bash
dotnet ef database update
```

If the Entity Framework Core CLI is not installed:

``` bash
dotnet tool install --global dotnet-ef
```

### Run the API

``` bash
dotnet run
```

The project also contains an `.http` file that can be used to test API
endpoints.

## Engineering Practices

The project demonstrates practical backend engineering concepts
including:

-   RESTful API design
-   Layered architecture
-   Separation of concerns
-   Dependency Injection
-   Interface-based programming
-   DTO-based API contracts
-   Entity Framework Core
-   Code-First database development
-   LINQ queries
-   JWT authentication
-   Business-logic separation
-   API validation
-   Production analytics and reporting

## Future Improvements

Potential improvements include:

-   Swagger/OpenAPI documentation
-   Global exception-handling middleware
-   Structured logging
-   FluentValidation
-   Unit and integration testing
-   Pagination and filtering
-   Refresh-token authentication
-   Docker support
-   CI/CD pipeline
-   API versioning
-   Real-time production monitoring and dashboards

## Author

**Chiranjeevi A C**

.NET Developer \| C# \| ASP.NET Core \| Web API \| Entity Framework Core
\| SQL Server

GitHub: https://github.com/ChiranjeeviAC
