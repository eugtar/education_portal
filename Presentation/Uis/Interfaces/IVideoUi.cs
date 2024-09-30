using Application.Dtos;

namespace Presentation.Uis.Interfaces;

public interface IVideoUi
{
    public CreateVideoDto Create();
    public UpdateVideoDto Update();
    public int Delete();
    public int GetById();
    public string GetAll();
}
