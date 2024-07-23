

namespace Domain {
    public class User : BaseEntity<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course?> ProceedingCourses { get; private set; }
        public List<Course?> CompletedCourses { get; private set; }
        public List<Skill?> Rewards { get; private set; }

        public User(
            string id,
            string firstName,
            string lastName,
            List<Course?> proceedingCourses,
            List<Course?> completedCourses,
            List<Skill?> rewards,
            TimeSpan createdAt,
            TimeSpan updatedAt
        ) : base(id, createdAt, updatedAt)
        {
            FirstName = firstName;
            LastName = lastName;
            ProceedingCourses = proceedingCourses;
            CompletedCourses = completedCourses;
            Rewards = rewards;
        }

        public void Deconstruct(
            out string id,
            out string firstName,
            out string lastName,
            out List<Course?> proceedingCourses,
            out List<Course?> completedCourses,
            out List<Skill?> rewards,
            out TimeSpan createdAt,
            out TimeSpan updatedAt
        )
        {
            base.Deconstruct(out id, out createdAt, out updatedAt);
            firstName = FirstName;
            lastName = LastName;
            proceedingCourses = ProceedingCourses;
            completedCourses = CompletedCourses;
            rewards = Rewards;
        }
    }
}