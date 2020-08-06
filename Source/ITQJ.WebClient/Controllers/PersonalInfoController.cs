
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
            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/");
            if (user is null || user.Role == "Contratista")
                return PageNotFound();

            var personalInfoDTO = await UserHasPersonalInfo(user.Id.ToString());
            if ((personalInfoDTO is null) && (userId == user.Id.ToString()))
                return RedirectToAction("Register");
            else if (userId == user.Id.ToString())
                return RedirectToAction("EditProfesional");
            else if (personalInfoDTO == null)
                return PageNotFound();

            return View(personalInfoDTO);
        }

        [Authorize]
        public async Task<IActionResult> EditProfesional()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;

            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/");
            if (user is null || user.Role == "Contratista")
                return PageNotFound();

            if (email != user.Email)
                return RedirectToAction("AccessDenied", "Authorization");

            var personalInfo = await CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + user.Id);

            if (personalInfo == null)
                return RedirectToAction("Register");

            return View(personalInfo);
        }

        [Authorize]
        public async Task<IActionResult> Contratist(string userId)
        {
            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/");
            if (user is null || user.Role == "Profesional")
                return PageNotFound();

            var personalInfoDTO = await UserHasPersonalInfo(user.Id.ToString());
            if ((personalInfoDTO is null) && (userId == user.Id.ToString()))
                return RedirectToAction("Register");
            else if (userId == user.Id.ToString())
                return RedirectToAction("EditContratist");
            else if (personalInfoDTO == null)
                return PageNotFound();

            return View(personalInfoDTO);
        }

        [Authorize]
        public async Task<IActionResult> EditContratist()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;

            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/");
            if (user is null || user.Role == "Profesional")
                return PageNotFound();

            if (email != user.Email)
                return RedirectToAction("AccessDenied", "Authorization");

            var personalInfo = await CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + user.Id);

            if (personalInfo == null)
                return RedirectToAction("Register");

            return View(personalInfo);
        }

        [Authorize]
        public async Task<IActionResult> Register()
        {
            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/");


            var personalInfoDTO = await UserHasPersonalInfo(user.Id.ToString());
            if (!(personalInfoDTO is null))
            {
                if (user.Role == "Profesional")
                    return RedirectToAction("EditProfesional");
                else if (user.Role == "Contratista")
                    return RedirectToAction("EditContratist");

                return RedirectToAction("AccessDenied", "Authorization");
            }

            var personalInfo = new PersonalInfoVM();
            personalInfo.Skills = new List<SkillM>();
            personalInfo.UserId = user.Id;

            if (user.Role == "Profesional")
            {
                var tempSkills = await CallApiGETAsync<List<SkillDTO>>("/api/skills");
                foreach (var skill in tempSkills)
                {
                    personalInfo.Skills.Add(new SkillM
                    {
                        Id = skill.Id,
                        Name = skill.Name,
                        Path = skill.Path
                    });
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


            if (newPersonalInfo.User.Role == "Profesional")
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
                _ = await CallSecuredApiPOSTAsync("/api/profesionalSkills/", temProfesionalSkills);

                return RedirectToAction("EditProfesional");


            }
            else if (newPersonalInfo.User.Role == "Contratista")
            {
                return RedirectToAction("EditContratist");
            }

            return Error();
        }

        private Task<PersonalInfoResponseDTO> UserHasPersonalInfo(string userId)
        {
            var personalInfo = CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + userId);

            return personalInfo;
        }
    }
}
