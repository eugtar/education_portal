using Application.Dtos;
using Application.Results;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IArticleService
{
    public Task<Result> CreateAsync(CreateArticleDto dto);
    public Task<Result> UpdateAsync(int id, UpdateArticleDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<Article?>> GetByIdAsync(int id);
    public Task<Result<List<Article>>> GetAllAsync();
}
