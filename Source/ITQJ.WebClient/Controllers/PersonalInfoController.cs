
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
        public async Task<IActionResult> Profesional(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Contratista")
                return PageNotFound();

            var personalInfoDTO = await GetPersonalInfo(userCredentials.Id.ToString());
            if ((personalInfoDTO is null) && (userId == userCredentials.Id.ToString()))
                return RedirectToAction("Register");
            else if (userId == userCredentials.Id.ToString())
                return RedirectToAction("EditProfesional");
            else if (personalInfoDTO == null)
                return PageNotFound();

            return View(personalInfoDTO);
        }


        [Authorize]
        public async Task<IActionResult> EditProfesional()
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Contratista")
                return PageNotFound();

            var personalInfo = await GetPersonalInfo(userCredentials.Id.ToString());

            if (personalInfo == null)
                return RedirectToAction("Register");


            return View(personalInfo);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfesional(PersonalInfoResponseDTO personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(personalInfo);
            }

            var response = await CallApiPUTAsync<PersonalInfoResponseDTO>(uri: "/api/PersonalInfo/EditPersonalInfo/" + personalInfo.UserId, body: personalInfo, isSecured: true);


            return View(response);
        }

        [Authorize]
        public async Task<IActionResult> Contratist(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Profesional")
                return PageNotFound();

            var personalInfoDTO = await GetPersonalInfo(userCredentials.Id.ToString());
            if ((personalInfoDTO is null) && (userId == userCredentials.Id.ToString()))
                return RedirectToAction("Register");
            else if (userId == userCredentials.Id.ToString())
                return RedirectToAction("EditContratist");
            else if (personalInfoDTO == null)
                return PageNotFound();

            return View(personalInfoDTO);
        }

        [Authorize]
        public async Task<IActionResult> EditContratist()
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Profesional")
                return PageNotFound();

            var personalInfo = await GetPersonalInfo(userCredentials.Id.ToString());

            if (personalInfo == null)
                return RedirectToAction("Register");

            return View(personalInfo);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditContratist(PersonalInfoResponseDTO personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(personalInfo);
            }

            var response = await CallApiPUTAsync<PersonalInfoResponseDTO>(uri: "/api/PersonalInfo/EditPersonalInfo/" + personalInfo.UserId, body: personalInfo, isSecured: true);


            return View(response);
        }


        [Authorize]
        public async Task<IActionResult> Register()
        {
            var userCredentials = GetUserCredentials();

            var personalInfoDTO = await GetPersonalInfo(userCredentials.Id.ToString());
            if (!(personalInfoDTO is null))
            {
                if (userCredentials.Role == "Profesional")
                    return RedirectToAction("EditProfesional");
                else if (userCredentials.Role == "Contratista")
                    return RedirectToAction("EditContratist");

                return RedirectToAction("AccessDenied", "Authorization");
            }

            var personalInfo = new PersonalInfoVM();
            personalInfo.Skills = new List<SkillM>();
            personalInfo.UserId = userCredentials.Id;
            personalInfo.DocumentTypes = await CallApiGETAsync<List<DocumentTypeDTO>>(uri: "/api/documentTypes", isSecured: false);

            if (userCredentials.Role == "Profesional")
            {
                var tempSkills = await CallApiGETAsync<List<SkillDTO>>(uri: "/api/skills", isSecured: false);
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
            //if (!ModelState.IsValid)
            //{
            //    return View(personalInfo);
            //}

            // Registra el documento de identidad.
            var newLegalDocument = await CallApiPOSTAsync<LegalDocumentResponseDTO>(uri: "/api/legalDocument", body: personalInfo.LegalDocument, isSecured: true);
            personalInfo.LegalDocumentId = newLegalDocument.Id;

            // Registra la informacion personal.
            var tempPersonalInfo = (PersonalInfoResponseDTO)personalInfo;
            var newPersonalInfo = await CallApiPOSTAsync<PersonalInfoResponseDTO>(uri: "/api/personalInfo", body: tempPersonalInfo, isSecured: true);

            //var get = GetUserCredentials();

            //newPersonalInfo.User = new UserResponseDTO();

            //newPersonalInfo.User.Role = get.Role;

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
                _ = await CallApiPOSTAsync(uri: "/api/profesionalSkills/", body: temProfesionalSkills, isSecured: true);

                return RedirectToAction("EditProfesional");


            }
            else if (newPersonalInfo.User.Role == "Contratista")
            {
                return RedirectToAction("EditContratist");
            }

            return Error();
        }

        private Task<PersonalInfoResponseDTO> GetPersonalInfo(string userId)
        {
            return CallApiGETAsync<PersonalInfoResponseDTO>(uri: "/api/personalInfo/" + userId, isSecured: true);
        }
    }
}
