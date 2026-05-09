using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Api.Domain.Entities;

namespace TodoList.Api.Domain.Factories
{
    /// <summary>
    /// ITaskFactory Interface.
    /// </summary>
    public interface ITaskFactory
    {
        TodoList.Api.Domain.Entities.Task Create(string title, string description, string priority, IEnumerable<string> tags, DateTime? reminderAt);
    }

    /// <summary>
    /// SimpleTaskFactory Implementation.
    /// 
    /// Study Material:
    /// 1. Factory Pattern: Centralizes the creation logic for a complex Aggregate (Task).
    ///    This prevents the Domain logic from being cluttered with 'new' keywords 
    ///    and orchestration details.
    /// 2. Object Calisthenics - Wrap Primitives: Every input string/date is wrapped 
    ///    immediately into a Value Object (TaskTitle, TaskDescription, etc.).
    /// 3. Object Calisthenics - No 'else': The ParsePriority method avoids 'else' by 
    ///    using early returns or default values.
    /// 4. Composition over Inheritance: Instead of a deep hierarchy, the Task is 
    ///    built by composing small, focused objects.
    /// </summary>
    public class SimpleTaskFactory : ITaskFactory
    {
        /// <summary>
        /// Creates a fully initialized Task aggregate.
        /// </summary>
        public TodoList.Api.Domain.Entities.Task Create(string title, string description, string priority, IEnumerable<string> tags, DateTime? reminderAt)
        {
            // OC Rule: Wrap all primitives
            var identifier = new TaskIdentifier(Guid.NewGuid());
            var taskTitle = new TaskTitle(title);
            var taskDescription = new TaskDescription(description);
            var taskPriority = ParsePriority(priority);
            var taskReminder = new TaskReminder(reminderAt);

            // OC Rule: Max 2 instance variables (facilitated by composition)
            var content = new TaskContent(taskTitle, taskDescription);
            var status = new TodoList.Api.Domain.Entities.TaskStatus(taskPriority, new TaskCompletion(false));
            var details = new TaskDetails(content, status);

            var lifeCycle = new TaskLifeCycle(details, taskReminder);

            // First-Class Collections
            var taskTags = new TaskTags(tags.Select(t => new TaskTag(t)).ToList());
            
            // Final Aggregate composition
            var aggregate = new TaskAggregate(lifeCycle, taskTags);

            return new TodoList.Api.Domain.Entities.Task(identifier, aggregate);
        }

        /// <summary>
        /// Parses priority avoiding the 'else' keyword.
        /// </summary>
        private TaskPriority ParsePriority(string priority)
        {
            if (Enum.TryParse<PriorityLevel>(priority, true, out var result))
            {
                return new TaskPriority(result);
            }

            return new TaskPriority(PriorityLevel.Medium);
        }
    }
}

