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

    public async Task CreateAsync(CreateEbookDto createEbookDto)
    {
        await _unitOfWork.Ebooks.AddAsync(
            new Ebook()
            {
                Title = createEbookDto.Title,
                Author = createEbookDto.Author,
                PageAmount = createEbookDto.PageAmount,
                FormatId = (int)createEbookDto.FormatId,
                PublishedOn = createEbookDto.PublishedOn,
            });

        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var eBook = await _unitOfWork.Ebooks.GetByIdAsync(id);

        if (eBook is not null)
        {
            await _unitOfWork.Ebooks.RemoveAsync(eBook);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<List<Ebook>> GetAllAsync()
    {
        return [.. await _unitOfWork.Ebooks.GetAllAsync()];
    }

    public async Task<Ebook?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Ebooks.GetByIdAsync(id);
    }

    public async Task UpdateAsync(int id, UpdateEbookDto updateEbookDto)
    {
        var eBook = await _unitOfWork.Ebooks.GetByIdAsync(id);

        if (eBook is not null)
        {
            eBook.Title = updateEbookDto.Title ?? eBook.Title;
            eBook.Author = updateEbookDto.Author ?? eBook.Author;
            eBook.PageAmount = updateEbookDto.PageAmount ?? eBook.PageAmount;
            eBook.FormatId = updateEbookDto.FormatId != null ? (int)updateEbookDto.FormatId : eBook.FormatId;
            eBook.PublishedOn = updateEbookDto.PublishedOn ?? eBook.PublishedOn;

            await _unitOfWork.Ebooks.UpdateAsync(eBook);
            await _unitOfWork.CompleteAsync();
        }
    }
}
