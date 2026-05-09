using System.Threading.Tasks;
using TodoList.Api.Domain.Entities;
using TodoList.Api.Domain.Interfaces;

namespace TodoList.Api.Domain.Commands
{
    /// <summary>
    /// RemoveTaskCommandHandler Implementation.
    /// </summary>
    public class RemoveTaskCommandHandler : ITaskCommandHandler<RemoveTaskCommand>
    {
        private readonly ITaskRepository _repository;

        public RemoveTaskCommandHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async System.Threading.Tasks.Task HandleAsync(RemoveTaskCommand command)
        {
            var identifier = new TaskIdentifier(command.Identifier);
            
            await _repository.RemoveAsync(identifier);
        }
    }
}
