<h1 align="center">🏠 HomeBalance API</h1>

<div align="center">
  <img src="https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Entity%20Framework-0078D7?style=for-the-badge&logo=.net&logoColor=white" alt="Entity Framework" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/Clean%20Architecture-FF9900?style=for-the-badge&logo=architecture&logoColor=white" alt="Clean Architecture" />
  <img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=JSON%20web%20tokens&logoColor=white" alt="JWT" />
</div>

<br/>

<p align="center">
  <b>ASP.NET Core Web API with Clean Architecture, JWT authentication, Repository/Service patterns, and EF Core.</b><br/>
  A high-performance RESTful API designed for roommates and shared living spaces to automate expense and debt tracking.
</p>

---

## 🎯 Project Goal

Aims to eliminate the complex calculation processes such as *"Who paid for what?"* and *"Who owes how much to whom?"* experienced in shared homes or groups. Thanks to the advanced **Balance Engine**, it analyzes multiple and complex money transfers and extracts the simplest payment plan.

## 📐 Architecture & Design Patterns

This project strictly adheres to **Clean Architecture** principles to maximize code maintainability, independence, and testability.

### Architecture Flow

```text
API → Application (Services/DTOs) → Domain (Entities) ← Infrastructure (EF Core/Repositories)
```

1.  **Domain Layer:** Core Entities and interfaces (No dependencies on external libraries).
2.  **Application Layer:** Business Logic, DTOs, Service Interfaces, and Validation processes.
3.  **Infrastructure Layer:** Database connections, Repository Pattern implementation, EF Core configurations, and SQL Server operations.
4.  **API Layer:** Controllers handling HTTP requests, JWT Authentication, Dependency Injection, and Swagger configuration.

## ✨ Key Features

*   🔒 **JWT Authentication & Authorization:** Secure login system and endpoint protection using `[Authorize]`.
*   🛡️ **Secure API Endpoints:** Implemented secure API endpoints with JWT Bearer authentication and Swagger integration.
*   🔐 **Secure Password Storage:** Implementation of **BCrypt password hashing** for enhanced security.
*   📦 **Data Transfer Objects (DTOs):** Secure, controlled data flow with DTO-based responses preventing over-posting and exposing sensitive data.
*   ⚡ **Asynchronous Operations:** Fully **Async EF Core** implementation for high-performance database interactions.
*   👥 **User & Group Management:** Users can be created and participate in multiple shared groups.
*   💸 **Expense Tracking:** Group-specific expenses can be recorded, and payer details are tracked.
*   ⚖️ **Smart Debt Calculation:** Resolves complex debt cycles and cleanly calculates exactly who needs to pay how much to whom.

## 🛠️ Technologies Used

*   **Platform:** ASP.NET Core Web API (.NET 8)
*   **Authentication:** JSON Web Tokens (JWT), BCrypt
*   **ORM:** Entity Framework Core (Async)
*   **Database:** Microsoft SQL Server
*   **Documentation:** Swagger / OpenAPI
*   **Design Patterns:** Clean Architecture, Repository Pattern, Service Pattern

---

## 🚀 Getting Started

Follow these steps to run the project locally. The repository is kept clean and maintained with meaningful commit messages.

### 1. Clone the Repository
```bash
git clone https://github.com/MerveAkdeniz/HomeBalance.API.git
cd HomeBalance.API
```

### 2. Configuration (`appsettings.json`)
Open the `appsettings.json` file in the API layer and configure your SQL Server connection string and JWT settings:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=HomeBalanceDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "Your_Super_Secret_Key_Here_Make_It_Long_Enough!",
    "Issuer": "HomeBalanceAPI",
    "Audience": "HomeBalanceAPI",
    "DurationInMinutes": 60
  }
}
```

### 3. Run Migrations & Update Database
Apply the Entity Framework migrations to create your database schema:
```bash
dotnet ef database update --project HomeBalance.Infrastructure --startup-project HomeBalance.API
```
*(Or use `Update-Database` in Package Manager Console)*

### 4. Run the Application
```bash
dotnet run --project HomeBalance.API
```
Once running, navigate to the interactive API documentation at:
👉 `https://localhost:<port>/swagger`

---

## 🔌 Example Requests

### 1. Login (Authenticate & Get Token)
**`POST /api/Auth/Login`**

**Request:**
```json
{
  "email": "merve@gmail.com",
  "password": "SecurePassword123!"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2026-05-04T18:40:05Z"
}
```

### 2. Get Users (Secured Endpoint)
**`GET /api/Users`**

*Requires the JWT token to be passed in the `Authorization` header.*

**Headers:**
```http
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

**Response (DTO-based):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "Merve",
  "email": "merve@gmail.com",
  "joinedGroups": [
    {
      "groupId": "1b2c3d4e-5f6a-7b8c-9d0e-1f2a3b4c5d6e",
      "groupName": "Roommates"
    }
  ]
}
```

---

## 👩‍💻 Developer

**Merve Akdeniz**  
*Information Systems Engineer*  
[LinkedIn](https://www.linkedin.com/in/merve-akdeniz-329409214/) | [GitHub](https://github.com/MerveAkdeniz)

---
*This project is built to demonstrate scalable solutions to real-world problems using modern software development standards, clean architecture, and best practices.*
