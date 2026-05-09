using System.Collections.Generic;

namespace TodoList.Api.Domain.Commands
{
    /// <summary>
    /// RegisterTaskCommand.
    /// </summary>
    public class RegisterTaskCommand : ITaskCommand
    {
        public string Title { get; }
        public string Description { get; }
        public string Priority { get; }
        public IEnumerable<string> Tags { get; }
        public System.DateTime? ReminderAt { get; }

        public RegisterTaskCommand(string title, string description, string priority, IEnumerable<string>? tags = null, System.DateTime? reminderAt = null)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Tags = tags ?? new List<string>();
            ReminderAt = reminderAt;
        }
    }
}
