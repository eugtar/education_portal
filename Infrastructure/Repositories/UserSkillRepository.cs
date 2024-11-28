using Application.Interfaces;
using Domain.Entities.UserGroup;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories;

public class UserSkillRepository : GenericRepository<UserSkill>, IUserSkillRepository
{
    public UserSkillRepository(DatabaseContext context) : base(context) { }
}
