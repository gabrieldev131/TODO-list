# Architecture Study Guide - TODO List Project

This guide explains the architectural decisions and principles applied to the TODO-list project, focusing on SOLID, Object Calisthenics, and Design Patterns within an MVC context.

## 1. SOLID Principles

The project strictly adheres to the SOLID principles to ensure maintainability and scalability.

- **SRP (Single Responsibility Principle):**
    - Each class has a single purpose. For example, `TaskTitle` only manages the title's validity and representation.
    - Command Handlers (e.g., `RegisterTaskCommandHandler`) are responsible for a single action, separating the "what to do" from the "how to do it".
- **OCP (Open/Closed Principle):**
    - The **Strategy Pattern** used in `TaskSortingContext` allows adding new sorting methods (like by Date) without modifying the existing context or strategies. You only need to implement `ITaskSortingStrategy`.
- **LSP (Liskov Substitution Principle):**
    - Any implementation of `ITaskSortingStrategy` can be used by the `TaskSortingContext` interchangeably without breaking the application logic.
- **ISP (Interface Segregation Principle):**
    - Interfaces like `ITaskCommandHandler<TCommand, TResult>` are focused and generic, ensuring that implementations only depend on the methods they actually need.
- **DIP (Dependency Inversion Principle):**
    - High-level modules (Controllers) do not depend on low-level modules (Repositories). Both depend on abstractions (`ITaskRepository`). This is facilitated by Dependency Injection in `Program.cs`.

## 2. Object Calisthenics

Object Calisthenics are a set of rules to keep code clean and object-oriented. Key rules applied:

- **Max 2 instance variables per class:**
    - Classes like `TaskAggregate` group related objects (`TaskLifeCycle`, `TaskTags`) to respect this limit while maintaining rich functionality.
    - This forces deep thinking about composition and how data is naturally grouped in the domain.
- **Wrap all primitives:**
    - We don't use raw `string` or `Guid`. Instead, we use `TaskTitle`, `TaskDescription`, and `TaskIdentifier`.
    - Benefits: Type safety (you can't pass a description to a title parameter) and a place to put domain validation logic.
- **No 'else' keyword:**
    - Logic flows use early returns or polymorphism.
    - Example: `TaskSortingContext` uses a dictionary lookup instead of `if-else` chains to select strategies.
- **First-Class Collections:**
    - `TaskTags` encapsulates a list of tags. It handles logic like "no duplicate tags" within its own class rather than leaking it into the `Task` entity.

## 3. Design Patterns

The backend follows an MVC architecture enhanced with specific patterns:

- **Command Pattern:**
    - Encapsulates requests as objects (`RegisterTaskCommand`).
    - Decouples the invoker (Controller) from the receiver (Repository) via Handlers.
- **Strategy Pattern:**
    - Used for sorting tasks. `ITaskSortingStrategy` defines the interface, and `PrioritySortingStrategy` / `TitleSortingStrategy` provide concrete algorithms.
- **Factory Pattern:**
    - `ITaskFactory` (specifically `SimpleTaskFactory`) handles the complex orchestration of creating a `Task` aggregate, including all its value objects and nested compositions.
- **Aggregate Root (DDD):**
    - `Task` acts as the Aggregate Root, ensuring consistency and providing a single entry point for all operations on the task data.

## 4. MVC & SPA Architecture

- **Model:** Represented by the Domain entities. It contains the business logic and rules.
- **View:** The React SPA (`frontend/src`). It's designed to be "Simple & Clear," communicating with the API via JSON.
- **Controller:** `TasksController` in the backend API. It thin-manages the flow, delegating business logic to the Command Handlers and Repositories.

This architecture ensures that the frontend remains a "dumb" representation layer while the backend maintains a rich, well-protected domain model.
