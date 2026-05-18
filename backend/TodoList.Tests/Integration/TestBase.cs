using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TodoList.Tests.Integration
{
    /// <summary>
    /// TestBase provides the foundational infrastructure for API Integration Testing.
    /// 
    /// Rationale for WebApplicationFactory:
    /// By using WebApplicationFactory, we bootstrap the entire API (including Dependency Injection,
    /// Middleware, and Routing) in-memory. This allows for high-fidelity testing that mirrors 
    /// production behavior without the overhead of a real network or external process.
    /// </summary>
    public abstract class TestBase(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient Client = factory.CreateClient();

        /// <summary>
        /// AssertSLA is our implementation of Constitution Principle VII (Performance SLA).
        /// 
        /// Decisions:
        /// 1. Use Stopwatch for high-precision timing.
        /// 2. Measure the entire HTTP roundtrip as seen by the client.
        /// 3. Threshold is hardcoded to 500ms per mandate.
        /// </summary>
        protected async Task<HttpResponseMessage> SendRequestWithSlaCheck(Func<HttpClient, Task<HttpResponseMessage>> requestFunc)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var response = await requestFunc(Client);

            stopwatch.Stop();

            var elapsed = stopwatch.ElapsedMilliseconds;

            // Unambiguous failure if SLA is violated.
            Assert.True(elapsed <= 500, $"Performance SLA Violated: Request took {elapsed}ms (Limit: 500ms)");

            return response;
        }
    }
}
