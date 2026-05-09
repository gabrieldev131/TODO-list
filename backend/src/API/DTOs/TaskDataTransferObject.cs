using System;
using System.Collections.Generic;

namespace TodoList.Api.API.DTOs
{
    /// <summary>
    /// TaskDataTransferObject (DTO).
    /// 
    /// MVC Pattern: The DTO is part of the Model layer but specifically designed for 
    /// communication between the Controller and the View (Frontend).
    /// 
    /// C# Feature: Record.
    /// Records are ideal for DTOs because they provide built-in immutability and 
    /// value-based equality. This follows the "Study Material" goal by demonstrating 
    /// modern C# practices for data contracts.
    /// </summary>
    public record TaskDataTransferObject(
        Guid Id,
        string Title,
        string Description,
        string Priority,
        IEnumerable<string> Tags,
        DateTime? ReminderAt,
        bool IsCompleted
    );
}
