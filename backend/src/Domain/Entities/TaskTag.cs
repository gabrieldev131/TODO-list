using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskTag - A Value Object that wraps a string representing a task tag.
/// 
/// Study Material - Object Calisthenics:
/// 1. Wrap Primitives (Rule 3): Instead of using a raw string for tags, 
///    we wrap it in a domain-specific class to ensure its meaning is clear 
///    and to provide a place for tag-specific validation if needed.
/// 2. Max 2 instance variables (Rule 7): This class only holds one variable, the tag value.
/// </summary>
public sealed class TaskTag
{
    private readonly string _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskTag"/> class.
    /// </summary>
    /// <param name="value">The string value of the tag.</param>
    /// <exception cref="ArgumentException">Thrown when value is null or whitespace.</exception>
    public TaskTag(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Tag value cannot be empty.", nameof(value));
        }
        _value = value;
    }

    /// <summary>
    /// Extracts the tag value for DTO mapping or display.
    /// Follows the "No Getters" rule by providing a specific method for data extraction.
    /// </summary>
    public string ToDto() => _value;

    public override bool Equals(object? obj)
    {
        return obj is TaskTag other && _value.Equals(other._value, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode() => HashCode.Combine(_value.ToLowerInvariant());

    public override string ToString() => _value;
}
