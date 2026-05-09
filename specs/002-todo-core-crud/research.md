# Research: Pattern Application & Study Material

## Architectural Patterns

### 1. Command Pattern (Orchestration)
- **Application**: Every user action (Register Task, Remove Task, Update Status) will be encapsulated as a Command.
- **Why**: Facilitates undo/redo functionality (if needed later), decouples the Controller from Domain logic, and makes each action independently testable.
- **Pattern Component**: `ITaskCommand`, `AddTaskCommand`, `RemoveTaskCommand`.

### 2. Strategy Pattern (Sorting)
- **Application**: The priority sorting logic will be implemented as a Strategy.
- **Why**: Allows switching between different sorting algorithms (Priority, Title, Date) at runtime without modifying the list manager. Adheres to the Open/Closed Principle.
- **Pattern Component**: `ISortingStrategy`, `PrioritySortStrategy`.

### 3. Factory & Abstract Factory (Instantiation)
- **Application**: An `AbstractTaskFactory` will define the interface for creating tasks and reminders.
- **Why**: Object Calisthenics restricts classes to only 2 instance variables. Factories manage the complex initialization of wrapped primitives and aggregate roots.
- **Pattern Component**: `ITaskFactory`, `SimpleTaskFactory`.

## Technical Constraints

### 1. Object Calisthenics (Backend)
- **Mandate**: No more than 2 instance variables per class.
- **Impact**: `Task` entity will likely aggregate smaller objects (e.g., `TaskIdentity`, `TaskContent`, `TaskMetadata`).
- **Wording**: Avoid all abbreviations. Use `TaskIdentifier` instead of `TaskId`.

### 2. Single-Page React (Frontend)
- **Mandate**: Zero-friction single-page UI.
- **Decision**: Use a single stateful component (or a custom hook `useTasks`) to manage the in-memory list. Inline editing and immediate removal logic.
- **Routing**: Even if it's a SPA, standard RESTful paths will be mimicked in the API calls (e.g., `DELETE /api/tasks/{id}`).

### 3. Study Material focus
- **Goal**: The code should clearly demonstrate SOLID (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion).
- **Decision**: Use dependency injection via ASP.NET built-in DI container to link Factories and Strategies to Controllers.
