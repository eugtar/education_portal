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
            return _repository.Create(createUserDto);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
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
