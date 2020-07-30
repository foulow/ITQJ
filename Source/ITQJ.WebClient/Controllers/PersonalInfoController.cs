
using ITQJ.Domain.DTOs;
using ITQJ.WebClient.Models;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class PersonalInfoController : BaseController
    {
        public PersonalInfoController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [Authorize]
        public async Task<IActionResult> Profesional(string userName)
        {
            var personalInfo = await CallApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userName);

            if (personalInfo == null)
                return PageNotFound();

            return View(personalInfo);
        }

        [Authorize]
        public async Task<IActionResult> Contratist(string userName)
        {
            var personalInfo = await CallApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userName);

            if (personalInfo == null)
                return PageNotFound();

            return View(personalInfo);
        }

        [Authorize]
        public async Task<IActionResult> Register(string userName)
        {
            var user = await CallApiGETAsync<UserResponseDTO>("/api/users/" + userName, true);
            if (user != null)
                return PageNotFound();

            if (UserHasPersonalInfo(user))
            {
                if (user.Rol.Name != "Profesional")
                    return RedirectToAction("Profesional");
                else if (user.Rol.Name != "Contratist")
                    return RedirectToAction("Contratist");

                return Error();
            }

            var personalInfo = new PersonalInfoVM();
            personalInfo.UserId = user.Id;
            if (user.Rol.Name != "Profesional")
            {
                var tempSkills = await CallApiGETAsync<List<SkillDTO>>("/api/skills");
                foreach (var skill in tempSkills)
                {
                    personalInfo.Skills.Add((SkillM)skill);
                }
            }

            return View(personalInfo);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(PersonalInfoVM personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(personalInfo);
            }

            // Registra el documento de identidad.
            var newLegalDocument = await CallApiPOSTAsync<LegalDocumentResponseDTO>("/api/legalDocument", personalInfo.LegalDocument, true);
            personalInfo.LegalDocumentId = newLegalDocument.Id;

            // Registra la informacion personal.
            var tempPersonalInfo = (PersonalInfoResponseDTO)personalInfo;
            var newPersonalInfo = await CallApiPOSTAsync<PersonalInfoResponseDTO>("/api/personailInfo", tempPersonalInfo, true);


            if (newPersonalInfo.User.Rol.Name != "Profesional")
            {
                // Registra los skills de dicho profesional.
                var temProfesionalSkills = new List<ProfesionalSkillCreateDTO>();
                foreach (var selectedSkill in personalInfo.Skills)
                {
                    var profesionalSkill = new ProfesionalSkillCreateDTO
                    {
                        Percentage = selectedSkill.Percentage,
                        PersonalInfoId = newPersonalInfo.Id,
                        SkillId = selectedSkill.SkillId
                    };
                    temProfesionalSkills.Add(profesionalSkill);
                }
                var newProfesionalSkills = await CallApiPOSTAsync("/api/profesionalSkills/", temProfesionalSkills, true);

                return RedirectToAction("Profesional");
            }
            else if (newPersonalInfo.User.Rol.Name != "Contratist")
            {
                return RedirectToAction("Contratist");
            }

            return Error();
        }

        private bool UserHasPersonalInfo(UserResponseDTO user)
        {
            var personalInfo = CallApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + user.UserName, true);

            if (personalInfo == null)
                return false;

            return true;
        }
    }
}
