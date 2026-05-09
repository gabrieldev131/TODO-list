using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Domain.Entities;
using TodoList.Api.Domain.Interfaces;
using TodoList.Api.Domain.Strategies;

namespace TodoList.Api.Infrastructure.Persistence
{
    /// <summary>
    /// InMemoryTaskRepository Implementation.
    /// </summary>
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TodoList.Api.Domain.Entities.Task> _tasks = new();
        private readonly TaskSortingContext _sortingContext;

        public InMemoryTaskRepository(TaskSortingContext sortingContext)
        {
            _sortingContext = sortingContext;
        }

        public System.Threading.Tasks.Task<IEnumerable<TodoList.Api.Domain.Entities.Task>> GetAllAsync(string? sortBy = null)
        {
            lock (_tasks)
            {
                // Apply sorting strategy via context (Strategy Pattern)
                var sortedTasks = _sortingContext.Sort(_tasks, sortBy);
                return System.Threading.Tasks.Task.FromResult(sortedTasks);
            }
        }

        public System.Threading.Tasks.Task AddAsync(TodoList.Api.Domain.Entities.Task task)
        {
            lock (_tasks)
            {
                _tasks.Add(task);
                return System.Threading.Tasks.Task.CompletedTask;
            }
        }

        public System.Threading.Tasks.Task RemoveAsync(TaskIdentifier identifier)
        {
            lock (_tasks)
            {
                var taskToRemove = _tasks.FirstOrDefault(t => t.HasIdentifier(identifier));
                
                RemoveIfFound(taskToRemove);
                
                return System.Threading.Tasks.Task.CompletedTask;
            }
        }

        private void RemoveIfFound(TodoList.Api.Domain.Entities.Task? task)
        {
            if (task is null) return;
            _tasks.Remove(task);
        }
    }
}
