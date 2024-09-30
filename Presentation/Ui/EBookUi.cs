using Application;
using Domain;

namespace Presentation
{
    public class EBookUi : Ui, IEBookUi
    {
        private readonly IEBookService _service;

        public EBookUi(IEBookService eBookService)
        {
            _service = eBookService;
        }

        public CreateEBookDto Create()
        {
            var title = ReadText("Book title");
            var author = ReadText("Book author");
            var pageAmount = ReadNumber("Page amount");

            List<string> eBookFormats = [".epub", ".pdf", ".docx", ".azw", ".txt"];
            var format = SelectOne(eBookFormats) switch
            {
                0 => EBookFormat.EPUB,
                1 => EBookFormat.PDF,
                2 => EBookFormat.DOCX,
                3 => EBookFormat.AZW,
                _ => EBookFormat.TXT
            };

            var publishedOn = new DateTime(
                year: ReadNumber("Year(YYYY)"),
                month: ReadNumber("Month(MM)"),
                day: ReadNumber("Day(DD)")
             );

            return new CreateEBookDto(title, author, pageAmount, format, publishedOn);
        }

        public string Delete()
        {
            var eBooks = _service.GetAll();

            return eBooks[base.SelectOne<EBook>(eBooks)].Id; ;
        }

        public string GetAll()
        {
            return $"[{string.Join(",\n", _service.GetAll())}]";
        }

        public string GetById()
        {
            var eBooks = _service.GetAll();

            return eBooks[SelectOne<EBook>(eBooks)].Id;
        }

        public UpdateEBookDto Update()
        {
            var title = ReadText("Book title", false);
            var author = ReadText("Book author", false);
            var pageAmount = ReadNumber("Page amount", false);

            List<string> eBookFormats = [".epub", ".pdf", ".docx", ".azw", ".txt"];
            var format = SelectOne(eBookFormats) switch
            {
                0 => EBookFormat.EPUB,
                1 => EBookFormat.PDF,
                2 => EBookFormat.DOCX,
                3 => EBookFormat.AZW,
                _ => EBookFormat.TXT
            };

            var publishedOn = new DateTime(
                year: ReadNumber("Year(YYYY)"),
                month: ReadNumber("Month(MM)"),
                day: ReadNumber("Day(DD)")
             );

            return new UpdateEBookDto(title, author, pageAmount, format, publishedOn);
        }
    }
}
