using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITQJ.WebPWA.Pages
{
    [Authorize]
    public class PerfilModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}