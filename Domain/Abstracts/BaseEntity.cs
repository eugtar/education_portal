namespace Domain{
    public abstract class BaseEntity<T> where T : notnull
    {
        public T Id { get; protected set; }
        public TimeSpan CreatedAt { get; protected set; }
        public TimeSpan UpdatedAt { get; set; }

        public BaseEntity(T id, TimeSpan createdAt, TimeSpan updatedAt)
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        public void Deconstruct(
            out T id,
            out TimeSpan createdAt,
            out TimeSpan updatedAt
        )
        {
            id = Id;
            createdAt = CreatedAt;
            updatedAt = UpdatedAt;
        }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}