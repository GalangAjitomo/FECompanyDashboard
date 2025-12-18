# Company Operations Dashboard

A full-stack web application demonstrating authentication, protected APIs, and production analytics visualization for a petrochemical production environment.

---

## Project Overview

Company Operations Dashboard provides a high-level view of petrochemical production performance, including:

- Daily ethylene production trends
- Monthly polyethylene output
- Actual vs design capacity comparison
- Product yield distribution

The system consists of a Blazor WebAssembly frontend and a .NET 10 Minimal API backend secured using JWT authentication.

---

## Architecture

- Frontend: Blazor WebAssembly (.NET 10)
- Backend: .NET 10 Minimal API
- Authentication: ASP.NET Identity + JWT
- Database: Entity Framework Core (InMemory)
- API Documentation: OpenAPI + Scalar UI

---

## Technology Stack Justification

### Frontend

- Blazor WebAssembly – SPA with full .NET integration
- MudBlazor – clean and consistent UI components
- Chart.js – flexible charting via JS interop
- JWT – stateless authentication for SPA

### Backend

- .NET 10 Minimal API – lightweight and high-performance API
- ASP.NET Identity – standard user management
- JWT Bearer Authentication – secure API access
- EF Core InMemory – simple seeded data for demo purposes
- OpenAPI – API documentation

---

## Why Scalar Instead of Swagger UI

Scalar is used instead of Swagger UI because it provides:

- A modern and clean interface
- Faster loading time
- Better usability for secured APIs
- Native OpenAPI integration

---

## Authentication Flow

1. User submits credentials via /auth/login
2. Backend validates credentials using ASP.NET Identity
3. JWT token is generated and returned
4. Frontend stores JWT in localStorage
5. JWT is attached to API requests using the Authorization header

---

## How to Run Backend

### Prerequisites

- .NET SDK 10

### Steps

```
cd BECompanyDashboard
dotnet restore
dotnet run
```

---

## Backend URLs

| Component     | URL                                     |
| ------------- | --------------------------------------- |
| Base URL      | https://localhost:44344                 |
| OpenAPI Spec  | https://localhost:44344/openapi/v1.json |
| Scalar API UI | https://localhost:44344/scalar          |

---

## How to Run Frontend

### Prerequisites

- .NET SDK 10

### Steps

```
cd FECompanyDashboard
dotnet restore
dotnet run
```

---

## Frontend URL

https://localhost:7157

---

## Default Credentials

- Username: admin
- Password: Password123!

---

## Testing Protected APIs

1. Open Scalar UI at https://localhost:44344/scalar
2. Call POST /auth/login using default credentials
3. Copy the returned JWT token
4. Add request header:
   Authorization: Bearer <JWT_TOKEN>
5. Call protected endpoints:
   - GET /production/trend/daily
   - GET /production/trend/monthly
   - GET /production/capacity
   - GET /production/yield

---

## Notes

- All data is seeded in memory for demonstration purposes
- Backend is stateless and JWT-secured
- Ready for containerization and deployment
- InMemory database can be replaced with a real database easily

---
