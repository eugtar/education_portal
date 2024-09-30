using Application.Dtos;

namespace Presentation.Uis.Interfaces;

public interface IArticleUi
{
    public CreateArticleDto Create();
    public UpdateArticleDto Update();
    public int Delete();
    public int GetById();
    public string GetAll();
}

