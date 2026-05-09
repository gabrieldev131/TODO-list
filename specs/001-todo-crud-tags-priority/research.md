# Research: Core Task Management Patterns

## Technical Decisions

### 1. Operation Orchestration: Command Pattern
- **Decision**: Use a custom `ICommand<TResponse>` and `ICommandHandler<TCommand, TResponse>` pattern.
- **Rationale**: Decouples the Controller from the Domain logic. Each CRUD operation (Create, Update, Delete) becomes a discrete command class. This facilitates testing and adheres to the Single Responsibility Principle.
- **Alternatives considered**: Direct Service calls (rejected as it tends to bloat services and violates the "one level of indentation" rule more easily).

### 2. Dynamic Sorting: Strategy Pattern
- **Decision**: Implement `ITaskSortStrategy` with specific implementations for `PrioritySortStrategy` and `CreatedDateSortStrategy`.
- **Rationale**: Allows the user to toggle sorting logic dynamically without modifying the list processing loop. This satisfies the Open/Closed Principle.
- **Alternatives considered**: Switch/Case in the UI (rejected as it leaks logic into the View).

### 3. Object Creation: Abstract Factory
- **Decision**: Use `ITaskFactory` for instantiating Task entities.
- **Rationale**: Object Calisthenics restricts constructors with many parameters and instance variables. A Factory can manage the complex initialization of the `Task` entity and its wrapped value objects.
- **Alternatives considered**: Static Create methods (acceptable but less flexible for testing mocks).

### 4. Object Calisthenics Compliance (C#)
- **Decision**: Wrap all strings (Title, Description, Tag) in Value Objects (e.g., `new TaskTitle("...")`).
- **Rationale**: Mandated by v1.1.0 Constitution ("Wrap all primitives"). Prevents primitive obsession and allows for internal validation (e.g., non-empty titles).
- **Enforcement**: Methods will be kept under 10 lines. No `else` keywords will be used; instead, guard clauses and early returns will be employed.

### 5. Frontend Orchestration (React)
- **Decision**: Use Custom Hooks (`useTasks`, `useSort`) as "Controllers".
- **Rationale**: Keeps the View components pure and focused on rendering. Logic for fetching, state management, and sorting is encapsulated in hooks.
- **Alternatives considered**: Context API (not needed for simple single-page state).
