
using ITQJ.WebPWA.VMs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ITQJ.WebPWA.Pages
{
    public class ProfesionalSkillEdictModel : PageModel
    {
        public void OnGet()
        {

        }

        private void EnviarProfesionalSkillVM()
        {
            OctenerProfesionalSkillVM();
        }


        private List<ProfesionalSkillVM> OctenerProfesionalSkillVM()
        {
            List<ProfesionalSkillVM> AllSkill = new List<ProfesionalSkillVM>();

            foreach (var skills in ListListSkill)
            {

                foreach (ProfesionalSkillVM skill in skills.Value)
                {
                    if (skill.Active == true)
                        AllSkill.Add(skill);
                }
            }

            return AllSkill;
        }


        #region Listas de Skill

        public Dictionary<string, List<ProfesionalSkillVM>> ListListSkill = new Dictionary<string, List<ProfesionalSkillVM>>()
        {

            { "Lenguajes de Programacion", new List<ProfesionalSkillVM>()
            {
                new ProfesionalSkillVM()
                {
                    Name="C++",
                    Path="/icon-Tecnology/CPlus.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="C#",
                    Path="/icon-Tecnology/CSharp.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Objective C",
                    Path="/icon-Tecnology/Objective-C.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Ruby",
                    Path="/icon-Tecnology/ruby.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Java",
                    Path="/icon-Tecnology/java.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Kotlin",
                    Path="/icon-Tecnology/kotlin.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Php",
                    Path="/icon-Tecnology/php.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Python",
                    Path="/icon-Tecnology/python.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Go",
                    Path="/icon-Tecnology/Go.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Dart",
                    Path="/icon-Tecnology/Dart.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Switf",
                    Path="/icon-Tecnology/swift.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Delphi",
                    Path="/icon-Tecnology/delphi.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="VBasic",
                    Path="/icon-Tecnology/visual-basic.png"
                },
                new ProfesionalSkillVM()
                {
                    Name="Perl",
                    Path="/icon-Tecnology/Perl.jpg"
                }
            }},

            { "Lenguaje de Programacion, Marcado y Estilo. Front End", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="Java Script",
                        Path="/icon-Tecnology/javascript.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Html 5",
                        Path="/icon-Tecnology/html5.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Css 3",
                        Path="/icon-Tecnology/css3.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Sass",
                        Path="/icon-Tecnology/sass.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Less",
                        Path="/icon-Tecnology/less.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Babel",
                        Path="/icon-Tecnology/babel.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="BooStrp",
                        Path="/icon-Tecnology/bootstrap.png"
                    }
                }},

            { "Framework y Librerias de Java Script", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Framework de C#", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Tecnologias Moviles", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Sistemas Gestores de Base de Datos", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "CMS", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Navegadores Web", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Sistemas Operativo", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Repositorios, Sistemas Integracion Continua y Sistemas de DevOps", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "IDE y Editores de Codigo", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Otros Frameworks", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Otras Tecnologias", new List<ProfesionalSkillVM>()
                {
                    new ProfesionalSkillVM()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new ProfesionalSkillVM()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }}

        };

        #endregion


    }
}