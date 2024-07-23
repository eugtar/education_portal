namespace Domain {
    public class Skill : BaseEntity<string>
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

        public void Deconstruct(
            out string id,
            out string name,
            out TimeSpan createdAt,
            out TimeSpan updatedAt
        )
        {
            base.Deconstruct(out id, out createdAt, out updatedAt);
            name = Name;
        }
    }
}