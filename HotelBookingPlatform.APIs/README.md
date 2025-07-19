# 🏨 HotelBookingPlatform.API

A **clean-architecture based ASP.NET Core Web API** for managing hotel operations — including user authentication, hotel listings, room availability, and booking workflows.

> 🚧 Developed during my backend internship at **Prodigy InfoTech**, following a task-based, layered approach.

---

## 🚀 Features

- 🔐 JWT Authentication & Role-based Authorization  
- 🏨 Hotel & 🛏️ Room Management APIs  
- 📆 Booking System with Status Handling  
- ⚡ Redis Caching for Optimized Performance  
- 📄 Swagger UI for Interactive API Docs  
- 🧱 Global Exception Middleware & Structured Logging  
- 🧬 EF Core + Code-First Migrations  
- 🌱 Auto DB Seeding on Startup  

---

## 🧠 Architecture Overview

- **Clean Architecture** (API / Application / Core / Infrastructure)  
- **Entity Framework Core** as ORM  
- **Repository & Unit of Work Patterns**  
- **DTOs & AutoMapper** for data shaping  
- **Custom Middleware** for Exception Handling  
- **Environment-based Configuration** (`appsettings`, Azure App Settings)  

---

## 🛠️ Tech Stack

| Technology         | Purpose                          |
|--------------------|-----------------------------------|
| ASP.NET Core 8      | Web API Framework                |
| C#                 | Main Language                    |
| EF Core            | ORM & Database Access Layer      |
| SQL Server         | Main Relational Database         |
| Redis              | In-memory Caching                |
| Swagger / Swashbuckle | API Documentation             |
| Hangfire (Optional) | Background Job Scheduling        |

---

## 📁 Project Structure

```bash
HotelBookingPlatform.API/
├── Controllers/            # API endpoints
├── DTOs/                   # Data Transfer Objects
├── Extensions/             # Service & middleware extensions
├── Helpers/                # Utility classes/helpers
├── Middlewares/            # Global exception middleware
├── Program.cs              # Main entry point
├── appsettings.json        # Base configuration
├── launchSettings.json     # Dev profiles

├── Core/
│   ├── Entities/           # Domain models
│   ├── Repositories.Contract/ # Interfaces for repos
│   └── Services.Contract/     # Interfaces for services

├── Application/
│   ├── Services/           # Business logic services
│   └── Interfaces/         # Optional abstraction layer

├── Infrastructure/
│   ├── Data/               # DbContext, Migrations
│   ├── Identity/           # Identity-related context & setup
│   └── Repositories/       # Implementations of repositories
```

---

## 🧪 How to Run Locally

1. Clone the repo  
   ```bash
   git clone https://github.com/yourusername/HotelBookingPlatform.API.git
   cd HotelBookingPlatform.API
   ```

2. Set up your local SQL Server with two databases:
   - `HotelAuthDb`
   - `HotelBusinessDb`

3. Update `appsettings.json` with your local connection strings.

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open Swagger UI at:  
   `https://localhost:<port>/swagger`

---

## 🚀 Deployment Notes

- ✅ Ready to deploy on **Azure App Service**  
- 🔁 Supports **Azure SQL** + **App Settings**  
- 🧪 Environment switching supported via `ASPNETCORE_ENVIRONMENT`

---

## 🙋‍♀️ About Me

**Shahd Soliman**  
Backend Developer | ASP.NET Core Enthusiast  
[LinkedIn Profile](https://www.linkedin.com/in/yourprofile)

---

## 📜 License

This project is licensed under the MIT License. See `LICENSE` file for details.
