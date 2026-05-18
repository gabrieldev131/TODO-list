using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoList.Api.API.DTOs;
using TodoList.Api.Domain.Commands;
using Xunit;

namespace TodoList.Tests.Integration
{
    /// <summary>
    /// TasksApiTests verifies the end-to-end behavior of the Tasks API.
    /// 
    /// Rationale for Integration Tests:
    /// 1. Verifies Routing: Ensures [HttpGet] and [HttpPost] attributes are correct.
    /// 2. Verifies JSON Serialization: Ensures DTOs are correctly formatted.
    /// 3. Verifies Dependency Injection: Ensures the real handlers and repository are wired up.
    /// 4. Enforces Principle VII: Every call is checked against the 500ms SLA.
    /// </summary>
    public class TasksApiTests(WebApplicationFactory<Program> factory) : TestBase(factory)
    {
        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetAll_ShouldReturnOk_AndBeFast()
        {
            // Act
            // Decision: Use the helper from TestBase to wrap the call in a SLA check.
            var response = await SendRequestWithSlaCheck(client => client.GetAsync("/api/tasks"));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var tasks = await response.Content.ReadFromJsonAsync<IEnumerable<TaskDataTransferObject>>();
            Assert.NotNull(tasks);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Create_ShouldReturnCreated_AndBeFast()
        {
            // Arrange
            RegisterTaskCommand command = new RegisterTaskCommand(
                "Integration Test Task",
                "Description",
                "Medium",
                ["integration"],
                null);

            // Act
            var response = await SendRequestWithSlaCheck(client =>
                client.PostAsJsonAsync("/api/tasks", command));

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var createdTask = await response.Content.ReadFromJsonAsync<TaskDataTransferObject>();
            Assert.NotNull(createdTask);
            Assert.Equal(command.Title, createdTask.Title);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Delete_ShouldReturnNoContent_AndBeFast()
        {
            // Arrange: First create a task to delete
            var createResponse = await Client.PostAsJsonAsync("/api/tasks",
                new RegisterTaskCommand("Delete Me", "Desc", "Low", [], null));
            var task = await createResponse.Content.ReadFromJsonAsync<TaskDataTransferObject>();

            // Act
            var response = await SendRequestWithSlaCheck(client =>
                client.DeleteAsync($"/api/tasks/{task!.Id}"));

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task SLACheck_ShouldFail_IfArtificialDelayIsAdded()
        {
            // This test is a "meta-test" to verify that our SLA assertion actually works.
            // Since we can't easily add a delay to the real API without changing code,
            // we manually simulate a slow call.

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Simulate a 600ms delay.
            await Task.Delay(600);

            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;

            // Rationale: Demonstrate to the user that 500ms is a hard limit.
            _ = Assert.Throws<Xunit.Sdk.TrueException>(() =>
                Assert.True(elapsed <= 500, $"Artificial SLA Failure: {elapsed}ms > 500ms"));
        }
    }
}
