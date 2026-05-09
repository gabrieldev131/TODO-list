using System;

namespace TodoList.Api.Domain.Entities;

/// <summary>
/// TaskIdentifier - A Value Object representing the unique identity of a Task.
/// 
/// Study Material - Domain-Driven Design (DDD) & Object Calisthenics:
/// 1. Wrap all primitives (Rule 3): Instead of using a raw Guid, we use this class.
///    This prevents "Primitive Obsession" where IDs for different entities (User, Task, Order) 
///    could be accidentally swapped.
/// 2. Immutability: The _value is 'readonly', ensuring that once an identity is assigned, 
///    it cannot change.
/// 3. No Getters/Setters (Rule 9): We use the 'ToDto()' method for data extraction 
///    and 'Equals' for comparisons, keeping the state encapsulated.
/// </summary>
public sealed class TaskIdentifier
{
    private readonly Guid _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskIdentifier"/> class.
    /// </summary>
    /// <param name="value">The raw Guid value.</param>
    public TaskIdentifier(Guid value)
    {
        _value = value;
    }

    /// <summary>
    /// Extracts the primitive value for DTO mapping.
    /// This follows the rule of not using getters while still allowing the 
    /// persistence or API layer to access the necessary data.
    /// </summary>
    /// <returns>The raw Guid.</returns>
    public Guid ToDto() => _value;

    /// <summary>
    /// Checks if this identifier is equal to another.
    /// Value Objects are defined by their attributes, not their memory address.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is TaskIdentifier other && _value.Equals(other._value);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    public override int GetHashCode() => _value.GetHashCode();

    /// <summary>
    /// Operator overload for equality comparison.
    /// </summary>
    public static bool operator ==(TaskIdentifier? left, TaskIdentifier? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    /// <summary>
    /// Operator overload for inequality comparison.
    /// </summary>
    public static bool operator !=(TaskIdentifier? left, TaskIdentifier? right)
    {
        return !(left == right);
    }
}
