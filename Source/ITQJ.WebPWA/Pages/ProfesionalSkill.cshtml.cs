using ITQJ.WebPWA.VMs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ITQJ.WebPWA.Pages
{
    public class ProfesionalSkillModel : PageModel
    {
        public string Rango = string.Empty;

        public void OnGet()
        {

        }

        public Dictionary<string, List<ProfesionalSkillVM>> ListListSkill = new Dictionary<string, List<ProfesionalSkillVM>>()
        {

            { "Lenguajes de Programacion", new List<ProfesionalSkillVM>()
            {
                new ProfesionalSkillVM()
                {
                    Name="C++",
                    Path="/icon-Tecnology/CPlus.png",
                    Percentage=26
                },
                new ProfesionalSkillVM()
                {
                    Name="C#",
                    Path="/icon-Tecnology/CSharp.png",
                    Percentage=64
                },
                new ProfesionalSkillVM()
                {
                    Name="Java",
                    Path="/icon-Tecnology/java.png",
                    Percentage=15
                },
                new ProfesionalSkillVM()
                {
                    Name="Php",
                    Path="/icon-Tecnology/php.png",
                    Percentage=15
                },
                new ProfesionalSkillVM()
                {
                    Name="Delphi",
                    Path="/icon-Tecnology/delphi.png",
                    Percentage=12
                }
            }},

            { "Lenguaje de Programacion, Marcado y Estilo. Front End", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="Java Script",
                        Path="/icon-Tecnology/javascript.png",
                        Percentage=45
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Html 5",
                        Path="/icon-Tecnology/html5.png",
                        Percentage=76
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Css 3",
                        Path="/icon-Tecnology/css3.png",
                        Percentage=85
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="BooStrp",
                        Path="/icon-Tecnology/bootstrap.png",
                        Percentage=35
                    }
                }
            }

        };

    }
}