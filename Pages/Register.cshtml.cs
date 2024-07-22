using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace OpenWhistle.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Username { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 14, ErrorMessage = "Password must be at least 14 characters long.")]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            return RedirectToPage("/Index"); 
        }
    }
}