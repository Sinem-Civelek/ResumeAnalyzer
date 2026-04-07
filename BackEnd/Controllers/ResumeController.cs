using Microsoft.AspNetCore.Mvc;
using UglyToad.PdfPig;


[ApiController]
[Route("api/[controller]")]
public class ResumeController : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadResume(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is not uploaded.");

        try
        {
            string content = "";

            //file extension
            if (file.FileName.EndsWith(".pdf"))
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();

                    using (var document = PdfDocument.Open(fileBytes))
                    {
                        content = string.Join(" ", document.GetPages().Select(p => p.Text));
                    }
                }
            }
            else if (file.FileName.EndsWith(".docx"))
            {
                content = DocxParser.ExtractText(file.OpenReadStream());
            }
            else
            {
                return BadRequest("Unsupported doc type. Please upload PDF or Docx.");
            }

            //content
            if (string.IsNullOrWhiteSpace(content))
            {
                return Ok(new { keywords = new string[] { "Text was not found" } });
            }

            
            var keywordsArray = content
                .Split(new[] { ' ', '\n', '\r', '\t', ',', '.', ':', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word.Length > 2) // eliminate based on the length
                .Distinct() 
                .ToArray();

          
            return Ok(new { keywords = keywordsArray });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            return StatusCode(500, $": {ex.Message}");
        }
    }
}