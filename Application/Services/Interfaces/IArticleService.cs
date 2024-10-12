using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IArticleService
{
    public Task CreateAsync(CreateArticleDto createArticleDto);
    public Task UpdateAsync(int id, UpdateArticleDto updateArticleDto);
    public Task DeleteAsync(int id);
    public Task<Article?> GetByIdAsync(int id);
    public Task<List<Article>> GetAllAsync();
}
