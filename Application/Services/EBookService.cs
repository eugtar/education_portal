using System.Globalization;
using System.Net;
using Application.Dtos;
using Application.Interfaces;
using Application.Results;
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

    public async Task<Result> CreateAsync(CreateEbookDto dto)
    {
        await _unitOfWork.Ebooks.AddAsync(
            new Ebook()
            {
                Title = dto.Title,
                Author = dto.Author,
                PageAmount = dto.PageAmount,
                FormatId = (int)dto.FormatId,
                PublishedOn = DateTime.ParseExact(
                    dto.PublishedOn,
                    "yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None),
            });

        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var ebook = await _unitOfWork.Ebooks.GetByIdAsync(id);

        if (ebook is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Book with ID: {id} not found");
        }

        await _unitOfWork.Ebooks.RemoveAsync(ebook);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }

    public async Task<Result<List<Ebook>>> GetAllAsync()
    {
        var ebooks = await _unitOfWork.Ebooks.GetAllAsync();

        if (ebooks.Count() == 0)
        {
            return new Error(HttpStatusCode.NotFound, "Not found");
        }

        return ebooks.ToList();
    }

    public async Task<Result<Ebook?>> GetByIdAsync(int id)
    {
        var ebook = await _unitOfWork.Ebooks.GetByIdAsync(id);

        if (ebook is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Book with ID: {id} not found");
        }

        return ebook;
    }

    public async Task<Result> UpdateAsync(int id, UpdateEbookDto dto)
    {
        var ebook = await _unitOfWork.Ebooks.GetByIdAsync(id);

        if (ebook is null)
        {
            return new Error(HttpStatusCode.NotFound, $"Book with ID: {id} not found");
        }

        ebook.Title = dto.Title ?? ebook.Title;
        ebook.Author = dto.Author ?? ebook.Author;
        ebook.PageAmount = dto.PageAmount ?? ebook.PageAmount;
        ebook.FormatId = dto.FormatId != null
            ? (int)dto.FormatId
            : ebook.FormatId;
        ebook.PublishedOn = dto.PublishedOn is null
            ? ebook.PublishedOn
            : DateTime.ParseExact(
                dto.PublishedOn,
                "yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None);

        await _unitOfWork.Ebooks.UpdateAsync(ebook);
        await _unitOfWork.CompleteAsync();

        return Result.Success();
    }
}
