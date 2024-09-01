using Application.Dtos;

namespace Presentation.Uis.Interfaces;

public interface IEbookUi
{
    public CreateEbookDto Create();
    public UpdateEbookDto Update();
    public int Delete();
    public int GetById();
    public string GetAll();
}
