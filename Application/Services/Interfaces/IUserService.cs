using Domain;

namespace Application
{
    public interface IUserService
    {
        public User Create(CreateUserDto createUserDto);
        public User? Update(string id, UpdateUserDto updateUserDto);
        public void Delete(string id);
        public User? GetUnique(string id);
        public List<User?> GetAll();
    }
}
