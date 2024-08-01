namespace Domain
{
    public interface IUserRepository
    {
        public User Create(CreateUserDto createUserDto);
        public User Update(string id, UpdateUserDto updateUserDto);
        public void Delete(string id);
        public User GetById(string id);
        public List<User> GetAll();
    }
}
