using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskContent - Composes the Title and Description of a Task.
/// 
/// Study Material - Object Calisthenics:
/// 1. Max 2 instance variables (Rule 7): By grouping Title and Description into 'Content', 
///    we keep the 'Task' entity simple while maintaining high cohesion.
/// 2. No Getters/Setters: Instead of exposing _title and _description, we provide 
///    a 'ToDto' method that extracts the necessary data for the UI.
/// </summary>
public sealed class TaskContent
{
    private readonly TaskTitle _title;
    private readonly TaskDescription _description;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskContent"/> class.
    /// </summary>
    public TaskContent(TaskTitle title, TaskDescription description)
    {
        _title = title;
        _description = description;
    }

    /// <summary>
    /// Extracts the title and description for DTO mapping.
    /// Returns a tuple to avoid creating a new specific class while still 
    /// complying with the "No Getters" rule.
    /// </summary>
    public (string Title, string Description) ToDto()
    {
        return (_title.ToDto(), _description.ToDto());
    }

    public override bool Equals(object? obj)
    {
        return obj is TaskContent other && 
               _title.Equals(other._title) && 
               _description.Equals(other._description);
    }

    public override int GetHashCode() => HashCode.Combine(_title, _description);

    public static bool operator ==(TaskContent? left, TaskContent? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(TaskContent? left, TaskContent? right)
    {
        return !(left == right);
    }
}
