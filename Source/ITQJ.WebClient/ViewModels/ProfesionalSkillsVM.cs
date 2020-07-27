using ITQJ.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITQJ.WebClient.Services;

namespace ITQJ.WebClient.ViewModels
{
    public class ProfesionalSkillsVM
    {
        APIClientService _APIClient { get; set; }
        public List<SkillM> AllSkill { get; set; }

        List<SkillVM> AllSkillVM = new List<SkillVM>();

        [BindProperty]
        public Dictionary<string, List<SkillM>> DisctListSkill1 { get; set; }

        public ProfesionalSkillsVM(APIClientService APIClient)
        {
            this._APIClient = APIClient;
        }

        public async Task OnGetAsync()
        {
            AllSkill = new List<SkillM>();

            AllSkillVM = await _APIClient.CallApiGetMethod<List<SkillVM>>(
            uri: "https://localhost:44338/api/skills/");


            foreach (SkillVM skillVM in AllSkillVM)
            {
                AllSkill.Add(new SkillM()
                {
                    Name = skillVM.Name,
                    Path = skillVM.Path,
                    Percentage = 0,
                    Active = false
                });
            }

        }
    }
}
