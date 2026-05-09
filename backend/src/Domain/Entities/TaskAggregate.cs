using System;
using System.Collections.Generic;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskAggregate - Composes TaskDetails and TaskTags.
/// 
/// Study Material - Object Calisthenics:
/// 1. Max 2 instance variables (Rule 7): By grouping details and tags, we maintain 
///    the limit while providing access to both.
/// 2. Composition: Demonstrates hierarchical composition to manage complexity.
/// </summary>
public sealed class TaskAggregate
{
    private readonly TaskLifeCycle _lifeCycle;
    private readonly TaskTags _tags;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskAggregate"/> class.
    /// </summary>
    public TaskAggregate(TaskLifeCycle lifeCycle, TaskTags tags)
    {
        _lifeCycle = lifeCycle;
        _tags = tags;
    }

    /// <summary>
    /// Extracts the details and tags for DTO mapping.
    /// </summary>
    public (TaskDetails Details, IEnumerable<string> Tags, DateTime? ReminderAt) ToDto()
    {
        var (details, reminderAt) = _lifeCycle.ToDto();
        return (details, _tags.ToDto(), reminderAt);
    }

    /// <summary>
    /// Provides access to the priority for sorting purposes.
    /// Following Object Calisthenics, we avoid naked getters and instead provide 
    /// a way to extract the information needed.
    /// </summary>
    public string ExtractPriority()
    {
        var detailsDto = _lifeCycle.Details.ToDto();
        return detailsDto.Priority;
    }

    /// <summary>
    /// Provides access to the title for sorting purposes.
    /// </summary>
    public string ExtractTitle()
    {
        var detailsDto = _lifeCycle.Details.ToDto();
        return detailsDto.Title;
    }

    public override bool Equals(object? obj)
    {
        return obj is TaskAggregate other && 
               _lifeCycle.Equals(other._lifeCycle) && 
               _tags.Equals(other._tags);
    }

    public override int GetHashCode() => HashCode.Combine(_lifeCycle, _tags);
}
