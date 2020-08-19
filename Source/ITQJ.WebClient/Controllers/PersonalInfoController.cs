
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
        public async Task<IActionResult> Profesional(string userId,Guid projectId, Guid PostulanId)
        {

            if (string.IsNullOrWhiteSpace(userId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Profesional")
                return RedirectToAction("AccessDenied", "Authorization");

            var personalInfoDTO = await GetPersonalInfo(userId);
            if ((personalInfoDTO is null) && (userId == userCredentials.Id.ToString()))
                return RedirectToAction("Register");
            else if (userId == userCredentials.Id.ToString())
                return RedirectToAction("Profesional");
            else if (personalInfoDTO == null)
                return PageNotFound();


            return View(new List<object>(){personalInfoDTO, Convert.ToString(projectId), Convert.ToString(PostulanId) });
        }



        [Authorize]
        public async Task<IActionResult> viewProfesionalInfo()
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
        public async Task<IActionResult> EdictProfesionalInfo()
        {
            var userCredentials = GetUserCredentials();

            if(userCredentials is null || userCredentials.Role == "Contratista")
                return PageNotFound();

            var personalInfo = await GetPersonalInfo(userCredentials.Id.ToString());

            if(personalInfo == null)
                return RedirectToAction("Register");


            return View(personalInfo);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PutProfesionalInfo(PersonalInfoResponseDTO personalInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(personalInfo);
            }

            var response = await CallApiPUTAsync<PersonalInfoResponseDTO>(uri: "/api/PersonalInfo/" + personalInfo.Id, body: personalInfo, isSecured: true);


            return RedirectToRoute(new { action = "viewProfesionalInfo", contructor = "PersonalInfo" });
        }

        


        [Authorize]
        public async Task<IActionResult> Contratist(string userId)
        {
            if(string.IsNullOrWhiteSpace(userId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials is null)
                return RedirectToAction("AccessDenied", "Authorization");

            var personalInfoDTO = await GetPersonalInfo(userId);
            if((personalInfoDTO is null) && (userId == userCredentials.Id.ToString()))
                return RedirectToAction("Register");
            else if(userId == userCredentials.Id.ToString())
                return RedirectToAction("Contratist");
            else if(personalInfoDTO == null)
                return PageNotFound();

            return View(personalInfoDTO);
        }


        [Authorize]
        public async Task<IActionResult> viewContratistInfo()
        {
            var userCredentials = GetUserCredentials();

            if(userCredentials is null || userCredentials.Role == "Profesional")
                return PageNotFound();

            var personalInfo = await GetPersonalInfo(userCredentials.Id.ToString());

            if(personalInfo == null)
                return RedirectToAction("Register");

            return View(personalInfo);
        }


        [Authorize]
        public async Task<IActionResult> EdictContratistInfo()
        {
            var userCredentials = GetUserCredentials();

            if(userCredentials is null || userCredentials.Role == "Profesional")
                return PageNotFound();

            var personalInfo = await GetPersonalInfo(userCredentials.Id.ToString());

            if(personalInfo == null)
                return RedirectToAction("Register");

            return View(personalInfo);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PutContratistInfo(PersonalInfoResponseDTO personalInfo)
        {
            if(!ModelState.IsValid)
            {
                return View(personalInfo);
            }

            var response = await CallApiPUTAsync<PersonalInfoResponseDTO>(uri: "/api/PersonalInfo/" + personalInfo.Id,body: personalInfo,isSecured: true);


            return RedirectToRoute(new { action = "viewContratistInfo",contructor = "PersonalInfo" });
        }






        [Authorize]
        public async Task<IActionResult> AddSkills(string id)
        {
            var userCredentials = GetUserCredentials();


            var personalInfo = new PersonalInfoVM();
            personalInfo.Skills = new List<SkillM>();
            personalInfo.Id = Guid.Parse(id);

            if(userCredentials.Role == "Profesional")
            {
                var tempSkills = await CallApiGETAsync<List<SkillDTO>>(uri: "/api/skills",isSecured: false);

                foreach(var skill in tempSkills)
                {
                    personalInfo.Skills.Add(new SkillM
                    {
                        Id = skill.Id,
                        Name = skill.Name,
                        Path = skill.Path,
                        PersonalInfoId = personalInfo.Id
                    });
                }
            }

            return View(personalInfo.Skills);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddSkills(List<SkillM> skills)
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

                _ = await CallApiPOSTAsync(uri: "/api/profesionalSkills/group",body: temProfesionalSkills,isSecured: true);

            return RedirectToAction("Index","Home");
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
            personalInfo.LegalDocument.FileName = "ninguno.desconosido";

            // Registra el documento de identidad.
            var newLegalDocument = await CallApiPOSTAsync<LegalDocumentResponseDTO>(uri: "/api/legalDocument", body: personalInfo.LegalDocument, isSecured: true);
            personalInfo.LegalDocumentId = newLegalDocument.Id;

            // Registra la informacion personal.
            var tempPersonalInfo = (PersonalInfoResponseDTO)personalInfo;
            var newPersonalInfo = await CallApiPOSTAsync<PersonalInfoResponseDTO>(uri: "/api/personalInfo", body: tempPersonalInfo, isSecured: true);

            if (newPersonalInfo.User.Role == "Contratista")
            {
                return RedirectToAction("EditContratist");
            }

            return RedirectToRoute( new { action = "AddSkills", controller = "PersonalInfo", id = newPersonalInfo.Id });
        }





        private Task<PersonalInfoResponseDTO> GetPersonalInfo(string userId)
        {
            return CallApiGETAsync<PersonalInfoResponseDTO>(uri: "/api/personalInfo/" + userId, isSecured: true);
        }
    }
}
