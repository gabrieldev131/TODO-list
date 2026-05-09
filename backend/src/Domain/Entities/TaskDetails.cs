using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskDetails - A composition of TaskContent and TaskStatus.
/// 
/// Study Material - Object Calisthenics:
/// 1. Max 2 instance variables: This class exists primarily to satisfy the rule 
///    while allowing the Task entity to have access to all its necessary components.
/// 2. Deep Composition: Demonstrates how complex objects are built from smaller, 
///    focused ones.
/// </summary>
public sealed class TaskDetails
{
    private readonly TaskContent _content;
    private readonly TaskStatus _status;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskDetails"/> class.
    /// </summary>
    public TaskDetails(TaskContent content, TaskStatus status)
    {
        _content = content;
        _status = status;
    }

    /// <summary>
    /// Coordinates the extraction of all task details for DTO mapping.
    /// </summary>
    public (string Title, string Description, string Priority, bool IsCompleted) ToDto()
    {
        var content = _content.ToDto();
        var status = _status.ToDto();
        
        return (content.Title, content.Description, status.Priority, status.IsCompleted);
    }

    public override bool Equals(object? obj)
    {
        return obj is TaskDetails other && 
               _content.Equals(other._content) && 
               _status.Equals(other._status);
    }

    public override int GetHashCode() => HashCode.Combine(_content, _status);

    public static bool operator ==(TaskDetails? left, TaskDetails? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(TaskDetails? left, TaskDetails? right)
    {
        return !(left == right);
    }
}
