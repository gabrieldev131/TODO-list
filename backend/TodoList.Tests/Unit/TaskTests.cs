using System;
using TodoList.Api.Domain.Entities;
using Xunit;

namespace TodoList.Tests.Unit
{
    /// <summary>
    /// TaskTests verifies the behavior of our Aggregate Root and its value objects.
    /// 
    /// Object Calisthenics & DDD:
    /// 1. Values are defined by attributes (Value Objects).
    /// 2. Logic is encapsulated within the entity.
    /// 3. We use factory methods or constructors to ensure a valid state.
    /// </summary>
    public class TaskTests : UnitTestsBase
    {
        [Fact]
        public void Task_ShouldReportCorrectIdentifier()
        {
            // Arrange
            var rawId = Guid.NewGuid();
            var id = new TaskIdentifier(rawId);
            var task = CreateDefaultTask(id);

            // Act & Assert
            // Decision: Use Equals override in TaskIdentifier for comparison.
            Assert.True(task.HasIdentifier(id));
        }

        [Fact]
        public void Task_ShouldExtractCorrectTitleAndPriority()
        {
            // Arrange
            var title = "Study Object Calisthenics";
            var priority = "High";
            var task = CreateTaskWith(title, priority);

            // Act
            var extractedTitle = task.ExtractTitle();
            var extractedPriority = task.ExtractPriority();

            // Assert
            // Rationale: We verify that the nested composition (Task -> Aggregate -> LifeCycle -> Details -> Content/Status)
            // correctly bubbles up the data.
            Assert.Equal(title, extractedTitle);
            Assert.Equal(priority, extractedPriority);
        }

        // Helper methods to keep tests clean and readable (Object Calisthenics: one level of indentation).
        private Task CreateDefaultTask(TaskIdentifier id)
        {
            return CreateTaskWith("Test", "Low", id);
        }

        private Task CreateTaskWith(string title, string priority, TaskIdentifier? id = null)
        {
            var taskId = id ?? new TaskIdentifier(Guid.NewGuid());
            
            // Complex nested structure construction to satisfy the 2-variable rule in domain entities.
            var content = new TaskContent(new TaskTitle(title), new TaskDescription("Desc"));
            var status = new TaskStatus(new TaskPriority(priority), new TaskCompletion(false));
            var details = new TaskDetails(content, status);
            var lifeCycle = new TaskLifeCycle(details, new TaskReminder(null));
            var aggregate = new TaskAggregate(lifeCycle, new TaskTags(new List<TaskTag>()));
            
            return new Task(taskId, aggregate);
        }
    }
}
