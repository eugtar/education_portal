using System.ComponentModel;

namespace Domain.Enums;

public enum EbookFormat
{
    [Description("epub")]
    EPUB = 1,
    [Description("pdf")]
    PDF = 2,
    [Description("docx")]
    DOCX = 3,
    [Description("azw")]
    AZW = 4,
    [Description("txt")]
    TXT = 5,
}