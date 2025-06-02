namespace ProductLookupService.Domain.Entities
{
    public class EntityId : IEquatable<EntityId>
    {

        protected EntityId()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }

        public bool Equals(EntityId? other)
        {
            return other is not null && Id.Equals(other.Id);
        }

        public static implicit operator Guid(EntityId entityId)
        {
            return entityId.Id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as EntityId);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
