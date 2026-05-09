# Tasks: Core Task Management

**Input**: Design documents from `specs/001-todo-crud-tags-priority/`
**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/api-v1.md

**Tests**: Unit tests are required for all backend domain logic and frontend services per Constitution v1.1.0.

**Organization**: Tasks are grouped by user story to enable independent implementation and testing.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

---

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure

- [ ] T001 Initialize backend ASP.NET Core Web API project in `backend/`
- [ ] T002 Initialize frontend React project (Vite/TS) in `frontend/`
- [ ] T003 [P] Configure `dotnet-format` and `EditorConfig` for Object Calisthenics in `backend/`
- [ ] T004 [P] Configure ESLint and Prettier in `frontend/`
- [ ] T005 [P] Setup xUnit project for backend tests in `backend/tests/`
- [ ] T006 [P] Setup Vitest/Testing Library for frontend tests in `frontend/tests/`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before ANY user story can be implemented

- [ ] T007 [P] Create `TaskId` value object in `backend/src/Domain/Entities/TaskId.cs`
- [ ] T008 [P] Create `TaskTitle` value object in `backend/src/Domain/Entities/TaskTitle.cs`
- [ ] T009 [P] Create `TaskPriority` enum in `backend/src/Domain/Entities/TaskPriority.cs`
- [ ] T010 Create base `Task` entity in `backend/src/Domain/Entities/Task.cs` (Object Calisthenics compliant)
- [ ] T011 Define `ITaskRepository` interface in `backend/src/Domain/Interfaces/ITaskRepository.cs`
- [ ] T012 Implement `InMemoryTaskRepository` in `backend/src/Infrastructure/Persistence/InMemoryTaskRepository.cs`
- [ ] T013 [P] Create base `TaskDTO` in `backend/src/API/DTOs/TaskDTO.cs`
- [ ] T014 [P] Setup API Client (Axios/Fetch) in `frontend/src/services/apiClient.js`

**Checkpoint**: Foundation ready - backend repository and frontend client can communicate.

---

## Phase 3: User Story 1 - Basic Task Lifecycle (Priority: P1) 🎯 MVP

**Goal**: Create, view, edit, and delete tasks.

**Independent Test**: Use Swagger/Postman to perform full CRUD on a task; verify UI updates.

### Backend Implementation (US1)

- [ ] T015 [P] [US1] Define `ICreateTaskCommand` in `backend/src/Domain/Commands/ICreateTaskCommand.cs`
- [ ] T016 [US1] Implement `CreateTaskCommandHandler` in `backend/src/Domain/Commands/CreateTaskCommandHandler.cs`
- [ ] T017 [P] [US1] Define `IDeleteTaskCommand` in `backend/src/Domain/Commands/IDeleteTaskCommand.cs`
- [ ] T018 [US1] Implement `DeleteTaskCommandHandler` in `backend/src/Domain/Commands/DeleteTaskCommandHandler.cs`
- [ ] T019 [US1] Create `TasksController` with GET/POST/DELETE in `backend/src/API/Controllers/TasksController.cs`
- [ ] T020 [US1] Add unit tests for `CreateTaskCommandHandler` in `backend/tests/Domain/Commands/CreateTaskCommandHandlerTests.cs`

### Frontend Implementation (US1)

- [ ] T021 [P] [US1] Create `TaskService` for CRUD operations in `frontend/src/services/taskService.js`
- [ ] T022 [US1] Implement `useTasks` hook for state management in `frontend/src/hooks/useTasks.js`
- [ ] T023 [US1] Create `TaskList` component in `frontend/src/components/TaskList.jsx`
- [ ] T024 [US1] Create `TaskForm` component for adding tasks in `frontend/src/components/TaskForm.jsx`
- [ ] T025 [US1] Add "Delete" button logic to `TaskItem` component in `frontend/src/components/TaskItem.jsx`

**Checkpoint**: User Story 1 complete - MVP is functional.

---

## Phase 4: User Story 2 - Task Categorization via Tags (Priority: P2)

**Goal**: Add and remove multiple custom tags to tasks.

**Independent Test**: Create a task with tags "Work" and "Urgent", verify they appear in the UI.

### Backend Implementation (US2)

- [ ] T026 [P] [US2] Create `TaskTag` value object in `backend/src/Domain/Entities/TaskTag.cs`
- [ ] T027 [US2] Update `Task` entity to include `TagCollection` in `backend/src/Domain/Entities/Task.cs`
- [ ] T028 [US2] Update `TaskDTO` and `TasksController` to handle tags in `backend/src/API/`
- [ ] T029 [US2] Add unit tests for tag validation in `backend/tests/Domain/Entities/TaskTagTests.cs`

### Frontend Implementation (US2)

- [ ] T030 [US2] Update `TaskForm` to include tag input logic in `frontend/src/components/TaskForm.jsx`
- [ ] T031 [US2] Create `TagList` component for displaying tags in `frontend/src/components/TagList.jsx`
- [ ] T032 [US2] Implement "Remove Tag" functionality in `frontend/src/components/TagItem.jsx`

**Checkpoint**: User Story 2 complete - tasks are now taggable.

---

## Phase 5: User Story 3 - Priority-Based Focus (Priority: P3)

**Goal**: Assign priorities and sort the list.

**Independent Test**: Add 3 tasks with Low, High, Medium priorities; trigger sort and verify High is at top.

### Backend Implementation (US3)

- [ ] T033 [P] [US3] Define `ITaskSortStrategy` interface in `backend/src/Domain/Strategies/ITaskSortStrategy.cs`
- [ ] T034 [US3] Implement `PrioritySortStrategy` in `backend/src/Domain/Strategies/PrioritySortStrategy.cs`
- [ ] T035 [US3] Update `TasksController` GET to accept `sortBy` parameter in `backend/src/API/Controllers/TasksController.cs`
- [ ] T036 [US3] Add unit tests for `PrioritySortStrategy` in `backend/tests/Domain/Strategies/PrioritySortStrategyTests.cs`

### Frontend Implementation (US3)

- [ ] T037 [US3] Update `TaskForm` to include Priority dropdown in `frontend/src/components/TaskForm.jsx`
- [ ] T038 [US3] Implement `SortControl` component in `frontend/src/components/SortControl.jsx`
- [ ] T039 [US3] Update `useTasks` hook to handle sorting requests in `frontend/src/hooks/useTasks.js`

**Checkpoint**: User Story 3 complete - full feature set delivered.

---

## Phase 6: Polish & Cross-Cutting Concerns

- [ ] T040 [P] Add CSS transitions for list sorting in `frontend/src/index.css`
- [ ] T041 [P] Implement loading skeletons in `frontend/src/components/LoadingSkeleton.jsx`
- [ ] T042 [P] Update `quickstart.md` with final API endpoint details
- [ ] T043 Final validation of Object Calisthenics compliance across backend

---

## Dependencies & Execution Order

### Phase Dependencies

1. **Setup (Phase 1)**: Must be completed first.
2. **Foundational (Phase 2)**: Depends on Phase 1.
3. **User Stories (Phase 3-5)**: All depend on Phase 2.
   - US1 (Phase 3) is the MVP and should be completed before US2/US3.
   - US2 and US3 can proceed in parallel once US1 is stable.

### Parallel Opportunities

- T003-T006 (Setup configurations)
- T007-T009 (Backend value objects)
- T015, T017, T021 (Command definitions and service client)
- US2 and US3 implementation after US1 is complete.

---

## Implementation Strategy

### MVP First (User Story 1 Only)

Focus on getting the backend API and the React list/form working without tags or priority sorting. This delivers the core value fastest.

### Incremental Delivery

1. Initialize projects.
2. Build core entities and in-memory storage.
3. Deliver CRUD (US1).
4. Add Tags (US2).
5. Add Sorting (US3).
6. Final UI/UX polish.
