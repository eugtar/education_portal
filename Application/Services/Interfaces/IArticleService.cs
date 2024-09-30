using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IArticleService
{
    public void Create(CreateArticleDto createArticleDto);
    public void Update(int id, UpdateArticleDto updateArticleDto);
    public void Delete(int id);
    public Article? GetById(int id);
    public List<Article> GetAll();
}
