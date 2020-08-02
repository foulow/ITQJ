
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
        public async Task<IActionResult> Profesional(string userName)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/" + userName);
            if (user is null)
                return PageNotFound();

            var personalInfoDTO = await UserHasPersonalInfo(user.Id.ToString());
            if ((personalInfoDTO is null) && (userId == user.Id.ToString()))
                return RedirectToAction("Register");
            else if (userId == user.Id.ToString())
                return RedirectToRoute(new { controller = "PersonalInfo", action = "EditProfesional", userName = userName });
            else if (personalInfoDTO == null)
                return PageNotFound();

            return View(personalInfoDTO);
        }

        [Authorize]
        public async Task<IActionResult> EditProfesional(string userName)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/" + userName);
            if (user is null)
                return PageNotFound();

            if (userId != user.Id.ToString())
                return RedirectToAction("AccessDenied", "Authorization");

            var personalInfo = await CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + user.Id);

            if (personalInfo == null)
                return RedirectToAction("Register");

            return View(personalInfo);
        }

        [Authorize]
        public async Task<IActionResult> Contratist(string userName)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/" + userName);
            if (user is null)
                return PageNotFound();

            var personalInfoDTO = await UserHasPersonalInfo(user.Id.ToString());
            if ((personalInfoDTO is null) && (userId == user.Id.ToString()))
                return RedirectToAction("Register");
            else if (userId == user.Id.ToString())
                return RedirectToRoute(new { controller = "PersonalInfo", action = "EditContratist", userName = userName });
            else if (personalInfoDTO == null)
                return PageNotFound();

            return View(personalInfoDTO);
        }

        [Authorize]
        public async Task<IActionResult> EditContratist(string userName)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var user = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users/" + userName);
            if (user is null)
                return PageNotFound();

            if (userId != user.Id.ToString())
                return RedirectToAction("AccessDenied", "Authorization");

            var personalInfo = await CallSecuredApiGETAsync<PersonalInfoResponseDTO>("/api/personalInfo/" + user.Id);

            if (personalInfo == null)
                return RedirectToAction("Register");

            return View(personalInfo);
        }

        [Authorize]
        public async Task<IActionResult> Register()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var userName = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

            var personalInfoDTO = await UserHasPersonalInfo(userId);
            if (!(personalInfoDTO is null))
            {
                if (role == "Profesional")
                    return RedirectToRoute(new { controller = "PersonalInfo", action = "EditProfesional", userName = userName });
                else if (role == "Contratista")
                    return RedirectToRoute(new { controller = "PersonalInfo", action = "EditContratist", userName = userName });

                return RedirectToAction("AccessDenied", "Authorization");
            }

            var personalInfo = new PersonalInfoVM();
            personalInfo.Skills = new List<SkillM>();
            personalInfo.UserId = Guid.Parse(userId);
            if (role == "Profesional")
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


            if (newPersonalInfo.User.Role.Name == "Profesional")
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

                return RedirectToRoute(new { controller = "PersonalInfo", action = "EditProfesional", userName = newPersonalInfo.User.UserName });

            }
            else if (newPersonalInfo.User.Role.Name == "Contratista")
            {
                return RedirectToRoute(new { controller = "PersonalInfo", action = "EditContratist", userName = newPersonalInfo.User.UserName });
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
