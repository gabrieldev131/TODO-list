<!--
Sync Impact Report:
- Version change: 1.2.0 → 1.3.0
- Added principles:
  - VII. Performance SLA (Mandates max 0.5s response time for all API/UI actions)
- Modified principles:
  - III. Testing Discipline (Expanded to mandate automated tests for all API endpoints)
- Added sections: None
- Removed sections: None
- Templates requiring updates:
  - plan-template.md ✅ updated
  - spec-template.md ✅ updated
  - tasks-template.md ✅ updated
- Follow-up TODOs: None
-->

# TODO-list Constitution

## Core Principles

### I. SOLID & Object Calisthenics (NON-NEGOTIABLE)
All code must adhere to SOLID principles. The Backend (C#) must strictly follow Object Calisthenics rules: 
- One level of indentation per method.
- No 'else' keyword.
- Wrap all primitives and strings.
- One dot per line.
- Don't abbreviate.
- Keep entities small (50 lines per class, 10 lines per method).
- No classes with more than two instance variables.
- No getters/setters/properties (favor behavior).

### II. MVC Pattern Separation
The application must maintain a strict Model-View-Controller architecture. 
- **Model**: Domain logic and state management (including Tasks and Reminders), decoupled from external dependencies.
- **View**: React-based UI components focusing on presentation and user interaction.
- **Controller**: Orchestration layer (ASP.NET Controllers / React Hooks/Services) that bridges View and Model.

### III. Testing Discipline (NON-NEGOTIABLE)
Every feature MUST include corresponding tests. For the C# backend, unit tests must verify domain 
logic behavior, and ALL API endpoints must be covered by automated tests (unit or integration). 
For the React frontend, component and hook tests are required. Bug fixes must be preceded by a 
failing reproduction test.

### IV. Persistence-less Domain Logic
No external database shall be used. Data persistence is managed in-memory or via simple file storage. 
The Domain Model must be entirely ignorant of the storage mechanism, communicating only through 
well-defined repository interfaces.

### V. Tech Stack Integrity (C#/.NET & React)
- **Backend**: MUST use C# and the .NET framework.
- **Frontend**: MUST use JavaScript and the React framework.
Changes must respect the idiomatic patterns of these ecosystems (e.g., LINQ for C#, Hooks for React).

### VI. Simple & Clear UX/Routing
- **Routing**: API and Frontend routes must be clear, predictable, and simple.
- **User Interface**: The frontend must be designed for simplicity. Users should encounter zero 
friction when registering, removing, or setting reminders for tasks. Clarity precedes complexity.

### VII. Performance SLA (NON-NEGOTIABLE)
The system must be highly responsive to ensure a smooth user experience. All API calls and UI 
interactions MUST complete within a maximum of 0.5 seconds. This limit is a non-negotiable 
constraint for all new features and optimizations.

## Additional Constraints
- **Conventions & Style**: Rigorously adhere to existing workspace conventions. Use Prettier/ESLint for React and dotnet-format for C#.
- **Composition over Inheritance**: Prefer explicit composition and delegation to maintain modularity.

## Development Workflow
- **Iterative Cycle**: Research -> Strategy -> Execution (Plan -> Act -> Validate).
- **Validation Path**: Every change must be validated via automated tests and manual verification of the MVC contract and UX simplicity.

## Governance
The Constitution supersedes all other practices. Amendments require documentation and a MINOR 
version bump for principle expansion. All PRs must verify compliance with SOLID, Object 
Calisthenics, UX simplicity, and Performance SLA.

**Version**: 1.3.0 | **Ratified**: 2026-05-09 | **Last Amended**: 2026-05-17
