using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskCompletion - A Value Object wrapping the boolean completion status.
/// 
/// Study Material:
/// 1. Wrap all primitives: 'bool' is a primitive. Wrapping it allows for semantic methods 
///    like 'Incomplete()' and 'Completed()', making the code more readable than raw booleans.
/// 2. Expressive Domain: Methods like 'Incomplete()' act as factories that reveal intent.
/// </summary>
public sealed class TaskCompletion
{
    private readonly bool _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskCompletion"/> class.
    /// </summary>
    public TaskCompletion(bool value)
    {
        _value = value;
    }

    /// <summary>
    /// Creates a new instance representing an incomplete task.
    /// </summary>
    public static TaskCompletion Incomplete() => new(false);

    /// <summary>
    /// Creates a new instance representing a completed task.
    /// </summary>
    public static TaskCompletion Completed() => new(true);

    /// <summary>
    /// Extracts the primitive value for DTO mapping.
    /// </summary>
    public bool ToDto() => _value;

    public override bool Equals(object? obj)
    {
        return obj is TaskCompletion other && _value == other._value;
    }

    public override int GetHashCode() => _value.GetHashCode();

    public static bool operator ==(TaskCompletion? left, TaskCompletion? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(TaskCompletion? left, TaskCompletion? right)
    {
        return !(left == right);
    }
}
