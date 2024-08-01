

namespace Domain {
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course> ProceedingCourses { get; private set; }
        public List<Course> CompletedCourses { get; private set; }
        public List<Skill> Rewards { get; private set; }

        public User(
            string id,
            string firstName,
            string lastName,
            List<Course> proceedingCourses,
            List<Course> completedCourses,
            List<Skill> rewards,
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
    }
}