# Data Model: Core Task Management

## Entities (Object Calisthenics compliant)

### Task
The aggregate root for task management.

- **Id**: `TaskId` (Wrapped GUID)
- **Title**: `TaskTitle` (Wrapped string, max 100 chars)
- **Description**: `TaskDescription` (Wrapped string, optional)
- **Priority**: `TaskPriority` (Enum: Low, Medium, High)
- **Tags**: `TagCollection` (Wrapper around `List<TaskTag>`)

## Value Objects

### TaskTitle
- **Validation**: Cannot be empty, trimmed.
- **Rules**: Must be unique within the current list (optional business rule).

### TaskPriority
- **Values**: `1` (High), `2` (Medium), `3` (Low).
- **Default**: `Medium`.

### TaskTag
- **Validation**: Max 20 chars, alphanumeric only.
- **Rules**: Immutable once created.

## Relationships

- **Task** (1) --- (*) **TaskTag** (Value object collection)
- **InMemoryStore** (1) --- (*) **Task** (Repository management)

## State Transitions

| Current State | Action | Next State |
|---------------|--------|------------|
| (none)        | Create | Active     |
| Active        | Update | Active     |
| Active        | Delete | (deleted)  |
