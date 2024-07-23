using System.ComponentModel;

namespace Domain {
    public enum EBookFormat
    {
        [Description(".epub")]
        EPUB,
        [Description(".pdf")]
        PDF,
        [Description("docx")]
        DOCX,
        [Description(".azw")]
        AZW,
        [Description(".txt")]
        TXT,
    }
}