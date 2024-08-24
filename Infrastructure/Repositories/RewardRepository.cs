using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories;

public class RewardRepository : GenericRepository<Reward>, IRewardRepository
{
    public RewardRepository(DatabaseContext context) : base(context) { }
}
