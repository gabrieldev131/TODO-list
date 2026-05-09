using System.Collections.Generic;
using TodoList.Api.Domain.Entities;

namespace TodoList.Api.Domain.Strategies;

/// <summary>
/// ITaskSortingStrategy - Interface for the Strategy pattern.
/// 
/// Study Material - SOLID:
/// 1. Open/Closed Principle (OCP): This interface allows adding new sorting 
///    algorithms (strategies) without modifying the TaskRepository or TaskController.
/// 2. Strategy Pattern: Defines a family of algorithms, encapsulates each one, 
///    and makes them interchangeable.
/// </summary>
public interface ITaskSortingStrategy
{
    /// <summary>
    /// Sorts a collection of tasks.
    /// </summary>
    /// <param name="tasks">The tasks to sort.</param>
    /// <returns>A sorted collection of tasks.</returns>
    IEnumerable<TodoList.Api.Domain.Entities.Task> Sort(IEnumerable<TodoList.Api.Domain.Entities.Task> tasks);
}
