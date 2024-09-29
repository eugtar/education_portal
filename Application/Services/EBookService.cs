using Application.Dtos;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class EBookService : IEbookService
{
    private readonly IUnitOfWork _unitOfWork;

    public EBookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Create(CreateEbookDto createEbookDto)
    {
        _unitOfWork.Ebooks.Add(
            new Ebook()
            {
                Title = createEbookDto.Title,
                Author = createEbookDto.Author,
                PageAmount = createEbookDto.PageAmount,
                FormatId = (int)createEbookDto.FormatId,
                PublishedOn = createEbookDto.PublishedOn,
            });
        
        _unitOfWork.Complete();
    }

    public void Delete(int id)
    {
        var eBook = _unitOfWork.Ebooks.GetById(id);

        _unitOfWork.Ebooks.Remove(eBook);
        _unitOfWork.Complete();
    }

    public List<Ebook> GetAll()
    {
        return [.. _unitOfWork.Ebooks.GetAll()];
    }

    public Ebook? GetById(int id)
    {
        return _unitOfWork.Ebooks.GetById(id);
    }

    public void Update(int id, UpdateEbookDto updateEbookDto)
    {
        var eBook = _unitOfWork.Ebooks.GetById(id);

        eBook.Title = updateEbookDto.Title ?? eBook.Title;
        eBook.Author = updateEbookDto.Author ?? eBook.Author;
        eBook.PageAmount = updateEbookDto.PageAmount ?? eBook.PageAmount;
        eBook.FormatId = updateEbookDto.FormatId != null ? (int)updateEbookDto.FormatId : eBook.FormatId;
        eBook.PublishedOn = updateEbookDto.PublishedOn ?? eBook.PublishedOn;

        _unitOfWork.Ebooks.Update(eBook);
        _unitOfWork.Complete();
    }
}
