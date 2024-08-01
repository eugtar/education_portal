namespace Domain
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository() : this("users") { }

        public UserRepository(string name) : base(name) { }

        public User Create(CreateUserDto createUserDto)
        {
            User newUser = new(
                Guid.NewGuid().ToString(),
                createUserDto.FirstName,
                createUserDto.LastName,
                new List<Course>(),
                new List<Course>(),
                new List<Skill>(),
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );


            List<User> users = Read();
            Write([newUser, .. users]);

            return newUser;
        }

        public void Delete(string id)
        {
            List<User> users = Read();
            if (users.Count == 0)
            {
                return;
            }

            int i = users.FindIndex(user => user?.Id == id);

            if (i == -1)
            {
                new NotImplementedException();
            }

            users.RemoveAt(i);
            Write(users);

            return;
        }

        public List<User> GetAll()
        {
            return Read();
        }

        public User GetById(string id)
        {
            throw new NotImplementedException();
        }

        public User Update(string id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}