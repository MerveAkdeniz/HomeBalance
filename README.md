<h1 align="center">🏠 HomeBalance API</h1>

<div align="center">
  <img src="https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Entity%20Framework-0078D7?style=for-the-badge&logo=.net&logoColor=white" alt="Entity Framework" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/Clean%20Architecture-FF9900?style=for-the-badge&logo=architecture&logoColor=white" alt="Clean Architecture" />
</div>

<br/>

<p align="center">
  <b>A high-performance RESTful API designed for roommates and shared living spaces to automate expense and debt tracking.</b>
</p>

---

## 🎯 Project Goal

Aims to eliminate the complex calculation processes such as *"Who paid for what?"* and *"Who owes how much to whom?"* experienced in shared homes or groups. Thanks to the advanced **Balance Engine**, it analyzes multiple and complex money transfers and extracts the simplest payment plan.

## ✨ Key Features

*   👥 **User & Group Management:** Users can be created and participate in multiple shared groups.
*   💸 **Expense Tracking:** Group-specific expenses can be recorded, and who made the expense can be tracked.
*   ⚖️ **Smart Debt Calculation (Balance Engine):** Resolves complex debt cycles and clearly calculates exactly who needs to pay how much to whom.
*   🛒 **Shared Needs List:** Easy management of home needs and shopping lists (ShoppingItem).
*   🛡️ **Data Security & Validation:** Secure, controlled data flow with DTOs (Data Transfer Objects) and Data Annotations/Validation.
*   📖 **Automated Documentation:** Interactive documentation and testing capabilities for all API endpoints with Swagger (OpenAPI) integration.

## 📐 Architecture & Design Patterns

This project was developed in 4 main layers, strictly adhering to **Clean Architecture** principles to maximize code maintainability, independence, and testability:

1.  **Domain Layer:** The heart of the project. Core Entities and interfaces (No dependencies on external libraries).
2.  **Application Layer:** Business Logic, DTOs, and Validation processes.
3.  **Infrastructure Layer:** Database connections, Entity Framework Core configurations, database integration, and SQL Server operations.
4.  **API Layer:** Controllers handling incoming HTTP requests, Dependency Injection setups, and Swagger configuration.

## 🛠️ Technologies Used

*   **Platform:** ASP.NET Core Web API (.NET 8)
*   **ORM:** Entity Framework Core
*   **Database:** Microsoft SQL Server
*   **Documentation:** Swagger / OpenAPI
*   **Architecture Approach:** Clean Architecture, N-Tier Architecture
*   **Testing:** xUnit (Ready infrastructure for optional test integrations)

---

## 🚀 Getting Started

Follow the steps below to run the project in your local environment:

### 1. Clone the Repository
```bash
git clone https://github.com/MerveAkdeniz/HomeBalance.API.git
cd HomeBalance.API
```

### 2. Configure Database Connection
Open the `appsettings.json` file in the API layer and add your SQL Server connection string appropriately:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=HomeBalanceDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Run Migrations & Create Database
Create the database via Package Manager Console (PMC) or .NET CLI:
```bash
# If using Package Manager Console:
Add-Migration InitialCreate -StartupProject HomeBalance.API
Update-Database
```

### 4. Run the Project
```bash
dotnet run --project HomeBalance.API
```
Once the project is running, navigate to `https://localhost:<port>/swagger` in your browser to test the API through the UI.

---

## 🔌 Example Endpoints

| HTTP Method | Endpoint | Description |
| :--- | :--- | :--- |
| `POST` | `/api/Users` | Creates a new user record |
| `POST` | `/api/Groups` | Creates a new home/group environment |
| `POST` | `/api/Expenses` | Adds a new expense bill to the relevant group |
| `GET` | `/api/Balances/{groupId}` | **Calculates the detailed debt status within the group (Balance Engine)** |

<details>
<summary><b>Click to View Example JSON Requests (Payloads)</b></summary>

**Create User (POST /api/Users)**
```json
{
  "name": "Merve",
  "email": "merve@gmail.com",
  "password": "123"
}
```

**Add Expense (POST /api/Expenses)**
```json
{
  "groupId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "paidByUserId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "amount": 150.00,
  "description": "Market"
}
```
</details>

---

## 👩‍💻 Developer

**Merve Akdeniz**  
*Information Systems Engineer*  
[LinkedIn](https://www.linkedin.com/in/merveakdeniz) | [GitHub](https://github.com/MerveAkdeniz)

---
*This project was developed to produce scalable solutions to real-world problems by taking modern software development standards into account.*
