using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskLifeCycle - Composes TaskDetails and TaskReminder.
/// 
/// Study Material - Object Calisthenics:
/// 1. Max 2 instance variables: Grouping details and reminder to respect the limit.
/// </summary>
public sealed class TaskLifeCycle
{
    private readonly TaskDetails _details;
    private readonly TaskReminder _reminder;

    public TaskLifeCycle(TaskDetails details, TaskReminder reminder)
    {
        _details = details;
        _reminder = reminder;
    }

    public (TaskDetails Details, DateTime? ReminderAt) ToDto()
    {
        return (_details, _reminder.ToDto());
    }

    public TaskDetails Details => _details;

    public override bool Equals(object? obj)
    {
        return obj is TaskLifeCycle other && 
               _details.Equals(other._details) && 
               _reminder.Equals(other._reminder);
    }

    public override int GetHashCode() => HashCode.Combine(_details, _reminder);
}
