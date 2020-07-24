using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITQJ.WebPWA.Entitdades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITQJ.WebPWA.Pages
{
    public class ProfesionalSkillModel : PageModel
    {
        public string Rango = string.Empty;

        public void OnGet()
        {

        }

        public  Dictionary<string, List<Skill>> ListListSkill = new Dictionary<string, List<Skill>>()
        {

            { "Lenguajes de Programacion", new List<Skill>()
            {
                new Skill()
                {
                    Name="C++",
                    Path="/icon-Tecnology/CPlus.png",
                    Percentage=26
                },
                new Skill()
                {
                    Name="C#",
                    Path="/icon-Tecnology/CSharp.png",
                    Percentage=64   
                },
                new Skill()
                {
                    Name="Java",
                    Path="/icon-Tecnology/java.png",
                    Percentage=15
                },
                new Skill()
                {
                    Name="Php",
                    Path="/icon-Tecnology/php.png",
                    Percentage=15
                },
                new Skill()
                {
                    Name="Delphi",
                    Path="/icon-Tecnology/delphi.png",
                    Percentage=12
                }
            }},

            { "Lenguaje de Programacion, Marcado y Estilo. Front End", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="Java Script",
                        Path="/icon-Tecnology/javascript.png",
                        Percentage=45
                    },
                    new Skill()
                    {
                        Name="Html 5",
                        Path="/icon-Tecnology/html5.png",
                        Percentage=76
                    },
                    new Skill()
                    {
                        Name="Css 3",
                        Path="/icon-Tecnology/css3.png",
                        Percentage=85
                    },
                    new Skill()
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