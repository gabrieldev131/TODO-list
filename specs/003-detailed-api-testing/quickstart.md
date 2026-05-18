# Quickstart: Testing

This document explains how to execute the test suites and verify the 0.5s Performance SLA.

## Prerequisites
- .NET 10.0 SDK
- Node.js 20+
- `npm install` in `frontend/`

## Running Backend Tests

### Unit Tests
```bash
dotnet test backend/TodoList.Tests --filter Category=Unit
```

### Integration Tests (with SLA Check)
```bash
dotnet test backend/TodoList.Tests --filter Category=Integration
```

## Running Frontend Tests

### Unit/Component Tests
```bash
cd frontend
npm run test
```

## Verification
- **Success**: All tests pass and output reports latency for API calls.
- **SLA Failure**: Tests will fail with message `Response time (Xms) exceeds 500ms limit`.
