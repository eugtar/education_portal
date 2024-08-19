using Application.Dtos;

namespace Presentation.Uis.Interfaces;

public interface IEBookUi
{
    public CreateEBookDto Create();
    public UpdateEBookDto Update();
    public int Delete();
    public int GetById();
    public string GetAll();
}
