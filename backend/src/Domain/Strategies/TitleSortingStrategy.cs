using System.Collections.Generic;
using System.Linq;
using TodoList.Api.Domain.Entities;

namespace TodoList.Api.Domain.Strategies;

/// <summary>
/// TitleSortingStrategy - Sorts tasks alphabetically by title.
/// 
/// Study Material - Object Calisthenics:
/// 1. Max 2 instance variables: Stateless strategy.
/// </summary>
public sealed class TitleSortingStrategy : ITaskSortingStrategy
{
    public IEnumerable<TodoList.Api.Domain.Entities.Task> Sort(IEnumerable<TodoList.Api.Domain.Entities.Task> tasks)
    {
        return tasks.OrderBy(t => t.ExtractTitle());
    }
}
