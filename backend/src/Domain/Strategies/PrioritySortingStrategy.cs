using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Api.Domain.Entities;

namespace TodoList.Api.Domain.Strategies;

/// <summary>
/// PrioritySortingStrategy - Sorts tasks by their priority level.
/// 
/// Study Material - Object Calisthenics:
/// 1. No 'else' keyword (Rule 2): Sorting logic uses LINQ which avoids explicit 
///    branching and 'else' statements.
/// 2. Max 2 instance variables: Stateless strategy, has zero instance variables.
/// </summary>
public sealed class PrioritySortingStrategy : ITaskSortingStrategy
{
    /// <summary>
    /// Sorts tasks by priority. 
    /// Note: Implementation depends on how priority strings are ordered.
    /// In this case, we rely on the domain entity to provide a sortable representation.
    /// </summary>
    public IEnumerable<TodoList.Api.Domain.Entities.Task> Sort(IEnumerable<TodoList.Api.Domain.Entities.Task> tasks)
    {
        return tasks.OrderByDescending(t => t.ExtractPriority());
    }
}
