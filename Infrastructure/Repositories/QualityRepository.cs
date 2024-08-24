using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories;

public class QualityRepository : GenericRepository<Quality>, IQualityRepository
{
    public QualityRepository(DatabaseContext context) : base(context) { }
}
