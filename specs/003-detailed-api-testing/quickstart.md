# Quickstart: Testing

This document explains how to execute the test suites and verify the 0.5s Performance SLA.

## Prerequisites
- .NET 10.0 SDK
- Node.js 20+
- `npm install` in `frontend/`

## Running Backend Tests

### Unit Tests (Domain Logic)
These tests are strictly in-memory and follow Object Calisthenics.
```bash
dotnet test backend/TodoList.Tests --filter Category=Unit
```

### Integration Tests (API & SLA)
These tests verify end-to-end behavior and enforce the 0.5s Performance SLA mandate.
```bash
dotnet test backend/TodoList.Tests --filter Category=Integration
```

## Running Frontend Tests

### Component and Hook Tests
These tests use Vitest and React Testing Library to verify UI behavior in isolation.
```bash
cd frontend
npm run test
```

## Environment Configuration
The frontend `apiClient.js` now uses the `VITE_API_URL` environment variable. 
To point to a different backend, create a `.env` file in the `frontend/` directory:
```text
VITE_API_URL=http://production-api.com/api
```

## Verification
- **Success**: All tests pass and output reports latency for API calls.
- **SLA Failure**: Integration tests will fail with message `Performance SLA Violated: Request took Xms (Limit: 500ms)`.
