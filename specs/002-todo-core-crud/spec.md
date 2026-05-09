# Feature Specification: TODO-list Core Task Management

**Feature Branch**: `002-todo-core-crud`  
**Created**: 2026-05-09  
**Status**: Draft  
**Input**: User description: "Crie a especificação principal da TODO-list. A feature precisa permitir criar, ler, editar e deletar tarefas. Inclua os fluxos de usuário para adicionar tags personalizadas e um filtro de ordenação por prioridade, tudo isso sem persistencia de dados"

## Clarifications

### Session 2026-05-09
- Q: Interpretation of "Não fará CRUD" → A: Reinforces no database/persistence; maintain full functional CRUD in-memory.
- Q: Routing Simplicity → A: Follow standard RESTful naming conventions for both API and Frontend routes.
- Q: Simple & Clear Frontend UX → A: Use a single-page interface where all actions (Create, List, Sort) happen in the same view.

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Simple Task Creation and Management (Priority: P1)

As a user, I want to quickly add a task with just a title and manage it (edit/delete) so that I can keep track of my daily activities with zero friction.

**Why this priority**: Fundamental value of the application; follows the "Simple & Clear UX" principle.

**Independent Test**: Create a task "Buy groceries", see it in the list, change it to "Buy groceries and water", and then delete it.

**Acceptance Scenarios**:

1. **Given** the app is open on the main view, **When** I type "Meeting at 2pm" and click 'Add', **Then** the task should appear at the top of my list.
2. **Given** a task "Exercise" exists, **When** I click the edit icon and change it to "Run 5km", **Then** the list should immediately reflect the update.
3. **Given** a task "Old task", **When** I click the delete button, **Then** the task should disappear from the screen without a page reload.

---

### User Story 2 - Organizing with Custom Tags (Priority: P2)

As an organized user, I want to add multiple custom tags to my tasks so that I can categorize them by context (e.g., Work, Home, Urgent).

**Why this priority**: Essential for managing more than a handful of tasks.

**Independent Test**: Create a task with tags "Work" and "Design", verify both are visible as distinct labels.

**Acceptance Scenarios**:

1. **Given** the task creation form, **When** I enter "ProjectA" and "ClientB" in the tags field, **Then** the saved task should display both labels.
2. **Given** a task has the tag "Legacy", **When** I remove the tag in the edit view, **Then** the label should vanish from the task.

---

### User Story 3 - Priority Sorting (Priority: P2)

As a user with many tasks, I want to assign priorities (Low, Medium, High) and sort my list so that I can focus on the most important items first.

**Why this priority**: Helps with decision-making and time management.

**Independent Test**: Add 3 tasks with different priorities and verify they reorder correctly when "Sort by Priority" is toggled.

**Acceptance Scenarios**:

1. **Given** multiple tasks with mixed priorities, **When** I select "Sort by Priority: High First", **Then** the tasks must be displayed in the order: High -> Medium -> Low.

---

### User Story 4 - Setting Reminders (Priority: P3)

As a forgetful user, I want to set a reminder time for my tasks so that I am notified when a task needs attention.

**Why this priority**: Mandated by project constitution v1.2.0 for proactive engagement.

**Independent Test**: Set a reminder for 1 minute in the future and verify a visual notification appears.

**Acceptance Scenarios**:

1. **Given** I am creating or editing a task, **When** I select a reminder time, **Then** the system should track this time in-memory.
2. **Given** a task reminder time is reached, **When** the app is open, **Then** a clear and simple visual alert should notify me.

### Edge Cases

- **Duplicate Tags**: Adding the same tag twice to a task should be handled gracefully (de-duplicated).
- **Empty Title**: System MUST NOT allow creation of a task without a title.
- **In-Memory Limit**: Since there is no persistence, a page refresh will clear all data. This must be clear to the user if appropriate.
- **Concurrent Reminders**: How the system handles multiple reminders firing at the same time.

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: System MUST allow creating tasks with a Title, Description (optional), Priority, and multiple Tags.
- **FR-002**: System MUST allow full in-memory CRUD (Create, Read, Update, Delete) operations.
- **FR-003**: System MUST provide a "Sort by Priority" toggle in the main view.
- **FR-004**: System MUST follow standard RESTful naming conventions for all API endpoints (e.g., `/api/tasks`).
- **FR-005**: System MUST allow adding/removing custom text tags to any task.
- **FR-006**: System MUST allow setting a specific time for a Reminder on a task.
- **FR-007**: System MUST trigger a visual notification when a reminder time is reached (if the app is open).
- **FR-008**: System MUST store all data in-memory only.
- **FR-009**: The Frontend MUST be a single-page interface with all primary actions (Add, Remove, Sort) accessible in the same view.

### Key Entities

- **Task**: 
    - **Id**: Unique identifier.
    - **Title**: String (Required).
    - **Description**: String (Optional).
    - **Priority**: Enum (Low, Medium, High).
    - **Tags**: Collection of Strings.
    - **ReminderTime**: DateTime (Optional).
    - **IsCompleted**: Boolean.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: Users can add a new task with tags and priority in under 5 seconds.
- **SC-002**: List sorting is performed in under 50ms for up to 100 tasks.
- **SC-003**: 100% of data is stored in memory; no calls to external databases or local storage are made for persistence.
- **SC-004**: Notifications are triggered within 2 seconds of the scheduled reminder time.

## Assumptions

- **Target Platform**: Modern web browser (supporting React).
- **User Environment**: Single-user, local-only session.
- **Persistence Awareness**: Users understand that closing the tab will clear their tasks.
- **Notification Method**: Simple browser-based or UI-component-based alerts (no OS-level push notifications for v1).
- **Reminder Logic**: [NEEDS CLARIFICATION: Should the system support recurring reminders or just one-time alerts?]
