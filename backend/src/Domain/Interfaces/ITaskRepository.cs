using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Api.Domain.Entities;

namespace TodoList.Api.Domain.Interfaces
{
    /// <summary>
    /// ITaskRepository Interface.
    /// 
    /// SOLID Principle: Dependency Inversion Principle (DIP).
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Retrieves all tasks, optionally sorted by a criteria.
        /// </summary>
        /// <param name="sortBy">The criteria to sort by (e.g., "priority", "title").</param>
        System.Threading.Tasks.Task<IEnumerable<Entities.Task>> GetAllAsync(string? sortBy = null);

        /// <summary>
        /// Adds a new task to the repository.
        /// </summary>
        System.Threading.Tasks.Task AddAsync(Entities.Task task);

        /// <summary>
        /// Removes a task from the repository by its identifier.
        /// </summary>
        System.Threading.Tasks.Task RemoveAsync(TaskIdentifier identifier);
    }
}
