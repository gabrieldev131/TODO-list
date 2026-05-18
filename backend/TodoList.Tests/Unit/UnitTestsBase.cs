using NSubstitute;

namespace TodoList.Tests.Unit
{
    /// <summary>
    /// UnitTestsBase ensures that all Unit Tests adhere to Constitution Principles III and IV.
    /// 
    /// Rationale:
    /// 1. Principle IV (Persistence-less): Tests must run entirely in-memory.
    /// 2. Speed: By avoiding IO, we target a suite completion time of < 10s.
    /// </summary>
    public abstract class UnitTestsBase
    {
        // Helper to create mocks consistently using NSubstitute.
        protected T CreateMock<T>() where T : class
        {
            return Substitute.For<T>();
        }
    }
}
