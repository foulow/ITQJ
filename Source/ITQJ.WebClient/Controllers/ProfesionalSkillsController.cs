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
            PersonalInfoVM personalInfo = new PersonalInfoVM();

            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Contratista")
                return PageNotFound();


            personalInfo.Id = (await GetPersonalInfo(userCredentials.Id.ToString())).Id;
            personalInfo.Skills = new List<SkillM>();


            if(userCredentials.Role == "Profesional")
            {
                var tempSkills = await CallApiGETAsync<List<SkillDTO>>(uri: "/api/skills",isSecured: false);

                List<ProfesionalSkillResponseDTO> skillDTOs = new List<ProfesionalSkillResponseDTO>();
                foreach(var skill in tempSkills)
                {
                    skillDTOs.Add( new ProfesionalSkillResponseDTO { Id = skill.Id });
                }

                foreach(var skill in tempSkills)
                {
                    personalInfo.Skills.Add(new SkillM
                    {
                        Id = skill.Id,
                        Name = skill.Name,
                        Path = skill.Path,
                        PersonalInfoId = personalInfo.Id,
                        Percentage = skillDTOs.FirstOrDefault(x => x.Skill.Id == skill.Id) == null ? 0 : skillDTOs.FirstOrDefault(x => x.Skill.Id == skill.Id).Percentage,
                        Active = skillDTOs.FirstOrDefault(x => x.Skill.Id == skill.Id) == null ? false : true
                    });
                }
            }


            return View(personalInfo.Skills);

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