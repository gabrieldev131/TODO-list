using System;
using System.Collections.Generic;
using TodoList.Api.Domain.Entities;

namespace TodoList.Api.Domain.Strategies;

/// <summary>
/// TaskSortingContext - The Strategy picker.
/// 
/// Study Material:
/// 1. Strategy Pattern: This class acts as the "Context". It maintains a reference 
///    to multiple Strategy objects and can switch between them at runtime based on 
///    the 'criteria' parameter. This makes the sorting logic Open for extension 
///    (new strategies) but Closed for modification.
/// 2. Object Calisthenics - No 'else' keyword (Rule 2): Instead of a long if-else 
///    chain checking 'criteria == "priority"', we use a Dictionary lookup.
/// 3. Object Calisthenics - Max 2 instance variables (Rule 7): Only holds the strategy map.
/// </summary>
public sealed class TaskSortingContext
{
    private readonly IDictionary<string, ITaskSortingStrategy> _strategies;

    public TaskSortingContext()
    {
        // Polymorphism in action: multiple implementations of ITaskSortingStrategy
        _strategies = new Dictionary<string, ITaskSortingStrategy>(StringComparer.OrdinalIgnoreCase)
        {
            { "priority", new PrioritySortingStrategy() },
            { "title", new TitleSortingStrategy() }
        };
    }

    /// <summary>
    /// Sorts the tasks based on the provided criteria name.
    /// If criteria is not found, it returns the tasks unsorted (Default Strategy).
    /// </summary>
    public IEnumerable<TodoList.Api.Domain.Entities.Task> Sort(IEnumerable<TodoList.Api.Domain.Entities.Task> tasks, string? criteria)
    {
        // Early return pattern to avoid 'else' and deep nesting
        if (criteria != null && _strategies.TryGetValue(criteria, out var strategy))
        {
            return strategy.Sort(tasks);
        }

        return tasks; // Default: No sorting or preserve original order
    }
}
