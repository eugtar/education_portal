using Domain.Entities;
using Application.Dtos;
using Application.Services.Interfaces;
using Application.Interfaces;

namespace Application.Services;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;

    public ArticleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CreateArticleDto createArticleDto)
    {
        _unitOfWork.Articles.Add(
            new Article()
            {
                Title = createArticleDto.Title,
                Link = createArticleDto.Link
            });
            
        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var article = _unitOfWork.Articles.GetById(id) ?? throw new ArgumentNullException();

        _unitOfWork.Articles.Remove(article);
        _unitOfWork.Complete();
    }

    public List<Article> GetAll()
    {
        return [.. _unitOfWork.Articles.GetAll()];
    }

    public Article? GetById(int id)
    {
        return _unitOfWork.Articles.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, UpdateArticleDto updateArticleDto)
    {
        var article = _unitOfWork.Articles.GetById(id) ?? throw new ArgumentNullException();

        article.Title = updateArticleDto.Title ?? article.Title;
        article.Link = updateArticleDto.Link ?? article.Link;

        _unitOfWork.Articles.Update(article);
        _unitOfWork.Complete();
    }
}
