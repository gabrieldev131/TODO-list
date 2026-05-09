using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Api.API.DTOs;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// Task - The Aggregate Root of the Task domain.
/// 
/// Study Material:
/// 1. Aggregate Root: In DDD, the Aggregate Root is the only way to access the 
///    internal entities of the group. All operations on a task must go through this class.
/// 2. Max 2 instance variables (Rule 7): It only holds its Identifier and its Aggregate. 
///    Everything else is nested within 'Aggregate'.
/// 3. Strategy Pattern Readiness: Provides extraction methods for fields used in sorting.
/// </summary>
public sealed class Task
{
    private readonly TaskIdentifier _id;
    private readonly TaskAggregate _aggregate;

    /// <summary>
    /// Initializes a new instance of the <see cref="Task"/> class.
    /// </summary>
    public Task(TaskIdentifier id, TaskAggregate aggregate)
    {
        _id = id;
        _aggregate = aggregate;
    }

    /// <summary>
    /// Checks if this task is identified by the given <see cref="TaskIdentifier"/>.
    /// </summary>
    public bool HasIdentifier(TaskIdentifier id)
    {
        return _id.Equals(id);
    }

    /// <summary>
    /// Extracts the priority for sorting.
    /// </summary>
    public string ExtractPriority() => _aggregate.ExtractPriority();

    /// <summary>
    /// Extracts the title for sorting.
    /// </summary>
    public string ExtractTitle() => _aggregate.ExtractTitle();

    /// <summary>
    /// Transforms the Domain Aggregate into a Data Transfer Object (DTO).
    /// </summary>
    public TaskDataTransferObject ToDto()
    {
        var idDto = _id.ToDto();
        var (details, tags, reminderAt) = _aggregate.ToDto();
        var detailsDto = details.ToDto();

        return new TaskDataTransferObject(
            idDto,
            detailsDto.Title,
            detailsDto.Description,
            detailsDto.Priority,
            tags,
            reminderAt,
            detailsDto.IsCompleted
        );
    }

    public override bool Equals(object? obj)
    {
        return obj is Task other && 
               _id.Equals(other._id) && 
               _aggregate.Equals(other._aggregate);
    }

    public override int GetHashCode() => HashCode.Combine(_id, _aggregate);
}
