---
description: "Task list for Detailed API Testing implementation"
---

# Tasks: Detailed API Testing

**Input**: Design documents from `/specs/003-detailed-api-testing/`
**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Tests**: Automated tests for ALL API endpoints are MANDATORY per Constitution (Principle III). Unit tests for domain logic and UI components are also required.

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story. Tasks are designed for junior developers (max 20 mins per task).

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure

- [ ] T001 [P] Create directory `backend/TodoList.Tests/` for the new test project
- [ ] T002 Create `backend/TodoList.Tests/TodoList.Tests.csproj` with xUnit and .NET 10.0 settings
- [ ] T003 Add `Microsoft.NET.Test.Sdk`, `xunit`, `xunit.runner.visualstudio` to `backend/TodoList.Tests/TodoList.Tests.csproj`
- [ ] T004 Add `Microsoft.AspNetCore.Mvc.Testing` and `NSubstitute` to `backend/TodoList.Tests/TodoList.Tests.csproj`
- [ ] T005 Add reference to `TodoList.Api.csproj` in `backend/TodoList.Tests/TodoList.Tests.csproj`
- [ ] T006 Update `backend/TodoList.slnx` to include the `TodoList.Tests` project
- [ ] T007 [P] Create directory `backend/TodoList.Tests/Unit/` for unit tests
- [ ] T008 [P] Create directory `backend/TodoList.Tests/Integration/` for integration tests

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure for Performance SLA and Mocking

- [ ] T009 [P] Create `backend/TodoList.Tests/Integration/TestBase.cs` to hold shared API client logic
- [ ] T010 Implement `WebApplicationFactory` setup in `backend/TodoList.Tests/Integration/TestBase.cs`
- [ ] T011 Implement `AssertSLA` helper in `TestBase.cs` to measure and verify < 500ms latency
- [ ] T012 [P] Create `backend/TodoList.Tests/Unit/UnitTestsBase.cs` for common unit test mocking utilities

---

## Phase 3: User Story 2 - Developer Writing Unit Tests (Priority: P1)

**Goal**: Implement isolated unit tests for domain entities and logic.

**Independent Test**: Run `dotnet test --filter Category=Unit` and verify domain logic tests pass in < 10s.

### Implementation for User Story 2 (Backend)

- [ ] T013 [P] [US2] Create `backend/TodoList.Tests/Unit/TaskTests.cs` for `Task` entity validation
- [ ] T014 [US2] Write unit test for `Task` title length validation in `TaskTests.cs`
- [ ] T015 [US2] Write unit test for `Task` priority assignment logic in `TaskTests.cs`
- [ ] T016 [P] [US2] Create `backend/TodoList.Tests/Unit/RegisterTaskCommandHandlerTests.cs`
- [ ] T017 [US2] Mock `ITaskRepository` using `NSubstitute` in `RegisterTaskCommandHandlerTests.cs`
- [ ] T018 [US2] Write test for successful task registration in `RegisterTaskCommandHandlerTests.cs`
- [ ] T019 [US2] Write test for task registration failure (e.g., null command) in `RegisterTaskCommandHandlerTests.cs`

### Implementation for User Story 2 (Frontend)

- [ ] T020 [P] [US2] Create `frontend/src/components/__tests__/TaskItem.test.jsx`
- [ ] T021 [US2] Write Vitest test for rendering task title in `TaskItem.test.jsx`
- [ ] T022 [US2] Write Vitest test for checkbox interaction in `TaskItem.test.jsx`
- [ ] T023 [P] [US2] Create `frontend/src/hooks/__tests__/useTasks.test.js`
- [ ] T024 [US2] Mock `apiClient` in `useTasks.test.js` to verify task fetching logic

---

## Phase 4: User Story 1 - Maintainer Validating API Endpoints (Priority: P1) 🎯 MVP

**Goal**: Implement automated integration tests for all API endpoints with SLA verification.

**Independent Test**: Run `dotnet test --filter Category=Integration` and verify all endpoints are called and meet the 0.5s SLA.

### Implementation for User Story 1 (Backend)

- [ ] T025 [P] [US1] Create `backend/TodoList.Tests/Integration/TasksApiTests.cs` inheriting from `TestBase.cs`
- [ ] T026 [US1] Implement `GetAll_ReturnsOk_AndUnderSLA` test for `GET /api/tasks` in `TasksApiTests.cs`
- [ ] T027 [US1] Implement `Create_ReturnsCreated_AndUnderSLA` test for `POST /api/tasks` in `TasksApiTests.cs`
- [ ] T028 [US1] Implement `Delete_ReturnsNoContent_AndUnderSLA` test for `DELETE /api/tasks/{id}` in `TasksApiTests.cs`
- [ ] T029 [US1] Add `[Trait("Category", "Integration")]` to all tests in `TasksApiTests.cs`
- [ ] T030 [US1] Verify that `AssertSLA` fails the test if an artificial delay of 600ms is added to a test case

---

## Phase N: Polish & Cross-Cutting Concerns

**Purpose**: Documentation and CI integration

- [ ] T031 [P] Update `specs/003-detailed-api-testing/quickstart.md` with final command examples
- [ ] T032 Verify all tests follow "One dot per line" and other Object Calisthenics where applicable
- [ ] T033 Run `dotnet format` on `backend/TodoList.Tests/`
- [ ] T034 Run `npm run lint` in `frontend/`

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately.
- **Foundational (Phase 2)**: Depends on Setup (T001-T008).
- **User Stories (Phase 3 & 4)**: Depend on Foundational (Phase 2).
- **Polish (Final Phase)**: Depends on all user stories.

### Parallel Opportunities

- Backend and Frontend unit tests (T013-T019 vs T020-T024) can run in parallel.
- All tasks marked `[P]` within the same phase can run in parallel.

---

## Implementation Strategy

### MVP First
1. Complete Setup and Foundational phases.
2. Complete US1 (Integration/SLA) to fulfill the primary mandate of the constitution.
3. Complete US2 (Unit tests) to ensure domain integrity.

### Incremental Delivery
- Each task is small enough for a junior developer.
- Each user story provides a testable increment of the testing infrastructure.
