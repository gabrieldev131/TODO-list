using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using TodoList.Api.Domain.Commands;
using TodoList.Api.Domain.Entities;
using TodoList.Api.Domain.Factories;
using TodoList.Api.Domain.Interfaces;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace TodoList.Tests.Unit
{
    /// <summary>
    /// RegisterTaskCommandHandlerTests demonstrates how to test orchestrators/handlers
    /// using mocks to isolate dependencies.
    /// 
    /// Rationale for Mocking:
    /// We mock ITaskRepository and ITaskFactory because we want to test the HANDLER'S logic,
    /// not the repository's storage or the factory's creation rules.
    /// </summary>
    public class RegisterTaskCommandHandlerTests : UnitTestsBase
    {
        private readonly ITaskRepository _repository;
        private readonly ITaskFactory _factory;
        private readonly RegisterTaskCommandHandler _handler;

        public RegisterTaskCommandHandlerTests()
        {
            _repository = CreateMock<ITaskRepository>();
            _factory = CreateMock<ITaskFactory>();
            _handler = new RegisterTaskCommandHandler(_repository, _factory);
        }

        [Fact]
        public async Task HandleAsync_ShouldInvokeFactoryAndRepository()
        {
            // Arrange
            var command = new RegisterTaskCommand(
                "Learn NSubstitute", 
                "Write tests for the 1-on-1", 
                "High", 
                new List<string> { "testing", "study" }, 
                null);

            // Mock the factory to return a task instance (we don't care about the details here)
            var dummyTask = CreateMockTask();
            _factory.Create(command.Title, command.Description, command.Priority, command.Tags, command.ReminderAt)
                    .Returns(dummyTask);

            // Act
            var result = await _handler.HandleAsync(command);

            // Assert
            // Rationale: We verify that the handler correctly coordinated the work.
            await _repository.Received(1).AddAsync(dummyTask);
            Assert.Same(dummyTask, result);
        }

        private TodoList.Api.Domain.Entities.Task CreateMockTask()
        {
            // We use a mock here as well to satisfy the return type without building the full aggregate.
            return Substitute.For<TodoList.Api.Domain.Entities.Task>(
                new TaskIdentifier(Guid.NewGuid()), 
                Substitute.For<TaskAggregate>(
                    Substitute.For<TaskLifeCycle>(
                        Substitute.For<TaskDetails>(
                            Substitute.For<TaskContent>(new TaskTitle("T"), new TaskDescription("D")),
                            Substitute.For<TodoList.Api.Domain.Entities.TaskStatus>(new TaskPriority("L"), new TaskCompletion(false))
                        ),
                        new TaskReminder(null)
                    ),
                    new TaskTags(new List<TaskTag>())
                )
            );
        }
    }
}
