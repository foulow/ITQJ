
using ITQJ.Domain.DTOs;
using ITQJ.WebClient.Models;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class ProfesionalSkillsController : BaseController
    {
        public ProfesionalSkillsController(IServiceProvider serviceProvider) : base(serviceProvider) { }


        [Authorize]
        public async Task<IActionResult> GetEdictSkills()
        {

            var userCredentials = GetUserCredentials();

            if(userCredentials is null || userCredentials.Role == "Contratista")
                return PageNotFound();

            var MySkills = await GetPersonalInfo(userCredentials.Id.ToString());

            if(MySkills == null)
                return RedirectToAction("Register");



            var skills = new PersonalInfoVM();
            skills.Skills = new List<SkillM>();
            skills.Id = (await GetPersonalInfo(userCredentials.Id.ToString())).Id;

            List<SkillDTO> tempSkills = new List<SkillDTO>();

            tempSkills = await CallApiGETAsync<List<SkillDTO>>(uri: "/api/skills",isSecured: false);

            foreach(var skill in MySkills.ProfesionalSkills)
            {
                var sk = tempSkills.FirstOrDefault(x => x.Id == skill.SkillId);

                skills.Skills.Add(new SkillM
                {
                    Id = skill.Id,
                    Name = sk.Name,
                    PersonalInfoId = MySkills.Id,
                    Path = sk.Path,
                    Percentage = skill.Percentage,
                    Active = skill.Percentage >= 1 ? true : false
                });
            }


            return View(skills.Skills);

        }




        private async Task<PersonalInfoResponseDTO> GetPersonalInfo(string userId)
        {
            return await CallApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userId, isSecured: true);
        }




        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostEdictSkills(List<SkillM> skills)
        {
            var temProfesionalSkills = new List<ProfesionalSkillCreateDTO>();

            foreach(var skill in skills)
            {
                if(skill.Percentage >= 1)
                {
                    var profesionalSkill = new ProfesionalSkillCreateDTO
                    {
                        Percentage = skill.Percentage,
                        PersonalInfoId = skill.PersonalInfoId,
                        SkillId = skill.Id
                    };

                    temProfesionalSkills.Add(profesionalSkill);
                }

            }

            _ = await CallApiPUTAsync(uri: "/api/profesionalSkills/group",body: temProfesionalSkills,isSecured: true);

            return RedirectToAction("Index","Home");
        }
    }
}