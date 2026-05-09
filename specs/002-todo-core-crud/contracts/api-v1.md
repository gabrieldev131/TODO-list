# API Contract: Tasks v1

## Endpoints

### GET /api/tasks
Retrieve all tasks from memory.

- **Query Parameters**:
  - `sortBy`: (optional) `priority` | `title` | `date`
- **Response**: `200 OK`
  - Body: `TaskDTO[]`

### POST /api/tasks
Register a new task.

- **Request Body**:
  - `title`: string (required)
  - `description`: string (optional)
  - `priority`: string ("High", "Medium", "Low")
  - `tags`: string[] (optional)
- **Response**: `201 Created`
  - Body: `TaskDTO`

### PUT /api/tasks/{id}
Update task details or status.

- **Request Body**:
  - Same as POST (partial updates allowed)
  - `isCompleted`: boolean
- **Response**: `204 No Content` | `404 Not Found`

### DELETE /api/tasks/{id}
Remove a task from memory.

- **Response**: `204 No Content` | `404 Not Found`

## Data Transfer Objects (DTOs)

### TaskDTO
```json
{
  "id": "uuid",
  "title": "string",
  "description": "string",
  "priority": "string",
  "tags": ["string"],
  "reminderAt": "iso-date",
  "isCompleted": "boolean"
}
```
