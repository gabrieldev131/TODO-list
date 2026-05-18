# Data Model: Testing Infrastructure

This document describes the conceptual entities involved in the testing infrastructure, following the "Detailed API Testing" specification.

## Entities

### TestSuite (Abstract)
Represents a collection of tests with a specific execution context.
- **Type**: `UnitTest` | `IntegrationTest`
- **Goal**: Unambiguous verification of behavior.

### APIEndpointRecord
Represents a unique API route that must be verified by the integration suite.
- **Route**: e.g., `GET /api/tasks`
- **ExpectedLatency**: 0.5s (Global SLA)
- **ValidationRules**: Status code, Body schema, Performance threshold.

### TestResult
The outcome of a single test execution.
- **Status**: `Pass` | `Fail`
- **Latency**: Measured in milliseconds (for Integration Tests).
- **FailureReason**: e.g., "SLA Violated: 550ms > 500ms" or "Logic Error".

## Relationships
- `IntegrationTestSuite` contains multiple `APIEndpointRecord` verifications.
- Each `TestExecution` generates a set of `TestResult`.
