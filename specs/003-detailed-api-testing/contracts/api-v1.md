# API Contract: v1

## Tasks Endpoints

### GET /api/tasks
Retrieves all tasks.
- **Query Params**: `sortBy` (optional: `priority`, `title`)
- **Success Response**: `200 OK`
- **Body**: `Array<TaskDataTransferObject>`

### POST /api/tasks
Creates a new task.
- **Body**: `RegisterTaskCommand`
- **Success Response**: `201 Created`
- **Body**: `TaskDataTransferObject`

### DELETE /api/tasks/{id}
Removes a task.
- **Path Params**: `id` (Guid)
- **Success Response**: `204 No Content`

## Data Objects

### TaskDataTransferObject
```json
{
  "id": "uuid",
  "title": "string",
  "description": "string",
  "priority": "string",
  "tags": ["string"],
  "reminderAt": "ISO8601-date-string",
  "isCompleted": "boolean"
}
```
