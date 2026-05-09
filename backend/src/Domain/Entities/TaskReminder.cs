using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskReminder - A Value Object wrapping the optional reminder date and time.
/// 
/// Study Material - Object Calisthenics:
/// 1. Wrap Primitives (Rule 3): Instead of using a raw DateTime? everywhere, 
///    we wrap it in a meaningful domain concept.
/// </summary>
public sealed class TaskReminder
{
    private readonly DateTime? _reminderAt;

    public TaskReminder(DateTime? reminderAt)
    {
        _reminderAt = reminderAt;
    }

    public DateTime? ToDto() => _reminderAt;

    public override bool Equals(object? obj)
    {
        return obj is TaskReminder other && _reminderAt == other._reminderAt;
    }

    public override int GetHashCode() => _reminderAt?.GetHashCode() ?? 0;

    public static bool operator ==(TaskReminder? left, TaskReminder? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(TaskReminder? left, TaskReminder? right)
    {
        return !(left == right);
    }
}
