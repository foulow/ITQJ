using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITQJ.WebPWA.Entitdades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITQJ.WebPWA.Pages
{

    public class ProfesionalSkillEdict2Model : PageModel
    {
        private List<Skill> AllSkill { get; set; }


        [BindProperty]
        public Dictionary<string, List<Skill>> DisctListSkill2 { get; set; }


        public ProfesionalSkillEdict2Model(List<Skill> AllSkill)
        {
            this.AllSkill = AllSkill;
        }

        public void OnGet()
        {
            DisctListSkill2 = new Dictionary<string, List<Skill>>()
            {
                {
                    "Stacks",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="Stack MEAN",
                        index=1
                        },
                        new Skill()
                        {
                            Name="Stack MERN",
                        index=2
                        },
                        new Skill()
                        {
                            Name="Stack LAMP",
                        index=3
                        },
                        new Skill()
                        {
                            Name="Stack WISA",
                         index=4
                        }
                    }
                },
                {
                    "Paradigmas",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="Programacion Funcional",
                        index=5
                        },
                        new Skill()
                        {
                            Name="Programacion Orientada Objetos",
                        index=6
                        },
                        new Skill()
                        {
                            Name="Programación reactiva",
                        index=7
                        },
                        new Skill()
                        {
                            Name="Programación multiparadigma",
                        index=8
                        },
                        new Skill()
                        {
                            Name="Programación imperativa o por procedimientos",
                        index=9
                        },
                        new Skill()
                        {
                            Name="Programación dirigida por eventos",
                        index=10
                        },
                        new Skill()
                        {
                            Name="Programación declarativa",
                        index=11
                        }
                    }
                },
                {
                    "Principios Solid",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="Solid",
                        index=12
                        }
                    }
                },
                {
                    "Patrones de diseño",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="Abstract Factory",
                        index=13
                        },
                        new Skill()
                        {
                            Name="Factory Method",
                        index=14
                        },
                        new Skill()
                        {
                            Name="Builder",
                        index=15
                        },
                        new Skill()
                        {
                            Name="Singleton",
                        index=16
                        },
                        new Skill()
                        {
                            Name="Prototype",
                        index=17
                        },
                        new Skill()
                        {
                            Name="",
                        index=18
                        },
                        new Skill()
                        {
                            Name="Adapter",
                        index=19
                        },
                        new Skill()
                        {
                            Name=" Bridge",
                        index=20
                        },
                        new Skill()
                        {
                            Name="Composite",
                        index=21
                        },
                        new Skill()
                        {
                            Name="Decorator",
                        index=22
                        },
                        new Skill()
                        {
                            Name="Facade",
                        index=23
                        },
                        new Skill()
                        {
                            Name="Flyweight",
                        index=24
                        },
                        new Skill()
                        {
                            Name="Proxy",
                        index=25
                        },
                        new Skill()
                        {
                            Name="",
                        index=26
                        },
                        new Skill()
                        {
                            Name="Command",
                        index=27
                        },
                        new Skill()
                        {
                            Name="Chain of responsibility",
                        index=28
                        },
                        new Skill()
                        {
                            Name="Interpreter",
                        index=29
                        },
                        new Skill()
                        {
                            Name="Iterator",
                        index=30
                        },
                        new Skill()
                        {
                            Name="Mediator",
                        index=31
                        },
                        new Skill()
                        {
                            Name="Memento",
                        index=32
                        },
                        new Skill()
                        {
                            Name="Observer",
                        index=33
                        },
                        new Skill()
                        {
                            Name="State",
                        index=34
                        },
                        new Skill()
                        {
                            Name="Strategy",
                        index=35
                        },
                        new Skill()
                        {
                            Name="Template Method",
                        index=36
                        },
                        new Skill()
                        {
                            Name="Visitor",
                        index=37
                        }
                    }
                },
                {
                    "Arquitectura de diseño y Patrones de arquitecturas",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="Capas (Layerin)",
                        index=38
                        },
                        new Skill()
                        {
                            Name="Niveles (Tree)",
                        index=39
                        },
                        new Skill()
                        {
                            Name="MVC",
                        index=40
                        },
                        new Skill()
                        {
                            Name="HMVC (PAC)",
                        index=41
                        },
                        new Skill()
                        {
                            Name="MVP",
                        index=42
                        },
                        new Skill()
                        {
                            Name="MVVM",
                        index=43
                        },
                        new Skill()
                        {
                            Name="MVP-VM",
                        index=44
                        },
                        new Skill()
                        {
                            Name="Page Controller",
                        index=45
                        },
                        new Skill()
                        {
                            Name="Front Controller",
                        index=46
                        },
                        new Skill()
                        {
                            Name="Template View",
                        index=47
                        },
                        new Skill()
                        {
                            Name="Application Controller",
                        index=48
                        },
                        new Skill()
                        {
                            Name="EBI",
                        index=49
                        },
                        new Skill()
                        {
                            Name="",
                        index=50
                        },

                        new Skill()
                        {
                            Name="Service Layer",
                        index=51
                        },
                        new Skill()
                        {
                            Name="DDD (Domin Driver Desing)",
                        index=52
                        },
                        new Skill()
                        {
                            Name="TDD (Test-driven development)",
                        index=53
                        },
                        new Skill()
                        {
                            Name="Domain Entity/ Domin Model/ Business Object",
                        index=54
                        },
                        new Skill()
                        {
                            Name="Value Object",
                        index=55
                        },
                        new Skill()
                        {
                            Name="Agregate Root",
                        index=56
                        },
                        new Skill()
                        {
                            Name="Transaction Script",
                        index=57
                        },
                        new Skill()
                        {
                            Name="Table Module",
                        index=58
                        },
                        new Skill()
                        {
                            Name="Data Transfers Object (DTO)",
                        index=59
                        },
                        new Skill()
                        {
                            Name="Business Delegate",
                        index=60
                        },
                        new Skill()
                        {
                            Name="Unit of Work",
                        index=61
                        },
                        new Skill()
                        {
                            Name="",
                        index=62
                        },

                         new Skill()
                        {
                            Name="Table Data Gateway",
                        index=63
                        },
                         new Skill()
                        {
                            Name="Data Mapper",
                        index=64
                        },
                         new Skill()
                        {
                            Name="Query Object",
                        index=65
                        },
                         new Skill()
                        {
                            Name="Data Access Object (DAO)",
                        index=66
                        },
                         new Skill()
                        {
                            Name="Repository",
                        index=67
                        }
                    }
                },
                {
                    "ORM",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="Entity Framework Core",
                        index=68
                        },
                        new Skill()
                        {
                            Name="Dapper",
                        index=69
                        },
                        new Skill()
                        {
                            Name="Hibérnate",
                        index=70
                        },
                        new Skill()
                        {
                            Name="iBatis",
                        index=71
                        },
                        new Skill()
                        {
                            Name="Ebean",
                        index=72
                        },
                        new Skill()
                        {
                            Name="Torque",
                        index=73
                        },
                        new Skill()
                        {
                            Name="nHibernate",
                        index=74
                        },
                        new Skill()
                        {
                            Name="Doctrine",
                        index=75
                        },
                        new Skill()
                        {
                            Name="Propel",
                        index=76
                        },
                        new Skill()
                        {
                            Name="Torpor",
                        index=77
                        },
                        new Skill()
                        {
                            Name="SQLObject",
                        index=78
                        },
                        new Skill()
                        {
                            Name="Django",
                        index=79
                        },
                        new Skill()
                        {
                            Name="Tryton",
                        index=80
                        }
                    }
                }
            };
        }

        public List<Skill> OctenerSkill()
        {

            foreach (var skills in DisctListSkill2)
            {
                foreach (Skill skill in skills.Value)
                {
                    if (skill.Active == true)
                        AllSkill.Add(skill);
                }
            }

            return AllSkill;
        }

        public IActionResult OnPostAsync()
        {

            return RedirectToPage("./ProfesionalSkill");
        }


    }
}