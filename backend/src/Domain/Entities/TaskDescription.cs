using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskDescription - A Value Object wrapping the string description of a Task.
/// 
/// Study Material - SOLID & Object Calisthenics:
/// 1. Open/Closed Principle: By wrapping even simple strings, we can add validation 
///    or formatting logic later without changing the Task entity's structure.
/// 2. Wrap all primitives: Prevents passing a Title where a Description is expected.
/// 3. Small classes (Rule 7): Keeps the domain logic granular and focused.
/// </summary>
public sealed class TaskDescription
{
    private readonly string _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskDescription"/> class.
    /// </summary>
    /// <param name="value">The description string.</param>
    public TaskDescription(string value)
    {
        _value = value ?? string.Empty;
    }

    /// <summary>
    /// Extracts the primitive value for DTO mapping.
    /// </summary>
    public string ToDto() => _value;

    /// <summary>
    /// Compares two TaskDescription objects based on their value.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is TaskDescription other && _value == other._value;
    }

    /// <summary>
    /// Gets the hash code for the description.
    /// </summary>
    public override int GetHashCode() => _value.GetHashCode();

    /// <summary>
    /// Returns the description string.
    /// </summary>
    public override string ToString() => _value;

    public static bool operator ==(TaskDescription? left, TaskDescription? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(TaskDescription? left, TaskDescription? right)
    {
        return !(left == right);
    }
}
