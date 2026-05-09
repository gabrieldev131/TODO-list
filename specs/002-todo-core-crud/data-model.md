# Data Model: Core Task Management

## Entities (Backend - C#)

### Task (Aggregate Root)
- **Identifier**: `TaskIdentifier` (Value Object)
- **Content**: `TaskContent` (Entity containing Title and Description)
- **Status**: `TaskStatus` (Value Object: Priority and Completion state)

*Note: Decomposition follows Object Calisthenics "Max 2 instance variables" rule.*

## Value Objects

### TaskIdentifier
- **Value**: `Guid`
- **Rule**: Immutable, unique.

### TaskTitle
- **Value**: `String`
- **Rule**: Wrapped primitive. Non-empty, max 100 chars.

### TaskDescription
- **Value**: `String`
- **Rule**: Wrapped primitive. Optional.

### TaskPriority
- **Enum**: `High`, `Medium`, `Low`.

### TaskTag
- **Value**: `String`
- **Rule**: Wrapped primitive. De-duplicated in Task collection.

## Frontend State (React)

```javascript
{
  tasks: [
    {
      id: "string",
      title: "string",
      description: "string",
      priority: "High" | "Medium" | "Low",
      tags: ["string"],
      reminderAt: "ISO-8601",
      isCompleted: "boolean"
    }
  ],
  filter: {
    sortBy: "priority" | "date"
  }
}
```

## Relationships

- **Task** (1) -- (*) **TaskTag** (Value Objects)
- **Task** (1) -- (0..1) **Reminder** (Value Object)
