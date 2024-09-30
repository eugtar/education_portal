using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories;

public class SkillRepository : GenericRepository<Skill>, ISkillRepository
{
    public SkillRepository(DatabaseContext context) : base(context) { }
}
