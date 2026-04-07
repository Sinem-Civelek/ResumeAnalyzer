using UglyToad.PdfPig;


public static class PdfParser
{
    public static string ExtractText(Stream pdfStream)
    {
        pdfStream.Position = 0;
        using (var document = PdfDocument.Open(pdfStream))
        {
            var text = string.Join(" ", document.GetPages().Select(page => page.Text));

            return text;
        }
    }
}