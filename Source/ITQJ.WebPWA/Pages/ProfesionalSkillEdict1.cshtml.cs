
using System.Collections.Generic;
using ITQJ.WebPWA.Entitdades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITQJ.WebPWA.Pages
{
    public class ProfesionalSkillEdict1Model : PageModel
    {
        [ViewData]
        private List<Skill> AllSkill { get; set; }


        [BindProperty]
        public Dictionary<string, List<Skill>> DisctListSkill1 { get; set; }


        public void OnGet()
        {

            DisctListSkill1 = new Dictionary<string, List<Skill>>()
            {
                { 
                    "Lenguajes de Programacion", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                            index=1,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                            index=2,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                            index=3,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                            index=4,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                            index=5,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                            index=6,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                            index=7,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                            index=8,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                            index=9,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                            index=10,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                            index=11,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                            index=12,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                            index=13,
                            Active = false,
                            Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                            index=14,
                            Active = false,
                            Percentage = 10
                        }
                    }
                },
                { 
                    "Lenguaje de Programacion, Marcado y Estilo. Front End", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="Java Script",
                            Path="/icon-Tecnology/javascript.png",
                        index=16,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Html 5",
                            Path="/icon-Tecnology/html5.png",
                        index=17,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Css 3",
                            Path="/icon-Tecnology/css3.png",
                        index=18,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Sass",
                            Path="/icon-Tecnology/sass.png",
                        index=19,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Less",
                            Path="/icon-Tecnology/less.png",
                        index=20,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Babel",
                            Path="/icon-Tecnology/babel.png",
                        index=21,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="BooStrp",
                            Path="/icon-Tecnology/bootstrap.png",
                        index=22,
                        Active = false,
                        Percentage = 10
                        }
                    }
                },
                { 
                    "Framework y Librerias de Java Script", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=23,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=24,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=25,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=26,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=27,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=28,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=29,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=30,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=31,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=32,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=33,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=34,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=35,
                        Active = false,
                        Percentage = 10
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=36,
                        Active = false,
                        Percentage = 10
                        }
                    }
                },
                { 
                    "Framework de C#",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=37
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=38
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=39
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=40
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=41
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=42
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=43
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=44
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=45
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=46
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=47
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=48
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=49
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=50
                        }
                    }
                },
                { 
                    "Tecnologias Moviles", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=51
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=52
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=53
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=54
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=55
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=56
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=57
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=58
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=59
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=60
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=61
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=62
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=63
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=64
                        }
                    }
                },
                { 
                    "Sistemas Gestores de Base de Datos", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=65
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=66
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=67
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=68
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=69
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=70
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=71
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=72
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=73
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=74
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=75
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=76
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=77
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=78
                        }
                    }
                },
                { 
                    "CMS",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=79
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=80
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=81
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=82
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=83
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=84
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=85
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=86
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=87
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=88
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=89
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=90
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=91
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=92
                        }
                    }
                },
                { 
                    "Navegadores Web", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=93
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=94
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=95
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=96
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=97
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=98
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=99
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=100
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=101
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=102
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=103
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=104
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=105
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=106
                        }
                    }
                },
                { 
                    "Sistemas Operativo",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=107
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=108
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=109
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=110
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=111
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=112
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=113
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=114
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=115
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=116
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=117
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=118
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=119
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=120
                        }
                    }
                },
                { 
                    "Repositorios, Sistemas Integracion Continua y Sistemas de DevOps",
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=121
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=122
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=123
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=124
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=125
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=126
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=127
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=128
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=129
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=130
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=131
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=132
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=133
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=134
                        }
                    }
                },
                { 
                    "IDE y Editores de Codigo", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=135
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=136
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=137
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=138
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=139
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=140
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=141
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=142
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=143
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=144
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=145
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=146
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=147
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=148
                        }
                    }
                },
                { 
                    "Otros Frameworks", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=149
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=150
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=151
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=152
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=153
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=154
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=155
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=156
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=157
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=158
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=159
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=160
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=161
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=162
                        }
                    }
                },
                { 
                    "Otras Tecnologias", 
                    new List<Skill>()
                    {
                        new Skill()
                        {
                            Name="C++",
                            Path="/icon-Tecnology/CPlus.png",
                        index=163
                        },
                        new Skill()
                        {
                            Name="C#",
                            Path="/icon-Tecnology/CSharp.png",
                        index=164
                        },
                        new Skill()
                        {
                            Name="Objective C",
                            Path="/icon-Tecnology/Objective-C.png",
                        index=165
                        },
                        new Skill()
                        {
                            Name="Ruby",
                            Path="/icon-Tecnology/ruby.png",
                        index=166
                        },
                        new Skill()
                        {
                            Name="Java",
                            Path="/icon-Tecnology/java.png",
                        index=167
                        },
                        new Skill()
                        {
                            Name="Kotlin",
                            Path="/icon-Tecnology/kotlin.png",
                        index=168
                        },
                        new Skill()
                        {
                            Name="Php",
                            Path="/icon-Tecnology/php.png",
                        index=169
                        },
                        new Skill()
                        {
                            Name="Python",
                            Path="/icon-Tecnology/python.png",
                        index=170
                        },
                        new Skill()
                        {
                            Name="Go",
                            Path="/icon-Tecnology/Go.png",
                        index=171
                        },
                        new Skill()
                        {
                            Name="Dart",
                            Path="/icon-Tecnology/Dart.png",
                        index=172
                        },
                        new Skill()
                        {
                            Name="Switf",
                            Path="/icon-Tecnology/swift.png",
                        index=173
                        },
                        new Skill()
                        {
                            Name="Delphi",
                            Path="/icon-Tecnology/delphi.png",
                        index=174
                        },
                        new Skill()
                        {
                            Name="VBasic",
                            Path="/icon-Tecnology/visual-basic.png",
                        index=175
                        },
                        new Skill()
                        {
                            Name="Perl",
                            Path="/icon-Tecnology/Perl.jpg",
                        index=176
                        }
                    }
                }
            };

        }


        public List<Skill> OctenerSkill()
        {
            AllSkill = new List<Skill>();

            foreach (var skills in DisctListSkill1)
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

            var listSkill = OctenerSkill();

            return RedirectToPage($"./ProfesionalSkill-2/{listSkill}");
        }


    }
}