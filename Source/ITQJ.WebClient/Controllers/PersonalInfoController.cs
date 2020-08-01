
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
    public class PersonalInfoController : BaseController
    {
        public PersonalInfoController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [Authorize]
        public async Task<IActionResult> Profesional(string userId)
        {
            var ownerId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (ownerId == userId)
                return RedirectToAction("EditProfesional");

            var personalInfo = await CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userId);

            if (personalInfo == null)
                return PageNotFound();

            return View(personalInfo);
        }

        [Authorize]
        public async Task<IActionResult> Contratist(string userId)
        {
            var ownerId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (ownerId == userId)
                return RedirectToAction("EditContratist");

            var personalInfo = await CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userId);

            if (personalInfo == null)
                return PageNotFound();

            return View(personalInfo);
        }

        [Authorize]
        public async Task<IActionResult> Register(string userId)
        {
            var ownerId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

            if (ownerId != userId)
                return PageNotFound();

            if (UserHasPersonalInfo(ownerId))
            {
                if (role == "Profesional")
                    return RedirectToAction("EditProfesional");
                else if (role == "Contratist")
                    return RedirectToAction("EditContratist");

                return Error();
            }

            var personalInfo = new PersonalInfoVM();
            personalInfo.UserId = Guid.Parse(ownerId);
            if (role == "Profesional")
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
            var newLegalDocument = await CallSecuredApiPOSTAsync<LegalDocumentResponseDTO>("/api/legalDocument", personalInfo.LegalDocument);
            personalInfo.LegalDocumentId = newLegalDocument.Id;

            // Registra la informacion personal.
            var tempPersonalInfo = (PersonalInfoResponseDTO)personalInfo;
            var newPersonalInfo = await CallSecuredApiPOSTAsync<PersonalInfoResponseDTO>("/api/personailInfo", tempPersonalInfo);


            if (newPersonalInfo.User.Role.Name != "Profesional")
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
                var newProfesionalSkills = await CallSecuredApiPOSTAsync("/api/profesionalSkills/", temProfesionalSkills);

                return RedirectToAction("Profesional");
            }
            else if (newPersonalInfo.User.Role.Name != "Contratist")
            {
                return RedirectToAction("Contratist");
            }

            return Error();
        }

        private bool UserHasPersonalInfo(string userId)
        {
            var personalInfo = CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userId);

            return personalInfo == null;
        }
    }
}
