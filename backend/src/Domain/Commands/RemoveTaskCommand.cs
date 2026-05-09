using System;

namespace TodoList.Api.Domain.Commands
{
    /// <summary>
    /// RemoveTaskCommand.
    /// </summary>
    public class RemoveTaskCommand : ITaskCommand
    {
        public Guid Identifier { get; }

        public RemoveTaskCommand(Guid identifier)
        {
            Identifier = identifier;
        }
    }
}
