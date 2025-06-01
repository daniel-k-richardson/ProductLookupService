namespace ProductLookupService.Domain.Entities;

public class EntityId : IEquatable<EntityId>
{
   public Guid Id { get; }

    protected EntityId()
    {
        Id = Guid.NewGuid();
    }

    public static implicit operator Guid(EntityId entityId) => entityId.Id;

    public override string ToString() => Id.ToString();

    public bool Equals(EntityId? other)
    {
        return other is not null && Id.Equals(other.Id);
    }

    public override bool Equals(object? obj) => Equals(obj as EntityId);

    public override int GetHashCode() => Id.GetHashCode();
}
