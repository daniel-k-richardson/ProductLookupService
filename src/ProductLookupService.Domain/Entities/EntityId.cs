namespace ProductLookupService.Domain.Entities;

public class EntityId : IEquatable<EntityId>
{
   public Guid Value { get; }

    protected EntityId()
    {
        Value = Guid.NewGuid();
    }

    public static implicit operator Guid(EntityId entityId) => entityId.Value;

    public override string ToString() => Value.ToString();

    public bool Equals(EntityId? other)
    {
        return other is not null && Value.Equals(other.Value);
    }

    public override bool Equals(object? obj) => Equals(obj as EntityId);

    public override int GetHashCode() => Value.GetHashCode();
}
