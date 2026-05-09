using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskStatus - Composes the Priority and Completion status of a Task.
/// 
/// Study Material - Object Calisthenics:
/// 1. Max 2 instance variables: Grouping priority and completion keeps the domain structure lean.
/// 2. Separation of Concerns: This class is responsible for the 'state' of the task, 
///    while TaskContent is responsible for the 'data'.
/// </summary>
public sealed class TaskStatus
{
    private readonly TaskPriority _priority;
    private readonly TaskCompletion _completion;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskStatus"/> class.
    /// </summary>
    public TaskStatus(TaskPriority priority, TaskCompletion completion)
    {
        _priority = priority;
        _completion = completion;
    }

    /// <summary>
    /// Extracts priority and completion for DTO mapping.
    /// </summary>
    public (string Priority, bool IsCompleted) ToDto()
    {
        return (_priority.ToDto(), _completion.ToDto());
    }

    public override bool Equals(object? obj)
    {
        return obj is TaskStatus other && 
               _priority.Equals(other._priority) && 
               _completion.Equals(other._completion);
    }

    public override int GetHashCode() => HashCode.Combine(_priority, _completion);

    public static bool operator ==(TaskStatus? left, TaskStatus? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(TaskStatus? left, TaskStatus? right)
    {
        return !(left == right);
    }
}
