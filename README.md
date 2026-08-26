הנה קובץ ה-`README.md` המלא והמעודכן, כולל הציון המפורש של שפת **C#** במקום הנכון (גם בפסקה הראשונה וגם בטכנולוגיות). הכל נמצא בתיבת קוד אחת לנוחות העתקה:

# Project Manager Web API

A robust Web API built with **C#** and **ASP.NET Core 8** for managing users, projects, tasks, and task statuses. Developed as a capstone project for the ASP.NET Core course.

---

## Features

- **Full CRUD Operations**: Complete resource management for Users, Projects, Tasks, and Statuses.
- **Relational Data Mapping**: Object-relational modeling using Entity Framework Core with automatic cascade delete and business constraint validations.
- **DTO Mapping**: Clean separation of concerns and data transfer object mapping using **AutoMapper**.
- **Global Error Handling**: Centralized exception management middleware.
- **Interactive Documentation**: Integrated **Swagger / OpenAPI** support for live endpoint testing in the development environment.

---

## Tech Stack

- **Language**: C# 12
- **Backend**: ASP.NET Core 8 Web API
- **ORM**: Entity Framework Core 8 with Pomelo MySQL Provider
- **Mapping**: AutoMapper 12
- **Documentation**: Swashbuckle (Swagger)
- **Database**: MySQL 8.0

---

## Prerequisites

Ensure you have the following installed on your local machine:
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (includes C# compiler and runtime)
- [MySQL 8.0](https://dev.mysql.com/downloads/mysql/) (running locally or accessible via cloud)

---

## Getting Started

### 1. Clone the Repository
```bash
git clone [https://github.com/Rivka-Weinstock/Project-Manager.git](https://github.com/Rivka-Weinstock/Project-Manager.git)
cd Project-Manager

```

### 2. Configure the Connection String

Locate `Api/appsettings.json` and update the MySQL connection string with your database credentials under `DefaultConnection`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=ProjectManagement;User=root;Password=YOUR_PASSWORD;"
}

```

> **Tip:** You can create an `Api/appsettings.Development.json` file to store your local credentials securely. (This file is ignored by Git).

---

### 3. Set Up the Database

Choose **one** of the following methods to initialize your database:

#### Option A: SQL Script (Recommended for submission)

Run the script using the MySQL CLI:

```bash
mysql -u root -p < DB/CreateDatabase.sql

```

Alternatively, open `DB/CreateDatabase.sql` in **MySQL Workbench** or your preferred database tool and execute it. This script sets up the tables, initial seed/demo data, and EF Core migration history.

#### Option B: Entity Framework Migrations

If you prefer EF Core to build the database from code migrations, run:

```bash
dotnet ef database update --project DataAccess --startup-project Api

```

---

### 4. Run the Application

Execute the API project:

```bash
dotnet run --project Api

```

* **Base API URL:** `http://localhost:5030`
* **Swagger UI (Development):** `http://localhost:5030/swagger`

---

## Architecture & Layering

The project follows a clean **N-Tier Architecture** pattern:

```text
Project-Manager/
├── Api/                 # Web API (Controllers, Middleware, Swagger, AutoMapper Profile)
├── BusinessLogic/       # Services (Business logic implementation, DTO ↔ Entity mapping)
├── DataAccess/          # Repositories, AppDbContext, EF Core Migrations
├── Models/              # Shared Domain Entities and DTOs
├── DB/                  # SQL Database initialization script
└── ProjectManagement.sln

```

### Request Flow:

```text
Client ──> Controller ──> Service ──> Repository ──> DbContext ──> MySQL Database

```

* **Api**: Handles incoming HTTP requests, model validation, and response status codes.
* **BusinessLogic**: Implements application workflows, orchestration, and AutoMapper configurations.
* **DataAccess**: Encapsulates database communication using the Repository Pattern.
* **Models**: Defines shared core entities and DTOs without dependencies on higher layers.

---

## Entity Relationships

```text
User (1) ──< (N) Project (1) ──< (N) TaskItem (N) >── (1) Status

```

* **User → Projects**: One-to-Many
* **Project → Tasks**: One-to-Many (Deleting a project cascades and deletes its tasks)
* **Status → Tasks**: One-to-Many (Statuses cannot be deleted while assigned tasks exist)

---

## API Endpoints

| Resource | Base Route | Supported Operations |
| --- | --- | --- |
| **Users** | `/api/users` | GET (All / By ID), POST, PUT, DELETE |
| **Projects** | `/api/projects` | GET (All / By ID), POST, PUT, DELETE |
| **Tasks** | `/api/tasks` | GET (All / By ID), POST, PUT, DELETE |
| **Statuses** | `/api/statuses` | GET (All / By ID), POST, PUT, DELETE |

---

## API Testing with Swagger

1. Run the project: `dotnet run --project Api`
2. Open your browser at: `http://localhost:5030/swagger`
3. Expand any endpoint, click **Try it out**, fill in the required parameters, and click **Execute**.

### Expected HTTP Status Codes:

* `200 OK`: Successful GET request
* `201 Created`: Successful POST request
* `204 No Content`: Successful PUT or DELETE update
* `400 Bad Request`: Input validation error
* `404 Not Found`: Requested resource does not exist

```

```
