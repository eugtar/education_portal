using Application.Dtos;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Presentation.Uis.Common;
using Presentation.Uis.Interfaces;

namespace Presentation.Uis;

public class EbookUi : Ui, IEbookUi
{
    private readonly IEbookService _service;

    public EbookUi(IEbookService ebookService)
    {
        _service = ebookService;
    }

    public CreateEbookDto Create()
    {
        var title = ReadText("Book title");
        var author = ReadText("Book author");
        var pageAmount = ReadNumber("Page amount");

        List<string> ebookFormats = [".epub", ".pdf", ".docx", ".azw", ".txt"];
        var format = SelectOne(ebookFormats) switch
        {
            0 => EbookFormat.EPUB,
            1 => EbookFormat.PDF,
            2 => EbookFormat.DOCX,
            3 => EbookFormat.AZW,
            _ => EbookFormat.TXT
        };

        var publishedOn = new DateTime(
            year: ReadNumber("Year(YYYY)"),
            month: ReadNumber("Month(MM)"),
            day: ReadNumber("Day(DD)")
         );

        return new CreateEbookDto(title, author, pageAmount, format, publishedOn);
    }

    public int Delete()
    {
        var ebooks = _service.GetAll();

        return ebooks[base.SelectOne<Ebook>(ebooks)].Id; ;
    }

    public string GetAll()
    {
        return $"[{string.Join(",\n", _service.GetAll())}]";
    }

    public int GetById()
    {
        var ebooks = _service.GetAll();

        return ebooks[SelectOne<Ebook>(ebooks)].Id;
    }

    public UpdateEbookDto Update()
    {
        var title = ReadText("Book title", false);
        var author = ReadText("Book author", false);
        var pageAmount = ReadNumber("Page amount", false);

        List<string> ebookFormats = [".epub", ".pdf", ".docx", ".azw", ".txt"];
        var format = SelectOne(ebookFormats) switch
        {
            0 => EbookFormat.EPUB,
            1 => EbookFormat.PDF,
            2 => EbookFormat.DOCX,
            3 => EbookFormat.AZW,
            _ => EbookFormat.TXT
        };

        var publishedOn = new DateTime(
            year: ReadNumber("Year(YYYY)"),
            month: ReadNumber("Month(MM)"),
            day: ReadNumber("Day(DD)")
         );

        return new UpdateEbookDto(title, author, pageAmount, format, publishedOn);
    }
}
