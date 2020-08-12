using ITQJ.Domain.DTOs;
using ITQJ.WebClient.Models;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class ProfesionalSkillsController : BaseController
    {
        public ProfesionalSkillsController(IServiceProvider serviceProvider) : base(serviceProvider) { }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetEdictSkills()
        {

            var userCredentials = GetUserCredentials();

            if(userCredentials is null || userCredentials.Role == "Contratista")
                return PageNotFound();

            var personalInfoskills = await GetPersonalInfo(userCredentials.Id.ToString());

            if(personalInfoskills == null)
                return RedirectToAction("Register");


            var personalInfo = new PersonalInfoVM();
            personalInfo.Skills = new List<SkillM>();
            personalInfo.UserId = userCredentials.Id;
            personalInfo.DocumentTypes = await CallApiGETAsync<List<DocumentTypeDTO>>("/api/documentTypes");

            if(userCredentials.Role == "Profesional")
            {
                var tempSkills = await CallApiGETAsync<List<SkillDTO>>("/api/skills");

                List<ProfesionalSkillResponseDTO> skillDTOs = new List<ProfesionalSkillResponseDTO>();
                foreach(var skill in personalInfoskills.ProfesionalSkills)
                {
                    skillDTOs.Add(skill);
                }

                //82a96710 - 57dc - 4ddc - 3651 - 08d83cab2c08
                //799a9cdc - 73b1 - 4256 - 3652 - 08d83cab2c0
                //38508f31 - c4bb - 4046 - 3653 - 08d83cab2c08

                foreach(var skill in tempSkills)
                {
                    personalInfo.Skills.Add(new SkillM  
                    {
                        Id = skill.Id,
                        Name = skill.Name,
                        Path = skill.Path,
                        Percentage = skillDTOs.FirstOrDefault(x => x.Skill.Id == skill.Id) == null ? 0 : skillDTOs.FirstOrDefault(x => x.Skill.Id == skill.Id).Percentage,
                        Active = skillDTOs.FirstOrDefault(x => x.Skill.Id == skill.Id) == null ? false : true
                    });

                }
            }

            return View(personalInfo);
        }

        private async Task<PersonalInfoResponseDTO> GetPersonalInfo(string userId)
        {
            return await CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userId);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostEdictSkills(PersonalInfoVM personalInfo)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(personalInfo);
            //}

            // Registra el documento de identidad.
            var newLegalDocument = await CallSecuredApiPOSTAsync<LegalDocumentResponseDTO>("/api/legalDocument",personalInfo.LegalDocument);
            personalInfo.LegalDocumentId = newLegalDocument.Id;

            // Registra la informacion personal.
            var tempPersonalInfo = (PersonalInfoResponseDTO)personalInfo;
            var newPersonalInfo = await CallSecuredApiPOSTAsync<PersonalInfoResponseDTO>("/api/personalInfo",tempPersonalInfo);


            if(newPersonalInfo.User.Role == "Profesional")
            {
                // Registra los skills de dicho profesional.
                var temProfesionalSkills = new List<ProfesionalSkillCreateDTO>();
                foreach(var selectedSkill in personalInfo.Skills)
                {
                    var profesionalSkill = new ProfesionalSkillCreateDTO
                    {
                        Percentage = selectedSkill.Percentage,
                        PersonalInfoId = newPersonalInfo.Id,
                        SkillId = selectedSkill.SkillId
                    };
                    temProfesionalSkills.Add(profesionalSkill);
                }
                _ = await CallSecuredApiPOSTAsync("/api/profesionalSkills/",temProfesionalSkills);

                return RedirectToAction("EditProfesional");


            }
            else if(newPersonalInfo.User.Role == "Contratista")
            {
                return RedirectToAction("EditContratist");
            }

            return Error();
        }

    }
}