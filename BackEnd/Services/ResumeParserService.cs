public static class ResumeParserService
{
    public static async Task<string> ParseAsync(IFormFile file)
    {
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream);

        if (file.FileName.EndsWith(".pdf"))
        {
            var pdfText = PdfParser.ExtractText(stream);
            return pdfText;
        }
        else if (file.FileName.EndsWith(".docx"))
        {
            var text = DocxParser.ExtractText(stream);
            return text;
        }
        return string.Empty;
    }
}