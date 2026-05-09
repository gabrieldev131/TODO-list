using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskTags - A collection wrapper for task tags.
/// 
/// Study Material - Object Calisthenics:
/// 1. First-Class Collections (Rule 8): Any class that contains a collection should 
///    contain no other member variables. This encapsulates collection logic and 
///    provides a place for domain-specific operations (like ensuring uniqueness).
/// 2. Max 2 instance variables (Rule 7): Only holds the collection itself.
/// </summary>
public sealed class TaskTags
{
    private readonly IEnumerable<TaskTag> _tags;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskTags"/> class.
    /// </summary>
    /// <param name="tags">The initial set of tags.</param>
    public TaskTags(IEnumerable<TaskTag> tags)
    {
        _tags = tags.Distinct().ToList();
    }

    /// <summary>
    /// Extracts the tags as strings for DTO mapping.
    /// </summary>
    public IEnumerable<string> ToDto() => _tags.Select(t => t.ToDto());

    /// <summary>
    /// Returns an empty set of tags.
    /// </summary>
    public static TaskTags Empty() => new TaskTags(Enumerable.Empty<TaskTag>());

    public override bool Equals(object? obj)
    {
        return obj is TaskTags other && _tags.SequenceEqual(other._tags);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var tag in _tags)
        {
            hash.Add(tag);
        }
        return hash.ToHashCode();
    }
}
