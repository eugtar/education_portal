using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IEbookService
{
    public void Create(CreateEbookDto createEbookDto);
    public void Update(int id, UpdateEbookDto updateEbookDto);
    public void Delete(int id);
    public Ebook? GetById(int id);
    public List<Ebook> GetAll();
}
