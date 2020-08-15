
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

            if (userCredentials is null || userCredentials.Role == "Contratista")
                return PageNotFound();

            var personalInfo = await GetPersonalInfo(userCredentials.Id.ToString());

            if (personalInfo == null)
                return RedirectToAction("Register");

            List<SkillM>  skills = new List<SkillM>();
            List<SkillDTO> tempSkills = new List<SkillDTO>();

            tempSkills = await CallApiGETAsync<List<SkillDTO>>(uri: "/api/skills", isSecured: false);

            foreach (var skill in tempSkills)
            {
                var sk = personalInfo.ProfesionalSkills.FirstOrDefault(x => x.SkillId == skill.Id);

                skills.Add(new SkillM
                {
                    Id = skill.Id,
                    Name = skill.Name,
                    Path = skill.Path,
                    PersonalInfoId = personalInfo.Id,
                    ProfesionalSkillId = sk.Id,
                    SkillId = sk.SkillId,
                    Percentage = sk.Percentage,
                    Active = sk.Percentage >= 1 ? true : false
                });
            }


            return View(skills);

        }




        private async Task<PersonalInfoResponseDTO> GetPersonalInfo(string userId)
        {
            return await CallApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userId, isSecured: true);
        }




        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostEdictSkills(List<SkillM> skills)
        {
            var temProfesionalSkills = new List<ProfesionalSkillResponseDTO>();

            foreach (var skill in skills)
            {

                var profesionalSkill = new ProfesionalSkillResponseDTO
                {
                    Id = skill.ProfesionalSkillId,
                    Percentage = skill.Percentage,
                    PersonalInfoId = skill.PersonalInfoId,
                    SkillId = skill.SkillId
                };

                temProfesionalSkills.Add(profesionalSkill);

            }

            var temp = temProfesionalSkills.FirstOrDefault(x => x.Percentage >= 0).PersonalInfoId;

            _ = await CallApiPUTAsync(uri: "/api/profesionalSkills/group/" + temp.ToString(), body: temProfesionalSkills, isSecured: true);

            return RedirectToAction("viewProfesionalInfo", "PersonalInfo");
        }
    }
}