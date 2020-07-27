
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class PersonalInfoController : Controller
    {
        //private readonly PersonalInfo profesionaInfo;
        //private readonly ProfesionalSkillsVM profesionalSkillsVM;

        public PersonalInfoController(/*PersonalInfo profesionaInfo, ProfesionalSkillsVM profesionalSkillsVM*/)
        {
            //this.profesionaInfo = profesionaInfo;
            //this.profesionalSkillsVM = profesionalSkillsVM;
        }

        public async Task<IActionResult> PersonalInfo()
        {
            PersonalInfo profesionaInfo = new PersonalInfo(new Services.APIClientService());
            await profesionaInfo.OnGetAsync();

            return View(profesionaInfo.AllSkill);
        }

        public async Task<IActionResult> ProfessionalSkill()
        {
            ProfesionalSkillsVM profesionalSkillsVM = new ProfesionalSkillsVM(new Services.APIClientService());
            await profesionalSkillsVM.OnGetAsync();
            
            return View(profesionalSkillsVM.AllSkill);
        }


    }
}
