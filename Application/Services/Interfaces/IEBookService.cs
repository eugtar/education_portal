using Application.Dtos;
using Application.Results;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IEbookService
{
    public Task<Result> CreateAsync(CreateEbookDto dto);
    public Task<Result> UpdateAsync(int id, UpdateEbookDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<Ebook?>> GetByIdAsync(int id);
    public Task<Result<List<Ebook>>> GetAllAsync();
}
