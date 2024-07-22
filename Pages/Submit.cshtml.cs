using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenWhistle.Models;

namespace OpenWhistle.Pages
{
    public class SubmitModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            long size = Upload.Sum(f => f.Length); // TODO: additional handling of the file size

            var filePath = Path.GetTempFileName();

            foreach (var formFile in Upload.Where(formFile => formFile.Length > 0))
            {
                byte[] fileByes;

                await using var stream = new FileStream(filePath, FileMode.Create);
                using var reader = new BinaryReader(stream);
                fileByes = reader.ReadBytes((int)stream.Length);

                WhistleblowerReport report = new(ReportDescription); // probably better off in a command / service class
                //TODO: Save
            }
            
            return Page();
        }
        [BindProperty] public List<IFormFile> Upload { get; set; }
        [BindProperty] 
        public string ReportDescription { get; set; }
        [BindProperty] 
        public DateTime DateOfOccurrence { get; set; }

        public TimeSpan TimeOfOccurence { get; set; }
    }
}
