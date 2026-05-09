# Tasks: Core Task Management

**Input**: Design documents from `specs/002-todo-core-crud/`
**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/api-v1.md

**Tests**: Unit tests are mandatory for all domain logic (Commands, Strategies, Factories) and backend entities per project constitution.

**Organization**: Tasks are grouped by user story to enable independent implementation and testing.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

---

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure

- [x] T001 Initialize backend ASP.NET Core Web API project in `backend/`
- [x] T002 Initialize frontend React project (Vite/TS) in `frontend/`
- [x] T003 [P] Configure `dotnet-format` and `.editorconfig` for Object Calisthenics rules in `backend/`
- [x] T004 [P] Configure ESLint and Prettier for React formatting in `frontend/`
- [x] T005 [P] Setup xUnit test project in `backend/tests/`
- [x] T006 [P] Setup Vitest/Testing Library for React components in `frontend/tests/`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before ANY user story can be implemented

- [x] T007 [P] Create `TaskIdentifier` value object (wrapped Guid) in `backend/src/Domain/Entities/TaskIdentifier.cs`
- [x] T008 [P] Create `TaskTitle` value object (wrapped string) in `backend/src/Domain/Entities/TaskTitle.cs`
- [x] T009 [P] Create `TaskDescription` value object (wrapped string) in `backend/src/Domain/Entities/TaskDescription.cs`
- [x] T010 [P] Create `TaskPriority` enumeration (High, Medium, Low) in `backend/src/Domain/Entities/TaskPriority.cs`
- [x] T011 Create `TaskContent` entity (Title + Description) in `backend/src/Domain/Entities/TaskContent.cs`
- [x] T012 Create `TaskStatus` value object (Priority + IsCompleted) in `backend/src/Domain/Entities/TaskStatus.cs`
- [x] T013 Implement `Task` aggregate root (Identifier + Content + Status) in `backend/src/Domain/Entities/Task.cs`
- [x] T014 Define `ITaskRepository` interface for in-memory storage in `backend/src/Domain/Interfaces/ITaskRepository.cs`
- [x] T015 Implement `InMemoryTaskRepository` (singleton state) in `backend/src/Infrastructure/Persistence/InMemoryTaskRepository.cs`
- [x] T016 Create `TaskDataTransferObject` for API responses in `backend/src/API/DTOs/TaskDataTransferObject.cs`

**Checkpoint**: Foundation ready - domain entities and storage abstraction complete.

---

## Phase 3: User Story 1 - Simple Task Lifecycle (Priority: P1) 🎯 MVP

**Goal**: Register, view, and remove tasks.

**Independent Test**: Use Swagger to create a task, list it, and delete it; verify in-memory state.

### Backend Implementation (US1)

- [x] T017 [P] [US1] Define `ITaskCommand` and `ITaskCommandHandler` interfaces in `backend/src/Domain/Commands/`
- [x] T018 [US1] Create `RegisterTaskCommand` class in `backend/src/Domain/Commands/RegisterTaskCommand.cs`
- [x] T019 [US1] Implement `RegisterTaskCommandHandler` in `backend/src/Domain/Commands/RegisterTaskCommandHandler.cs`
- [x] T020 [US1] Create `RemoveTaskCommand` class in `backend/src/Domain/Commands/RemoveTaskCommand.cs`
- [x] T021 [US1] Implement `RemoveTaskCommandHandler` in `backend/src/Domain/Commands/RemoveTaskCommandHandler.cs`
- [x] T022 [US1] Create `TasksController` with RESTful GET/POST/DELETE in `backend/src/API/Controllers/TasksController.cs`
- [x] T023 [US1] Add unit tests for `RegisterTaskCommandHandler` in `backend/tests/Domain/Commands/`

### Frontend Implementation (US1)

- [x] T024 [P] [US1] Create `apiClient` service (Axios/Fetch) in `frontend/src/services/apiClient.js`
- [x] T025 [US1] Implement `useTasks` hook for in-memory state and CRUD logic in `frontend/src/hooks/useTasks.js`
- [x] T026 [US1] Create `TaskList` view component in `frontend/src/components/TaskList.jsx`
- [x] T027 [US1] Create `TaskRegistrationForm` component in `frontend/src/components/TaskRegistrationForm.jsx`
- [x] T028 [US1] Implement removal logic in `TaskItem` component in `frontend/src/components/TaskItem.jsx`

**Checkpoint**: User Story 1 complete - SPA with CRUD (except Update) functional.

---

## Phase 4: User Story 2 & 3 - Organization & Sorting (Priority: P2)

**Goal**: Add tags and sort tasks by priority using the Strategy pattern.

### Backend Implementation (US2/US3)

- [x] T029 [P] [US2] Create `TaskTag` value object in `backend/src/Domain/Entities/TaskTag.cs`
- [x] T030 [US2] Update `Task` entity to support tag collection in `backend/src/Domain/Entities/Task.cs`
- [x] T031 [P] [US3] Define `ITaskSortingStrategy` interface in `backend/src/Domain/Strategies/ITaskSortingStrategy.cs`
- [x] T032 [US3] Implement `PrioritySortingStrategy` in `backend/src/Domain/Strategies/PrioritySortingStrategy.cs`
- [x] T033 [US3] Update `TasksController` GET to support `sortBy` parameter in `backend/src/API/Controllers/TasksController.cs`
- [x] T034 [US3] Add unit tests for `PrioritySortingStrategy` in `backend/tests/Domain/Strategies/`

### Frontend Implementation (US2/US3)

- [x] T035 [US2] Update `TaskRegistrationForm` to handle tag inputs in `frontend/src/components/TaskRegistrationForm.jsx`
- [x] T036 [US2] Create `TagBadge` component for UI display in `frontend/src/components/TagBadge.jsx`
- [x] T037 [US3] Create `SortingControl` component (Dropdown) in `frontend/src/components/SortingControl.jsx`
- [x] T038 [US3] Update `useTasks` hook to trigger sorted data fetching in `frontend/src/hooks/useTasks.js`

**Checkpoint**: User Story 2 & 3 complete - Tags and Sorting integrated into the SPA.

---

## Phase 5: User Story 4 - Reminders (Priority: P3)

**Goal**: Set and receive task reminders.

### Backend Implementation (US4)

- [x] T039 [P] [US4] Create `TaskReminder` value object (DateTime) in `backend/src/Domain/Entities/TaskReminder.cs`
- [x] T040 [US4] Update `Task` entity to include `TaskReminder` in `backend/src/Domain/Entities/Task.cs`
- [x] T041 [US4] Update `TaskDataTransferObject` and Controller for reminders in `backend/src/API/`

### Frontend Implementation (US4)

- [x] T042 [US4] Add Date/Time picker to `TaskRegistrationForm` in `frontend/src/components/TaskRegistrationForm.jsx`
- [x] T043 [US4] Implement `NotificationOverlay` for reminder alerts in `frontend/src/components/NotificationOverlay.jsx`
- [x] T044 [US4] Implement client-side timer logic for triggering reminders in `frontend/src/hooks/useReminders.js`

**Checkpoint**: User Story 4 complete - Proactive reminder alerts functional in UI.

---

## Phase 6: Polish & Study Material

**Purpose**: Documentation and Final OC/SOLID audit

- [x] T045 [P] Add detailed comments to all Backend Patterns (Strategy, Command, Factory) explaining SOLID principles
- [x] T046 [P] Add detailed comments to Backend Entities explaining Object Calisthenics benefits
- [x] T047 [P] Create `ArchitectureStudyGuide.md` summary for 1-on-1 prep
- [x] T048 Final validation of "Zero Friction" UX in SPA

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: Must be completed first.
- **Foundational (Phase 2)**: Must be completed before any functional stories.
- **User Stories**:
  - US1 (Phase 3) is the mandatory MVP.
  - US2 & US3 (Phase 4) integration.
  - US4 (Phase 5) final feature addition.
- **Polish (Phase 6)**: Continuous but finalized at end.

### Parallel Opportunities

- Setup tasks (T003-T006) can run in parallel after T001/T002.
- Backend Value Objects (T007-T010) in Phase 2.
- Backend vs Frontend development within each Story phase (e.g., T017-T023 vs T024-T028).

---

## Implementation Strategy

### MVP First (User Story 1 Only)

The primary goal is to establish the ASP.NET Core REST API and the React SPA with simple task registration and removal. This establishes the pattern baseline.

### Incremental Delivery

1. Setup environment and OC rules.
2. Build domain model with wrapped primitives.
3. Deliver CRUD Command logic and API.
4. Integrate React list view and form.
5. Extend with Sorting Strategy and Tags.
6. Add Reminder logic.
7. Final SOLID audit and documentation.

---

## Notes

- **Object Calisthenics Rule**: Classes should only have 2 instance variables. If `Task` needs more, compose them into sub-entities like `TaskContent` and `TaskStatus`.
- **In-Memory Rule**: Do not use `DbContext` or LocalStorage. Keep state in static singletons (Backend) or local component state (Frontend).
- **Study Material**: Comments should focus on "Why this pattern" and "Which SOLID principle applies".
