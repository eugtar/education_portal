namespace Domain{
    public abstract class BaseEntity
    {
        public string Id { get; protected set; }
        public TimeSpan CreatedAt { get; protected set; }
        public TimeSpan UpdatedAt { get; set; }

        public BaseEntity(string id, TimeSpan createdAt, TimeSpan updatedAt)
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}