using System.Threading.Tasks;

namespace TodoList.Api.Domain.Commands
{
    /// <summary>
    /// ITaskCommand Interface.
    /// 
    /// Command Pattern: Marker interface for task-related commands.
    /// </summary>
    public interface ITaskCommand { }

    /// <summary>
    /// ITaskCommandHandler Interface.
    /// 
    /// SOLID Principle: Interface Segregation Principle (ISP).
    /// By separating the handler from the command, we ensure that each class has a 
    /// single reason to change (SRP).
    /// </summary>
    /// <typeparam name="TCommand">The type of command to handle.</typeparam>
    public interface ITaskCommandHandler<in TCommand> where TCommand : ITaskCommand
    {
        Task HandleAsync(TCommand command);
    }

    /// <summary>
    /// ITaskCommandHandler with Result.
    /// </summary>
    public interface ITaskCommandHandler<in TCommand, TResult> where TCommand : ITaskCommand
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
