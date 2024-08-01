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
            string title = ReadText("Book title");
            string author = ReadText("Book author");
            int pageAmount = ReadNumber("Page amount");

            List<string> eBookFormats = [".epub",".pdf", ".docx", ".azw", ".txt"];
            EBookFormat format = SelectOne(eBookFormats) switch
            {
                0 => EBookFormat.EPUB,
                1 => EBookFormat.PDF,
                2 => EBookFormat.DOCX,
                3 => EBookFormat.AZW,
                _ => EBookFormat.TXT
            };

            DateTime publishedOn = new DateTime(
                year:ReadNumber("Year(YYYY)"),
                month:ReadNumber("Month(MM)"),
                day:ReadNumber("Day(DD)")
             );

            return new CreateEBookDto(title, author, pageAmount, format, publishedOn);
        }


        public string Delete()
        {
            List<EBook> eBooks = _service.GetAll();

            if (eBooks.Count == 0)
            {
                Console.WriteLine("Not Found");
                App.StopProcess();
            }

            return eBooks[base.SelectOne<EBook>(eBooks)]?.Id; ;
        }


        public string SelectOne()
        {
            throw new NotImplementedException();
        }


        public UpdateEBookDto Update()
        {
            throw new NotImplementedException();
        }
    }
}
