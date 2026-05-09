# Quickstart: Core Task Management

## Prerequisites
- .NET 8 SDK
- Node.js (v18+)
- npm

## Backend (ASP.NET Core)
1. `cd backend`
2. `dotnet restore`
3. `dotnet run` (Runs on http://localhost:5000)

## Frontend (React)
1. `cd frontend`
2. `npm install`
3. `npm start` (Runs on http://localhost:3000)

## Design Patterns implemented
- **Command**: See `backend/src/Domain/Commands`
- **Strategy**: See `backend/src/Domain/Strategies`
- **Factory**: See `backend/src/Domain/Factories`
- **MVC**: Controller in `backend/src/API`, View in `frontend/src/components`
