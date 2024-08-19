using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IEBookService
{
    public void Create(CreateEBookDto createEBookDto);
    public void Update(int id, UpdateEBookDto updateEBookDto);
    public void Delete(int id);
    public EBook? GetById(int id);
    public List<EBook> GetAll();
}
