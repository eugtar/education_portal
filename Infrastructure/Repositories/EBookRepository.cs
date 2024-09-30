using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository;

namespace Infrastructure.Repositories;

public class EbookRepository : GenericRepository<Ebook>, IEbookRepository
{
    public EbookRepository(DatabaseContext context) : base(context) { }
}
