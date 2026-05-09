# Feature Specification: Core Task Management

**Feature Branch**: `001-todo-crud-tags-priority`  
**Created**: 2026-05-09  
**Status**: Draft  
**Input**: User description: "Crie a especificação principal da TODO-list. A feature precisa permitir criar, ler, editar e deletar tarefas. Inclua os fluxos de usuário para adicionar tags personalizadas e um filtro de ordenação por prioridade"

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Basic Task Lifecycle (Priority: P1)

As a busy professional, I want to create, view, edit, and delete tasks so that I can keep track of my daily responsibilities without cluttering my mind.

**Why this priority**: Core functionality; without it, the application has no purpose.

**Independent Test**: Create a task with title "Prepare presentation", verify it appears in the list, change it to "Prepare Q2 presentation", and then delete it.

**Acceptance Scenarios**:

1. **Given** the task list is empty, **When** I add a task titled "Review PRs", **Then** I should see "Review PRs" in my list.
2. **Given** a task "Submit report" exists, **When** I edit the title to "Submit monthly report", **Then** the list should reflect the updated name.
3. **Given** a task exists, **When** I delete it, **Then** it should no longer be visible in the list.

---

### User Story 2 - Task Categorization via Tags (Priority: P2)

As a user with multiple projects, I want to add custom tags to my tasks so that I can group related items together.

**Why this priority**: Essential for organization once the list grows beyond a few items.

**Independent Test**: Add tags "ProjectX" and "Urgent" to a task and verify both are displayed.

**Acceptance Scenarios**:

1. **Given** I am creating a task, **When** I enter "Work" as a tag, **Then** the task should be saved with the "Work" label.
2. **Given** a task has the tag "Personal", **When** I remove it, **Then** the "Personal" label should vanish from that task.

---

### User Story 3 - Priority-Based Focus (Priority: P3)

As a user with many competing demands, I want to assign priorities to tasks and sort my list accordingly so that I know what to work on first.

**Why this priority**: Helps with decision-making and efficiency.

**Independent Test**: Assign "High" priority to a new task and trigger "Sort by Priority" to see it move to the top.

**Acceptance Scenarios**:

1. **Given** tasks with Low, Medium, and High priorities, **When** I apply the priority filter/sort, **Then** High priority tasks must appear first, followed by Medium and Low.

### Edge Cases

- **Task with Empty Title**: System MUST block creation and prompt the user for a name.
- **Maximum Tag Length**: System should handle very long tags gracefully (e.g., wrap or truncate).
- **Duplicate Tags**: Adding the same tag twice should result in a single unique tag instance on the task.

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: System MUST allow users to create tasks with a title, description, and priority level (Low, Medium, High).
- **FR-002**: System MUST allow users to update any attribute of an existing task.
- **FR-003**: System MUST allow users to delete tasks permanently.
- **FR-004**: System MUST allow users to attach multiple custom text strings as tags to a task.
- **FR-005**: System MUST allow users to remove tags from a task.
- **FR-006**: System MUST provide a sorting mechanism that orders tasks by priority (High > Medium > Low).
- **FR-007**: System MUST validate that a title is provided before saving a task.

### Key Entities

- **Task**: The central unit of work. Contains: Unique ID, Title, Description, Priority (High/Medium/Low), Tags (List of Strings).

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: 100% of tasks created are successfully persisted in the current session.
- **SC-002**: Users can complete the creation of a task with 2 tags and a priority in under 10 seconds.
- **SC-003**: Priority sorting reorders a list of 50 tasks in under 100ms.
- **SC-004**: Task list displays updated information immediately after an edit or delete operation.

## Assumptions

- **Persistence**: Data is stored in-memory for the current session, as per project standards (no database).
- **Reminders**: [NEEDS CLARIFICATION: Should task reminders/alerts be part of this CRUD feature or a separate iteration?]
- **Concurrency**: Only one user interacting with the session at a time.
