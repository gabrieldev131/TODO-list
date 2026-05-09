using System.Threading.Tasks;
using TodoList.Api.Domain.Entities;
using TodoList.Api.Domain.Factories;
using TodoList.Api.Domain.Interfaces;

namespace TodoList.Api.Domain.Commands
{
    /// <summary>
    /// RegisterTaskCommandHandler Implementation.
    /// 
    /// Study Material:
    /// 1. Command Pattern: This class is a "Receiver" handler for the RegisterTaskCommand.
    ///    It encapsulates the logic of what happens when a task is registered.
    /// 2. SRP (Single Responsibility): This class has only ONE reason to change: 
    ///    if the process of registering a task changes.
    /// 3. DIP (Dependency Inversion): It depends on ITaskRepository and ITaskFactory,
    ///    not on concrete SQL repositories or specific factory implementations.
    /// 4. Object Calisthenics (Max 2 instance variables): Only holds the repository and the factory.
    /// </summary>
    public class RegisterTaskCommandHandler : ITaskCommandHandler<RegisterTaskCommand, TodoList.Api.Domain.Entities.Task>
    {
        private readonly ITaskRepository _repository;
        private readonly ITaskFactory _factory;

        public RegisterTaskCommandHandler(ITaskRepository repository, ITaskFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        /// <summary>
        /// Handles the registration of a new task.
        /// </summary>
        public async System.Threading.Tasks.Task<TodoList.Api.Domain.Entities.Task> HandleAsync(RegisterTaskCommand command)
        {
            // The factory handles the complex creation including tags and reminders,
            // abstracting away the instantiation logic from the handler.
            var newTask = _factory.Create(command.Title, command.Description, command.Priority, command.Tags, command.ReminderAt);
            
            await _repository.AddAsync(newTask);

            return newTask;
        }
    }
}
