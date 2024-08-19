using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories;

public class EBookRepository : GenericRepository<EBook>, IEBookRepository
{
    public EBookRepository(DatabaseContext context) : base(context) { }
}
