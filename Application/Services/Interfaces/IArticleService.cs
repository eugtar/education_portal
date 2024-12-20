using Application.Dtos.ArticleDtos;
using Application.Results;

namespace Application.Services.Interfaces;

public interface IArticleService
{
    public Task<Result> CreateAsync(CreateArticleDto dto);
    public Task<Result> UpdateAsync(int id, UpdateArticleDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<ArticleDto>> GetByIdAsync(int id);
    public Task<Result<List<ArticleDto>>> GetAllAsync();
}
