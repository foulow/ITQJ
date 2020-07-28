using ITQJ.WebClient.Models;
using ITQJ.WebClient.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebClient.ViewModels
{
    public class PersonalInfo
    {
        APIClientService _APIClient { get; set; }
        public List<SkillM> AllSkill { get; set; }

        List<SkillVM> AllSkillVM = new List<SkillVM>();

        [BindProperty]
        public Dictionary<string, List<SkillM>> DisctListSkill1 { get; set; }

        public PersonalInfo(APIClientService APIClient)
        {
            this._APIClient = APIClient;
        }

        public async Task OnGetAsync()
        {
            AllSkill = new List<SkillM>();

            AllSkillVM = await _APIClient.CallApiGetMethod<List<SkillVM>>(
            uri: "https://localhost:44338/api/PersonalInfo/");


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
