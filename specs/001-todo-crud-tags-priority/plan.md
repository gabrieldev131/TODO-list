# Implementation Plan: Core Task Management

**Branch**: `001-todo-crud-tags-priority` | **Date**: 2026-05-09 | **Spec**: [specs/001-todo-crud-tags-priority/spec.md](specs/001-todo-crud-tags-priority/spec.md)
**Input**: Feature specification for TODO-list CRUD with tags and priority sorting.

## Summary

This feature implements the core lifecycle of a TODO-list (Create, Read, Update, Delete) using an ASP.NET Core backend and a React frontend. The implementation strictly adheres to the project's v1.1.0 Constitution, utilizing SOLID principles and Object Calisthenics. Architecture is MVC-based, incorporating the Command pattern for operations, Strategy pattern for sorting, and Factories for object instantiation. Data is managed purely in-memory.

## Technical Context

**Language/Version**: C# 12 / JavaScript (ES6+)  
**Primary Dependencies**: ASP.NET Core 8, React 18, React Hooks  
**Storage**: In-memory (Domain-agnostic Repository)  
**Testing**: xUnit (Backend), Jest/React Testing Library (Frontend)  
**Target Platform**: Cross-platform (Localhost)
**Project Type**: web-service (API) + mobile-app (React SPA)  
**Performance Goals**: <100ms for sorting/CRUD operations  
**Constraints**: SOLID, Object Calisthenics (Backend), MVC, No Database  
**Scale/Scope**: Single-user, session-based storage

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

- [x] **SOLID & Object Calisthenics**: Backend must use wrapped primitives, single dots per line, and no 'else' blocks.
- [x] **MVC Pattern Separation**: ASP.NET for Controllers/Models, React for View.
- [x] **Testing Discipline**: Mandated unit tests for Command/Strategy logic.
- [x] **Persistence-less Domain**: Using an `ITaskRepository` with an `InMemoryTaskRepository` implementation.
- [x] **Tech Stack**: C#/.NET and React confirmed.

## Project Structure

### Documentation (this feature)

```text
specs/001-todo-crud-tags-priority/
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
│   │   ├── Entities/    # Object Calisthenics: Wrapped primitives
│   │   ├── Commands/    # Command Pattern
│   │   ├── Strategies/  # Strategy Pattern
│   │   └── Factories/   # Factory/Abstract Factory
│   ├── Infrastructure/
│   │   └── Persistence/ # InMemory Repository
│   └── API/             # ASP.NET Controllers
└── tests/

frontend/
├── src/
│   ├── components/      # React Views
│   ├── hooks/           # Controller/Orchestration logic
│   └── services/        # API Clients
└── tests/
```

**Structure Decision**: Option 2: Web application (frontend + backend).

## Complexity Tracking

| Violation | Why Needed | Simpler Alternative Rejected Because |
|-----------|------------|-------------------------------------|
| Pattern Overload | Required by user prompt/Constitution | Simpler procedural code violates v1.1.0 mandates. |
