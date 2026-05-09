# API Contract: Tasks v1

## Endpoints

### GET /api/tasks
Retrieve all tasks.

- **Query Parameters**:
  - `sortBy`: (optional) `priority` | `title` | `date`
- **Response**: `200 OK`
  - Body: `TaskDTO[]`

### POST /api/tasks
Create a new task.

- **Request Body**:
  - `title`: string (required)
  - `description`: string (optional)
  - `priority`: string ("High", "Medium", "Low")
  - `tags`: string[] (optional)
- **Response**: `201 Created`
  - Body: `TaskDTO`

### PUT /api/tasks/{id}
Update an existing task.

- **Request Body**:
  - Same as POST (partial updates allowed)
- **Response**: `204 No Content` | `404 Not Found`

### DELETE /api/tasks/{id}
Delete a task.

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
  "createdAt": "iso-date"
}
```
