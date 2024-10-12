using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IEbookService
{
    public Task CreateAsync(CreateEbookDto createEbookDto);
    public Task UpdateAsync(int id, UpdateEbookDto updateEbookDto);
    public Task DeleteAsync(int id);
    public Task<Ebook?> GetByIdAsync(int id);
    public Task<List<Ebook>> GetAllAsync();
}
