using ITQJ.WebPWA.Services;
using ITQJ.WebPWA.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ITQJ.WebPWA.Pages
{
    [Authorize]
    public class PerfilModel : PageModel
    {
        APIClientService APIClient { get; set; }
        public PersonalInfoVM PersonalInfo { get; set; }

        public PerfilModel(APIClientService apiClient)
        {
            APIClient = apiClient;
        }

        public async Task OnGet()
        {
            PersonalInfo = await APIClient.CallApiGetMethod<PersonalInfoVM>("https://localhost:44338/api/personalInfo/" + "1");
        }
    }
}