using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskTitle - A Value Object wrapping the string title of a Task.
/// 
/// Study Material - Object Calisthenics:
/// 1. Wrap all primitives (Rule 3): Ensures that a title is not just any string, 
///    but one that adheres to domain invariants (like being non-empty).
/// 2. No Getters/Setters: Use 'ToDto()' to expose the value for external layers.
/// 3. Immutability: The title cannot be changed once created. To "change" a title, 
///    a new instance must be created.
/// </summary>
public sealed class TaskTitle
{
    private readonly string _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskTitle"/> class.
    /// </summary>
    /// <param name="value">The title string.</param>
    /// <exception cref="ArgumentException">Thrown when the value is null or empty.</exception>
    public TaskTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Title cannot be empty.");
        }
        _value = value;
    }

    /// <summary>
    /// Extracts the primitive value for DTO mapping.
    /// </summary>
    public string ToDto() => _value;

    /// <summary>
    /// Compares two TaskTitle objects based on their value.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is TaskTitle other && _value == other._value;
    }

    /// <summary>
    /// Gets the hash code for the title.
    /// </summary>
    public override int GetHashCode() => _value.GetHashCode();

    /// <summary>
    /// Returns the title string.
    /// </summary>
    public override string ToString() => _value;

    public static bool operator ==(TaskTitle? left, TaskTitle? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(TaskTitle? left, TaskTitle? right)
    {
        return !(left == right);
    }
}
