using Domain;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService() : this(new UserRepository()) { }

        public UserService(IUserRepository userRepository) 
        {
            _userRepo = userRepository;
        }

        public User Create(CreateUserDto createUserDto)
        {
            return _userRepo.Create(createUserDto);
        }

        public void Delete(string id)
        {
            _userRepo.Delete(id);
        }

        public List<User?> GetAll()
        {
            return _userRepo.GetAll();
        }

        public User? GetUnique(string id)
        {
            throw new NotImplementedException();
        }

        public User? Update(string id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
