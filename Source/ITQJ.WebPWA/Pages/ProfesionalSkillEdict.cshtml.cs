
using ITQJ.WebPWA.Entidades;
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


        private List<Skill> OctenerProfesionalSkillVM()
        {
            List<Skill> AllSkill = new List<Skill>();

            foreach (var skills in ListListSkill)
            {

                foreach (Skill skill in skills.Value)
                {
                    if (skill.Active == true)
                        AllSkill.Add(skill);
                }
            }

            return AllSkill;
        }


        #region Listas de Skill

        public Dictionary<string, List<Skill>> ListListSkill = new Dictionary<string, List<Skill>>()
        {

            { "Lenguajes de Programacion", new List<Skill>()
            {
                new Skill()
                {
                    Name="C++",
                    Path="/icon-Tecnology/CPlus.png"
                },
                new Skill()
                {
                    Name="C#",
                    Path="/icon-Tecnology/CSharp.png"
                },
                new Skill()
                {
                    Name="Objective C",
                    Path="/icon-Tecnology/Objective-C.png"
                },
                new Skill()
                {
                    Name="Ruby",
                    Path="/icon-Tecnology/ruby.png"
                },
                new Skill()
                {
                    Name="Java",
                    Path="/icon-Tecnology/java.png"
                },
                new Skill()
                {
                    Name="Kotlin",
                    Path="/icon-Tecnology/kotlin.png"
                },
                new Skill()
                {
                    Name="Php",
                    Path="/icon-Tecnology/php.png"
                },
                new Skill()
                {
                    Name="Python",
                    Path="/icon-Tecnology/python.png"
                },
                new Skill()
                {
                    Name="Go",
                    Path="/icon-Tecnology/Go.png"
                },
                new Skill()
                {
                    Name="Dart",
                    Path="/icon-Tecnology/Dart.png"
                },
                new Skill()
                {
                    Name="Switf",
                    Path="/icon-Tecnology/swift.png"
                },
                new Skill()
                {
                    Name="Delphi",
                    Path="/icon-Tecnology/delphi.png"
                },
                new Skill()
                {
                    Name="VBasic",
                    Path="/icon-Tecnology/visual-basic.png"
                },
                new Skill()
                {
                    Name="Perl",
                    Path="/icon-Tecnology/Perl.jpg"
                }
            }},

            { "Lenguaje de Programacion, Marcado y Estilo. Front End", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="Java Script",
                        Path="/icon-Tecnology/javascript.png"
                    },
                    new Skill()
                    {
                        Name="Html 5",
                        Path="/icon-Tecnology/html5.png"
                    },
                    new Skill()
                    {
                        Name="Css 3",
                        Path="/icon-Tecnology/css3.png"
                    },
                    new Skill()
                    {
                        Name="Sass",
                        Path="/icon-Tecnology/sass.png"
                    },
                    new Skill()
                    {
                        Name="Less",
                        Path="/icon-Tecnology/less.png"
                    },
                    new Skill()
                    {
                        Name="Babel",
                        Path="/icon-Tecnology/babel.png"
                    },
                    new Skill()
                    {
                        Name="BooStrp",
                        Path="/icon-Tecnology/bootstrap.png"
                    }
                }},

            { "Framework y Librerias de Java Script", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Framework de C#", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Tecnologias Moviles", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Sistemas Gestores de Base de Datos", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "CMS", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Navegadores Web", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Sistemas Operativo", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Repositorios, Sistemas Integracion Continua y Sistemas de DevOps", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "IDE y Editores de Codigo", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Otros Frameworks", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }},

            { "Otras Tecnologias", new List<Skill>()
                {
                    new Skill()
                    {
                        Name="C++",
                        Path="/icon-Tecnology/CPlus.png"
                    },
                    new Skill()
                    {
                        Name="C#",
                        Path="/icon-Tecnology/CSharp.png"
                    },
                    new Skill()
                    {
                        Name="Objective C",
                        Path="/icon-Tecnology/Objective-C.png"
                    },
                    new Skill()
                    {
                        Name="Ruby",
                        Path="/icon-Tecnology/ruby.png"
                    },
                    new Skill()
                    {
                        Name="Java",
                        Path="/icon-Tecnology/java.png"
                    },
                    new Skill()
                    {
                        Name="Kotlin",
                        Path="/icon-Tecnology/kotlin.png"
                    },
                    new Skill()
                    {
                        Name="Php",
                        Path="/icon-Tecnology/php.png"
                    },
                    new Skill()
                    {
                        Name="Python",
                        Path="/icon-Tecnology/python.png"
                    },
                    new Skill()
                    {
                        Name="Go",
                        Path="/icon-Tecnology/Go.png"
                    },
                    new Skill()
                    {
                        Name="Dart",
                        Path="/icon-Tecnology/Dart.png"
                    },
                    new Skill()
                    {
                        Name="Switf",
                        Path="/icon-Tecnology/swift.png"
                    },
                    new Skill()
                    {
                        Name="Delphi",
                        Path="/icon-Tecnology/delphi.png"
                    },
                    new Skill()
                    {
                        Name="VBasic",
                        Path="/icon-Tecnology/visual-basic.png"
                    },
                    new Skill()
                    {
                        Name="Perl",
                        Path="/icon-Tecnology/Perl.jpg"
                    }
                }}

        };

        #endregion


    }
}