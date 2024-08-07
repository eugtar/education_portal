using Domain;
using Infrastructure;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserService() : this(new GenericRepository<User>("user")) { }

        public UserService(IGenericRepository<User> userRepository)
        {
            _repository = userRepository;
        }

        public User Create(CreateUserDto createUserDto)
        {
            var newUser = new User(
                Guid.NewGuid().ToString(),
                createUserDto.FirstName,
                createUserDto.LastName,
                new List<Course>(),
                new List<Course>(),
                new List<Skill>(),
                DateTime.Now.TimeOfDay,
                DateTime.Now.TimeOfDay
            );

            return _repository.Insert(newUser) ? newUser : throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<User> GetAll()
        {
            var users = _repository.GetAll().ToList();

            return users.Count == 0 ? throw new NotImplementedException() : users;
        }

        public User GetById(string id)
        {
            return _repository.GetById(id) ?? throw new NotImplementedException();
        }

        public User Update(string id, UpdateUserDto updateUserDto)
        {
            var user = _repository.GetById(id) ?? throw new NotImplementedException();

            user.FirstName = updateUserDto.FirstName ?? user.FirstName;
            user.LastName = updateUserDto.LastName ?? user.LastName;
            user.UpdatedAt = DateTime.Now.TimeOfDay;

            return _repository.Update(user) ? user : throw new NotImplementedException();
        }
    }
}
