using DocumentFormat.OpenXml.Packaging;


public static class DocxParser
{
    public static string ExtractText(Stream docxStream)
    {
        using var memoryStream = new MemoryStream();
        docxStream.CopyTo(memoryStream);
        memoryStream.Position = 0;

        using var wordDoc = WordprocessingDocument.Open(memoryStream, false);
        var body = wordDoc.MainDocumentPart.Document.Body;
        return body.InnerText;
    }
}