using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// Defines the priority levels available for a Task.
/// </summary>
public enum PriorityLevel
{
    Low,
    Medium,
    High
}

/// <summary>
/// TaskPriority - A Value Object wrapping the PriorityLevel enum.
/// 
/// Study Material:
/// 1. Wrap all primitives (Rule 3): Enums are primitives. Wrapping them allows us to 
///    add behavior (like checking if a priority is 'High') without cluttering the Task entity.
/// 2. Separation of Concerns: The logic for how a priority is represented (string, int, etc.) 
///    is kept here.
/// </summary>
public sealed class TaskPriority
{
    private readonly PriorityLevel _level;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskPriority"/> class.
    /// </summary>
    public TaskPriority(PriorityLevel level)
    {
        _level = level;
    }

    /// <summary>
    /// Converts the priority level to a string for DTO representation.
    /// </summary>
    public string ToDto() => _level.ToString();

    /// <summary>
    /// Compares two TaskPriority objects.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is TaskPriority other && _level == other._level;
    }

    /// <summary>
    /// Gets the hash code for the priority level.
    /// </summary>
    public override int GetHashCode() => _level.GetHashCode();

    public static bool operator ==(TaskPriority? left, TaskPriority? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(TaskPriority? left, TaskPriority? right)
    {
        return !(left == right);
    }
}
