using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories;

public class FormatRepository : GenericRepository<Format>, IFormatRepository
{
    public FormatRepository(DatabaseContext context) : base(context) { }
}
