# Implementation Plan: Core Task Management

**Branch**: `002-todo-core-crud` | **Date**: 2026-05-09 | **Spec**: [specs/002-todo-core-crud/spec.md](specs/002-todo-core-crud/spec.md)
**Input**: Core CRUD for TODO-list with tags, priority, and reminders. Strictly in-memory.

## Summary

This feature implements a high-quality TODO-list system using ASP.NET Core for the backend and React for the frontend. The architecture is strictly MVC, enhanced with GoF design patterns (Command, Strategy, Factory, Abstract Factory) and constrained by SOLID and Object Calisthenics. Data is managed purely in-memory.

## Technical Context

**Language/Version**: C# 12 / JavaScript (ES2022)  
**Primary Dependencies**: ASP.NET Core 8.0, React 18, React Hooks  
**Storage**: In-memory (Domain-agnostic Repository)  
**Testing**: xUnit (Backend), Jest + React Testing Library (Frontend)  
**Target Platform**: Web Browser / Localhost
**Project Type**: web-service (API) + web-app (SPA)  
**Performance Goals**: <50ms for list sorting, <5s for task creation flow  
**Constraints**: SOLID, Object Calisthenics (strict C#), MVC, No Database  
**Scale/Scope**: Single-user, session-based in-memory state

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

- [x] **SOLID & Object Calisthenics**: C# backend must wrap all primitives and have zero 'else' blocks.
- [x] **MVC Pattern Separation**: ASP.NET Controllers for logic, React for View.
- [x] **Testing Discipline**: Unit tests required for all Patterns (Command/Strategy).
- [x] **Persistence-less Domain**: Using `ITaskRepository` with an `InMemoryTaskRepository` implementation.
- [x] **Tech Stack**: C#/.NET and React confirmed.
- [x] **Simple & Clear UX**: Mandated single-page interface with RESTful routes.

## Project Structure

### Documentation (this feature)

```text
specs/002-todo-core-crud/
├── plan.md              # This file
├── research.md          # Phase 0 output
├── data-model.md        # Phase 1 output
├── quickstart.md        # Phase 1 output
├── contracts/           # Phase 1 output
│   └── api-v1.md
└── tasks.md             # Phase 2 output
```

### Source Code (repository root)

```text
backend/
├── src/
│   ├── Domain/
│   │   ├── Entities/    # Wrapped primitives, OC compliant
│   │   ├── Commands/    # Command Pattern (Add, Remove, Update)
│   │   ├── Strategies/  # Strategy Pattern (SortByPriority)
│   │   └── Factories/   # Abstract Factory (Entity instantiation)
│   ├── Infrastructure/
│   │   └── Persistence/ # InMemory Repository
│   └── API/             # ASP.NET Controllers (RESTful)
└── tests/

frontend/
├── src/
│   ├── components/      # React Views (Single Page)
│   ├── hooks/           # Controller/State logic
│   └── services/        # API Client (RESTful)
└── tests/
```

**Structure Decision**: Option 2: Web application (frontend + backend).

## Complexity Tracking

| Violation | Why Needed | Simpler Alternative Rejected Because |
|-----------|------------|-------------------------------------|
| Pattern Overload | Required for study material & v1.2.0 | Simpler procedural code violates v1.2.0 mandates. |
| Wrapped Primitives| Object Calisthenics rule #3 | Bare strings/ints lead to primitive obsession. |
