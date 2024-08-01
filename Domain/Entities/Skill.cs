namespace Domain {
    public class Skill : BaseEntity
    {
        public string Name { get; set; }

        public Skill(
            string id,
            string name,
            TimeSpan createdAt,
            TimeSpan updatedAt
        ) : base(id, createdAt, updatedAt)
        {
            Name = name;
        }
    }
}