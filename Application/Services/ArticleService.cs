using Domain.Entities;
using Application.Services.Interfaces;
using Application.Interfaces;
using Application.Results;
using System.Net;
using Application.Dtos.ArticleDtos;

namespace Application.Services;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArticleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> CreateAsync(CreateArticleDto dto)
    {
        await _unitOfWork.Articles.AddAsync(
            new Article()
            {
                Title = dto.Title,
                Link = dto.Link
            });

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var article = await _unitOfWork.Articles.GetByIdAsync(id);

        if (article is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Article with ID: {id} not found");
        }

        await _unitOfWork.Articles.RemoveAsync(article);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result<List<ArticleDto>>> GetAllAsync()
    {
        var articles = await _unitOfWork.Articles.GetAllAsync();

        if (articles.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return articles.Select(a => ArticleDto.MapToView(a)).ToList();
    }

    public async Task<Result<ArticleDto>> GetByIdAsync(int id)
    {
        var article = await _unitOfWork.Articles.GetByIdAsync(id);

        if (article is null)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return ArticleDto.MapToView(article);
    }

    public async Task<Result> UpdateAsync(int id, UpdateArticleDto dto)
    {
        var article = await _unitOfWork.Articles.GetByIdAsync(id);

        if (article is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Article with ID: {id} not found");
        }

        article.Title = dto.Title ?? article.Title;
        article.Link = dto.Link ?? article.Link;

        await _unitOfWork.Articles.UpdateAsync(article);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }
}
