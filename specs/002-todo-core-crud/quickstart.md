# Quickstart: Core Task Management

## Prerequisites
- .NET 8.0 SDK
- Node.js (v18+)
- npm

## Setup & Run

### Backend (ASP.NET Core)
1. `cd backend`
2. `dotnet restore`
3. `dotnet run` (Runs on http://localhost:5115)

### Frontend (React)
1. `cd frontend`
2. `npm install`
3. `npm start` (Runs on http://localhost:3000)

## Pattern Guide for Study
- **Command**: Logic for adding/removing tasks in `backend/src/Domain/Commands`.
- **Strategy**: Priority sorting implementation in `backend/src/Domain/Strategies`.
- **Factory**: Creation of complex OC-compliant entities in `backend/src/Domain/Factories`.
- **Object Calisthenics**: Check `backend/src/Domain/Entities` for wrapped primitives and minimal instance variables.
