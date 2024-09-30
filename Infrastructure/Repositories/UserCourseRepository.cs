using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories;

public class UserCourseRepository : GenericRepository<UserCourse>, IUserCourseRepository
{
    public UserCourseRepository(DatabaseContext context) : base(context) { }
}
