using System.ComponentModel;

namespace Domain {
    public enum EBookFormat
    {
        [Description(".epub")]
        EPUB = 0,
        [Description(".pdf")]
        PDF = 1,
        [Description("docx")]
        DOCX = 2,
        [Description(".azw")]
        AZW = 3,
        [Description(".txt")]
        TXT = 4,
    }
}