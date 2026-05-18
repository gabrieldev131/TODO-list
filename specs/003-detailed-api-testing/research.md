# Research: Detailed API Testing

## Decision: Testing Frameworks

### Backend (C#)
- **Choice**: xUnit + Microsoft.AspNetCore.Mvc.Testing (WebApplicationFactory)
- **Rationale**: xUnit is the industry standard for .NET testing. `WebApplicationFactory` allows for high-fidelity integration testing of the API by hosting it in-memory.
- **Alternatives**: NUnit, MSTest (rejected for lower adoption/less idiomatic async support).

### Frontend (React)
- **Choice**: Vitest + React Testing Library
- **Rationale**: Already configured in the project (`package.json`). Vitest is extremely fast and integrates seamlessly with Vite.
- **Alternatives**: Jest (rejected due to complex ESM configuration with Vite).

## Decision: Performance SLA Validation

### Integration Tests
- **Choice**: Automated timing assertions in Integration Tests.
- **Rationale**: By using `Stopwatch` in C# integration tests, we can assert that `elapsedMilliseconds < 500`. This ensures Principle VII is enforced at the gate.
- **Implementation**: A base test class or helper will wrap HTTP calls to measure latency.

### Unit Tests
- **Choice**: Strictly decoupled from external I/O.
- **Rationale**: Per Constitution Principle III and IV, unit tests must only touch domain logic in-memory.
- **Constraint**: Total suite execution time must be < 10s to ensure developer flow.

## Decision: Mocking Strategy

### Backend
- **Choice**: NSubstitute for mocking interfaces.
- **Rationale**: Clean, fluent API for creating stubs and mocks for `ITaskRepository`.

### Frontend
- **Choice**: Vitest mocks (`vi.fn()`).
- **Rationale**: Built-in and sufficient for mocking `apiClient` in component tests.
