using Domain.Enums;

namespace Application.Dtos;

public class UpdateEBookDto(string? title, string? author, int? pageAmount, EBookFormat? format, DateTime? publishedOn)
{
    public string? Title => title;
    public string? Author => author;
    public int? PageAmount => pageAmount;
    public EBookFormat? Format => format;
    public DateTime? PublishedOn => publishedOn;
}
