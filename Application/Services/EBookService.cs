using Application.Dtos;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class EBookService : IEBookService
{
    private readonly IUnitOfWork _unitOfWork;

    public EBookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CreateEBookDto createEBookDto)
    {
        _unitOfWork.EBooks.Add(
            new EBook()
            {
                Title = createEBookDto.Title,
                Author = createEBookDto.Author,
                PageAmount = createEBookDto.PageAmount,
                Format = createEBookDto.Format,
                PublishedOn = createEBookDto.PublishedOn,
            });
        
        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var eBook = _unitOfWork.EBooks.GetById(id) ?? throw new ArgumentException();

        _unitOfWork.EBooks.Remove(eBook);
        _unitOfWork.Complete();
    }

    public List<EBook> GetAll()
    {
        return [.. _unitOfWork.EBooks.GetAll()];
    }

    public EBook? GetById(int id)
    {
        return _unitOfWork.EBooks.GetById(id) ?? throw new ArgumentNullException();
    }

    public void Update(int id, UpdateEBookDto updateEBookDto)
    {
        var eBook = _unitOfWork.EBooks.GetById(id) ?? throw new ArgumentNullException();

        eBook.Title = updateEBookDto.Title ?? eBook.Title;
        eBook.Author = updateEBookDto.Author ?? eBook.Author;
        eBook.PageAmount = updateEBookDto.PageAmount ?? eBook.PageAmount;
        eBook.Format = updateEBookDto.Format ?? eBook.Format;
        eBook.PublishedOn = updateEBookDto.PublishedOn ?? eBook.PublishedOn;

        _unitOfWork.EBooks.Update(eBook);
        _unitOfWork.Complete();
    }
}
