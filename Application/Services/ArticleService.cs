using Domain.Entities;
using Application.Dtos;
using Application.Services.Interfaces;
using Application.Interfaces;
using Application.Results;

namespace Application.Services;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArticleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> CreateAsync(CreateArticleDto createArticleDto)
    {
        await _unitOfWork.Articles.AddAsync(
            new Article()
            {
                Title = createArticleDto.Title,
                Link = createArticleDto.Link
            });

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var article = await _unitOfWork.Articles.GetByIdAsync(id);

        if (article is not null)
        {
            await _unitOfWork.Articles.RemoveAsync(article);
            await _unitOfWork.CompleteAsync();
        }

        return Result.Success();
    }

    public async Task<List<Article>> GetAllAsync()
    {
        return [.. await _unitOfWork.Articles.GetAllAsync()];
    }

    public async Task<Article?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Articles.GetByIdAsync(id);
    }

    public async Task UpdateAsync(int id, UpdateArticleDto updateArticleDto)
    {
        var article = await _unitOfWork.Articles.GetByIdAsync(id);

        if (article is not null)
        {
            article.Title = updateArticleDto.Title ?? article.Title;
            article.Link = updateArticleDto.Link ?? article.Link;

            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.CompleteAsync();
        }

    }
}
