using TodoList.Api.Domain.Commands;
using TodoList.Api.Domain.Entities;

namespace TodoList.Api.Domain.Interfaces
{
    /// <summary>
    /// TaskCommandHandlerBundle.
    /// 
    /// Object Calisthenics: Used to aggregate related dependencies while maintaining 
    /// the "Max 2 instance variables" rule in the Controller.
    /// </summary>
    public class TaskCommandHandlerBundle
    {
        public ITaskCommandHandler<RegisterTaskCommand, Entities.Task> RegisterHandler { get; }
        public ITaskCommandHandler<RemoveTaskCommand> RemoveHandler { get; }

        public TaskCommandHandlerBundle(
            ITaskCommandHandler<RegisterTaskCommand, Entities.Task> registerHandler,
            ITaskCommandHandler<RemoveTaskCommand> removeHandler)
        {
            RegisterHandler = registerHandler;
            RemoveHandler = removeHandler;
        }
    }
}
