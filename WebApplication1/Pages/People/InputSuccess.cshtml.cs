using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace WebApplication1.Pages.People
{
    public class InputSuccessModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/People");
        }



    }
}
