using ITQJ.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ITQJ.EFCore.Configurations
{
    public class DataConfig
    {
        //public static IEnumerable<Role> Roles =>
        //    new Role[]
        //    {
        //        new Role {
        //            Id = Guid.Parse("31BE72FD-BE58-492A-8976-57FF74DAEB7A"),
        //            Name = "Profesional"
        //        },
        //        new Role {
        //            Id = Guid.Parse("3D3B586A-EC26-42A3-A63A-026492FFC298"),
        //            Name = "Contratista"
        //        }
        //    };

        public static IEnumerable<DocumentType> DocumentTypes =>
            new DocumentType[]
            {
                new DocumentType {
                    Id = Guid.Parse("189EE312-AFD2-4145-9687-585D001F23E7"),
                    Name = "Cédula"
                },
                new DocumentType {
                    Id = Guid.Parse("44CA726F-E486-451A-81CE-780F50748FE0"),
                    Name = "Pasaporte"
                },
                new DocumentType {
                    Id = Guid.Parse("D514AD48-39BF-4212-843C-1A26289087FE"),
                    Name = "RCN"
                }
            };

        public static IEnumerable<Skill> Skills =>
            new Skill[]
            {
                new Skill { Id = Guid.Parse("0F5F4AE9-4E26-4A38-B2D1-A5338AF48BAA"), Name = "C",        Path = "/icon-Tecnology/C.png"},
                new Skill { Id = Guid.Parse("D99EBA61-53CC-41E1-AFEE-5C99A6AF102A"), Name = "C++",      Path = "/icon-Tecnology/CPlus.png"},
                new Skill { Id = Guid.Parse("1EA43D00-8DC7-4B82-96E0-EABFEA74C9B9"), Name = "C#",       Path = "/icon-Tecnology/CSharp.png"},
                new Skill { Name = "Objective-C",                                       Path = "/icon-Tecnology/Objective-C.png"},
                new Skill { Name = "Ruby",                                              Path = "/icon-Tecnology/ruby.png"},
                new Skill { Name = "Java",                                              Path = "/icon-Tecnology/java.png"},
                new Skill { Name = "Kotlin",                                            Path = "/icon-Tecnology/kotlin.png"},
                new Skill { Name = "PHP",                                               Path = "/icon-Tecnology/php.png"},
                new Skill { Name = "Go",                                                Path = "/icon-Tecnology/Go.png"},
                new Skill { Name = "Dart",                                              Path = "/icon-Tecnology/Dart.png"},
                new Skill { Name = "Swift",                                             Path = "/icon-Tecnology/swift.png"},
                new Skill { Name = "Delphi",                                            Path = "/icon-Tecnology/delphi.png"},
                new Skill { Name = "VB",                                                Path = "/icon-Tecnology/visual-basic.png"},
                new Skill { Name = "Perl",                                              Path = "/icon-Tecnology/Perl.png"},
                new Skill { Name = "Java Script",                                       Path = "/icon-Tecnology/javascript.png"},
                new Skill { Name = "Css 3",                                             Path = "/icon-Tecnology/css3.png"},
                new Skill { Name = "HTML 5",                                            Path = "/icon-Tecnology/html5.png"},
                new Skill { Name = "Sass",                                              Path = "/icon-Tecnology/sass.png"},
                new Skill { Name = "Less",                                              Path = "/icon-Tecnology/less.png"},
                new Skill { Name = "Babel",                                             Path = "/icon-Tecnology/babel.png"},
                new Skill { Name = "Bootstrap",                                         Path = "/icon-Tecnology/bootstrap.png"},
                new Skill { Name = "Angular",                                           Path = "/icon-Tecnology/angularjs.png"},
                new Skill { Name = "Vue",                                               Path = "/icon-Tecnology/vue_js.png"},
                new Skill { Name = "React",                                             Path = "/icon-Tecnology/react.png"},
                new Skill { Name = "Ember",                                             Path = "/icon-Tecnology/ember.png"},
                new Skill { Name = "Jquery",                                            Path = "/icon-Tecnology/jquery.png"},
                new Skill { Name = "Nodo Js",                                           Path = "/icon-Tecnology/nodejs.png"},
                new Skill { Name = "Type Script",                                       Path = "/icon-Tecnology/typescript.png"},
                new Skill { Name = "Polymer",                                            Path = "/icon-Tecnology/polymer.png"},
                new Skill { Name = "Electron",                                          Path = "/icon-Tecnology/electron.png"},
                new Skill { Name = "Asp.net",                                           Path = "/icon-Tecnology/asp.net.png"},
                new Skill { Name = "Blazor",                                            Path = "/icon-Tecnology/blazor.png"},
                new Skill { Name = "Cordova",                                           Path = "/icon-Tecnology/cordova.png"},
                new Skill { Name = "Xamarin",                                           Path = "/icon-Tecnology/xamarin.png"},
                new Skill { Name = "Flutter",                                           Path = "/icon-Tecnology/flutter.png"},
                new Skill { Name = "Ionic",                                             Path = "/icon-Tecnology/ionic.png"},
                new Skill { Name = "Reat Native",                                       Path = "/icon-Tecnology/react_native.png"},
                new Skill { Name = "TeraData",                                          Path = "/icon-Tecnology/teradata.png"},
                new Skill { Name = "Redis Db",                                          Path = "/icon-Tecnology/redis_db.png"},
                new Skill { Name = "Postgre Sql",                                       Path = "/icon-Tecnology/postgresql.png"},
                new Skill { Name = "MySql",                                             Path = "/icon-Tecnology/mysql.png"},
                new Skill { Name = "Mongo Db",                                          Path = "/icon-Tecnology/mongodb.png"},
                new Skill { Name = "Sql Server",                                        Path = "/icon-Tecnology/T-SQL.png"},
                new Skill { Name = "IBM Db2",                                           Path = "/icon-Tecnology/ibm_db2.png"},
                new Skill { Name = "Sap Sybase",                                        Path = "/icon-Tecnology/sap_sybase.png"},
                new Skill { Name = "Drupal",                                            Path = "/icon-Tecnology/drupal.png"},
                new Skill { Name = "Joomla",                                            Path = "/icon-Tecnology/joomla.png"},
                new Skill { Name = "Moodle",                                            Path = "/icon-Tecnology/moodle.png"},
                new Skill { Name = "WordPress",                                         Path = "/icon-Tecnology/wordpress.png"},
                new Skill { Name = "Chrome",                                            Path = "/icon-Tecnology/chrome.png"},
                new Skill { Name = "FireFox",                                           Path = "/icon-Tecnology/firefox.png"},
                new Skill { Name = "Edge",                                              Path = "/icon-Tecnology/edge.png"},
                new Skill { Name = "Opera",                                             Path = "/icon-Tecnology/opera.png"},
                new Skill { Name = "Safari",                                            Path = "/icon-Tecnology/safari.png"},
                new Skill { Name = "DuckDuckgo",                                        Path = "/icon-Tecnology/duckduckgo.png"},
                new Skill { Name = "Windows",                                           Path = "/icon-Tecnology/windows.png"},
                new Skill { Name = "Ubuntu",                                            Path = "/icon-Tecnology/ubuntu.png"},
                new Skill { Name = "Linux",                                             Path = "/icon-Tecnology/linux.png"},
                new Skill { Name = "Git",                                               Path = "/icon-Tecnology/git.png"},
                new Skill { Name = "GitHub",                                            Path = "/icon-Tecnology/github.png"},
                new Skill { Name = "GitLab",                                            Path = "/icon-Tecnology/gitlab.png"},
                new Skill { Name = "Bitbuket",                                          Path = "/icon-Tecnology/bitbucket.png"},
                new Skill { Name = "Cicleci",                                           Path = "/icon-Tecnology/circleci.png"},
                new Skill { Name = "Travis",                                            Path = "/icon-Tecnology/travis_ci.png"},
                new Skill { Name = "AWS",                                               Path = "/icon-Tecnology/amazon_web_services.png"},
                new Skill { Name = "Azure",                                             Path = "/icon-Tecnology/azure.png"},
                new Skill { Name = "FireBase",                                          Path = "/icon-Tecnology/firebase.png"},
                new Skill { Name = "Google cloud",                                      Path = "/icon-Tecnology/google-cloud-platform.png"},
                new Skill { Name = "Jenkins",                                           Path = "/icon-Tecnology/jenkins.png"},
                new Skill { Name = "VS Code",                                           Path = "/icon-Tecnology/visual_studio_code.png"},
                new Skill { Name = "Sublime",                                           Path = "/icon-Tecnology/sublime.png"},
                new Skill { Name = "Atom",                                              Path = "/icon-Tecnology/atom.png"},
                new Skill { Name = "Visul Studio",                                      Path = "/icon-Tecnology/visual_studio.png"},
                new Skill { Name = "NetBens",                                           Path = "/icon-Tecnology/NetBeans.svg"},
                new Skill { Name = "Eclipse",                                           Path = "/icon-Tecnology/eclipse.jpeg"},
                new Skill { Name = "JeBrains",                                          Path = "/icon-Tecnology/jetbrains.png"},
                new Skill { Name = "QT Creatorpng",                                     Path = "/icon-Tecnology/Qt-creator.png"},
                new Skill { Name = "Dev C++",                                           Path = "/icon-Tecnology/dev_visual_c_plus_plus.png"},
                new Skill { Name = "Django",                                            Path = "/icon-Tecnology/django.png"},
                new Skill { Name = "Laravel",                                           Path = "/icon-Tecnology/laravel.png"},
                new Skill { Name = "Symfony",                                           Path = "/icon-Tecnology/symfony.png"},
                new Skill { Name = "Ajax",                                              Path = "/icon-Tecnology/AJAX.png"},
                new Skill { Name = "BlazorStrop",                                       Path = "/icon-Tecnology/blazorStrop.png"},
                new Skill { Name = "Docker",                                            Path = "/icon-Tecnology/docker.png"},
                new Skill { Name = "Express",                                           Path = "/icon-Tecnology/express.png"},
                new Skill { Name = "GraphQL",                                           Path = "/icon-Tecnology/graphql.png"},
                new Skill { Name = "Json",                                              Path = "/icon-Tecnology/json.png"},
                new Skill { Name = "Kubernetes",                                        Path = "/icon-Tecnology/kubernetes.png"},
                new Skill { Name = "Nuget",                                             Path = "/icon-Tecnology/nuget.png"},
                new Skill { Name = "Npm",                                               Path = "/icon-Tecnology/npm.png"},
                new Skill { Name = "Yan",                                               Path = "/icon-Tecnology/yarn.png"},
                new Skill { Name = "IIS",                                               Path = "/icon-Tecnology/IIS.png"},
                new Skill { Name = "Xampp",                                             Path = "/icon-Tecnology/Xampp.png"},
                new Skill { Name = "Webpack",                                           Path = "/icon-Tecnology/webpack.png"},
                new Skill { Name = "Xml",                                               Path = "/icon-Tecnology/xml.png"},
                new Skill { Name = "Radzen",                                            Path = "/icon-Tecnology/Radzen.png"}//,
                //new Skill { Name = "Stack MEAN",                                        Path = "/icon-Tecnology"},
                //new Skill { Name = "Stack MEAN",                                        Path = "/icon-Tecnology"},
                //new Skill { Name = "Stack LAMP",                                        Path = "/icon-Tecnology"},
                //new Skill { Name = "Stack WISA",                                        Path = "/icon-Tecnology"},
                //new Skill { Name = "Programacion Orientada Objetos",                    Path = "/icon-Tecnology"},
                //new Skill { Name = "Programacion Orientada Objetos",                    Path = "/icon-Tecnology"},
                //new Skill { Name = "Programación reactiva",                             Path = "/icon-Tecnology"},
                //new Skill { Name = "Programación reactiva",                             Path = "/icon-Tecnology"},
                //new Skill { Name = "Programación imperativa o por procedimientos",      Path = "/icon-Tecnology"},
                //new Skill { Name = "Programación dirigida por eventos",                 Path = "/icon-Tecnology"},
                //new Skill { Name = "Programación declarativa",                          Path = "/icon-Tecnology"},
                //new Skill { Name = "principios solid",                                  Path = "/icon-Tecnology"},
                //new Skill { Name = "Abstract Factory",                                  Path = "/icon-Tecnology"},
                //new Skill { Name = "Factory Method",                                    Path = "/icon-Tecnology"},
                //new Skill { Name = "Builder",                                           Path = "/icon-Tecnology"},
                //new Skill { Name = "Singleton",                                         Path = "/icon-Tecnology"},
                //new Skill { Name = "Prototype",                                         Path = "/icon-Tecnology"},
                //new Skill { Name = "Adapter",                                           Path = "/icon-Tecnology"},
                //new Skill { Name = "Bridge",                                            Path = "/icon-Tecnology"},
                //new Skill { Name = "Composite",                                         Path = "/icon-Tecnology"},
                //new Skill { Name = "Composite",                                         Path = "/icon-Tecnology"},
                //new Skill { Name = "Facade",                                            Path = "/icon-Tecnology"},
                //new Skill { Name = "Flyweight",                                         Path = "/icon-Tecnology"},
                //new Skill { Name = "Proxy",                                             Path = "/icon-Tecnology"},
                //new Skill { Name = "Command",                                           Path = "/icon-Tecnology"},
                //new Skill { Name = "Chain of responsibility",                           Path = "/icon-Tecnology"},
                //new Skill { Name = "Interpreter",                                       Path = "/icon-Tecnology"},
                //new Skill { Name = "Iterator",                                          Path = "/icon-Tecnology"},
                //new Skill { Name = "Iterator",                                          Path = "/icon-Tecnology"},
                //new Skill { Name = "Memento",                                           Path = "/icon-Tecnology"},
                //new Skill { Name = "Observer",                                          Path = "/icon-Tecnology"},
                //new Skill { Name = "State",                                             Path = "/icon-Tecnology"},
                //new Skill { Name = "Strategy",                                          Path = "/icon-Tecnology"},
                //new Skill { Name = "Template Method",                                   Path = "/icon-Tecnology"},
                //new Skill { Name = "Visitor",                                           Path = "/icon-Tecnology"}
            };

        public static IEnumerable<User> Users =>
            new User[]
            {
                //new User
                //{
                //    Id = Guid.Parse("7A5B3C6E-7E95-435E-B46F-1F449F49BE04"),
                //    Email = "jeffreyissaul@hotmail.com",
                //    Subject = "auth0|5f0c49e03e0de80013aa852c",
                //    Role = "Profesional"
                //},
                new User
                {
                    Id = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),
                    Email = "luiseduardofrias27@gmail.com",
                    Subject = "auth0|5f2eb494022f3a003d353973",
                    Role = "Contratista"
                }//,
                //new User
                //{
                //    Id = Guid.Parse("d2b17c1e-205c-4167-8219-08d839ce621a"),
                //    Email = "jessejose@outlook.es",
                //    Subject = "auth0|5f2b8e5d58e286003737cd4a",
                //    Role = "Contratista"
                //}
            };

        public static IEnumerable<LegalDocument> LegalDocuments =>
            new LegalDocument[]
            {
                //new LegalDocument
                //{
                //    Id = Guid.Parse("8B817101-C051-4BF4-8A1E-ECC2BB32B613"),
                //    Number = "123-4567789-0",
                //    Image = new byte[] { 1,1,1,1,1,1,1,1 },
                //    DocumentTypeId = Guid.Parse("189EE312-AFD2-4145-9687-585D001F23E7")
                //},
                new LegalDocument
                {
                    Id = Guid.Parse("CE3695B2-CCF1-4521-A3EB-DAE703FFBDFB"),
                    Number = "123-4567789-0",
                    Image = new byte[] { 1,1,1,1,1,1,1,1 },
                    DocumentTypeId = Guid.Parse("189EE312-AFD2-4145-9687-585D001F23E7")
                }
            };

        public static IEnumerable<PersonalInfo> PersonalInfos =>
            new PersonalInfo[]
            {
                //new PersonalInfo
                //{
                //    Id = Guid.Parse("73415AAD-60B5-4179-8E2E-C76D9CA64529"),
                //    Name = "Jeffrey Jose",
                //    PhoneNumber = "8091234567",
                //    Description = @"Jeffrey es un experimentado desarrollador full stack especializado en                  seguridad informatica y desarrollo multiplataformas",
                //    PagLink = "www.abc.com",
                //    LegalDocumentId = Guid.Parse("8B817101-C051-4BF4-8A1E-ECC2BB32B613"),
                //    UserId = Guid.Parse("7A5B3C6E-7E95-435E-B46F-1F449F49BE04")
                //},
                new PersonalInfo
                {
                    Id = Guid.Parse("02F30D25-73D1-47DA-83FB-07753ED4DD83"),
                    Name = "Luis Eduardo",
                    PhoneNumber = "8097654321",
                    Description = @"Luis es un desarrollador de software con 5 años de experiencia como 
                                   full stack web developer",
                    PagLink = "www.def.com",
                    LegalDocumentId = Guid.Parse("CE3695B2-CCF1-4521-A3EB-DAE703FFBDFB"),
                    UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84")
                }
            };

        //public static IEnumerable<ProfesionalSkill> ProfesionalSkills =>
        //    new ProfesionalSkill[]
        //    {
        //        new ProfesionalSkill
        //        {
        //            Percentage = 70,
        //            PersonalInfoId = Guid.Parse("73415AAD-60B5-4179-8E2E-C76D9CA64529"),
        //            SkillId = Guid.Parse("0F5F4AE9-4E26-4A38-B2D1-A5338AF48BAA")
        //        },
        //        new ProfesionalSkill
        //        {
        //            Percentage = 80,
        //            PersonalInfoId = Guid.Parse("73415AAD-60B5-4179-8E2E-C76D9CA64529"),
        //            SkillId = Guid.Parse("D99EBA61-53CC-41E1-AFEE-5C99A6AF102A")
        //        },
        //        new ProfesionalSkill
        //        {
        //            Percentage = 50,
        //            PersonalInfoId = Guid.Parse("73415AAD-60B5-4179-8E2E-C76D9CA64529"),
        //            SkillId = Guid.Parse("1EA43D00-8DC7-4B82-96E0-EABFEA74C9B9")
        //        }
        //    };

        public static IEnumerable<Project> Projects =>
        new Project[]
        {
             new Project
             {
               Name = "Administrador de seguridad y sistema",

               Description ="Experiencia administrando: -Windows Server (Active Directory, DNS, GPO, Webserver IISS, Cluster, NPS, Certificados) -Virtualizacion (WMWare, Hiper V) -Office 365 -Servidores de Almacenamiento Storage -Azure -Seguridad Endpoint Protection Preparación Académica -Ingeniero en Sistemas -Certificaciones en Windows Server y Comptia Mínimo dos años de experiencia en Labores Similares (Deseable)",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Administrador de Base de Datos Senior, (DBA)",

               Description = "Necesitamos un candidato con experiencia ADMINISTRADOR DE BASE DE DATOS (DBA)   Profesional del área de informática. Conocimientos MySQL, ORACLE, SQL, ETC Poseer un buen conocimiento técnico de las bases de datos y lenguajes de consulta Mínimo 2 años de experiencia en posiciones similares Tener capacidad de organización. Tener un enfoque lógico para la resolución de problemas. Prestar atención a los detalles. Tener capacidad de planificación y de previsión. Poseer aptitudes para el trabajo en equipo Competencias Aptitudes para la comunicación verbal y escrita. Aptitudes para la planificación. Asesora a directivos sobre problemas relacionados con bases de datos. Capacidad para trabajar en equipo. Capacidades organizativas. Capaz de mantenerse al día de los avances tecnológicos. Capaz de prestar atención al detalle. Capaz de trabajar bajo presión. Conocimientos especializados en informática.   El salario según experiencia.",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "DESARROLLADOR LIDER TECNICO (LEAD TECHNICAL DEVELOPER)",

               Description = "Frameworks: .NET Core, Angular (Avanzado) Metodología Scrum (Avanzado) DevOps (Continuous Integration / Deployment) Database deployment (SQL Server / Oracle) Conocimiento arquitectura N-Tier Experiencia mínima de 8 años / Hoja de proyectos comprobable como Desarrollador Líder",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "PRODUCT OWNER",

               Description ="Certificaciones como Product Owner Scrum (o cursos realizados) Experiencia / Hoja de proyectos realizados en este rol Excelentes habilidades de comunicación, presentación de informes. Trabajo en un proyecto de 6 meses de duración, Salario negociable y excelentes beneficios",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Sr. ERP Developer Analyst",

               Description ="Sr. ERP Developer Analyst Location: Santiago de los Caballeros, DR IT Professional or equivalent experience. 4 years of experience in web development in any language/platform. Experience in business needs and reports, using PowerPlatform (PowerApps, PowerBI and Flow). Develop solutions for SharePoint, Infopath and ERP systems, such as Ms Dynamics Nav. Work on the integration of multiples systems. Intermediate level of English skill. Curently reside at Santiago, DR or availability to change residence.",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Data Analyst - Power BI",

               Description ="Data Analyst - Power BI Location: Santiago de los Caballeros, DR - On site Computer Science Professional / Student. 3 years of experience in data analystics using Ms Power Bi (required). Expert analizing data using Ms Power Bi. Responsible of analyzing/understanding the data structure and developing insightful reports based on each company/department needs. High domain on collects and analyzes data to evaluating and developing reports using Power BI. Develop database solution to retrieve and store data from multiple sources. Intermediate English skills. Strong analytical and problem solving skills, detail oriented, organization, strong collaboration and team work. Curently reside at Santiago de los Caballeros DR or availability to change residence.",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Front End Developer",

               Description ="Front End Developer Full contract - Remote A degree in a CS, design-related field, or equivalent experience. 3 years of experience building awesome interfaces of web developement in HTML, CSS and JavaScript. Experience in web design to work with the EH development team on web application. Solid understanding of UX and SEO management. Excellent knowledge of front-end web technologies and frameworks. Experience implementing cross-browser compatible sites. Advanced English skills, both oral and written. (indispensable).",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Software QA Engineerr",

               Description ="Software QA Engineer Location: Santo Domingo, DR. - On site Computer Science Professional / Student. + 3 years of experience software development and software quality assurance (is a must). Responsible of review requirements, specifications, and technical design documents to provide timely and meaningful feedback. Strong knowledge of software QA methodologies, tools and processes. Hands-on experience with automated testing tools. Experience working in an Agile/Scrum development process. Create detailed, comprehensive, and well-structured test plans and test cases. Design, develop, and execute automation scripts using open source tools. Perform thorough regression testing when bugs are resolved. Identify, record, document thoroughly and track bugs. Advanced English skills.",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Full Stack Developer",

               Description ="Full Stack Developer Full contract - Remote Computer Science Professional or equivalent experience. 3 years experience in software development, in at least one of the following - Python, C++, C# Experience in back end and front end development. High domain with a compiled, strongly-typed language. and HTML, CSS, JS and SQL. Work in an Agile/Scrum environment to deliver high quality software. Advanced English skills, both oral and written (indispensable). Data science and machine learning experience is a plus.",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Remote HTML/CSS and WordPress Develope",

               Description ="--",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "QUALITY ASSURANCE",

               Description ="---",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "SENIOR iOS DEVELOPER",

               Description =@"We’re a USA based company in Miami, FL, and Santiago DR, and we’re looking for candidates like you to fill an IOS Developer position that focuses on designing/implementing the overall architecture of mobile applications that interacts with complex API’s and implement complex business logic and an awesome UI/UX. We’d love to hear from qualified, self-learner and proactive people that loves creating wonderful and scalable apps with high quality and standardized code.
                              Expertise in:
                            - Apple’s Xcode IDE
                            - Swift (3.0 and above).
                            - Both iPhone and iPad Apps and Architectures
                            - Apple Frameworks and APIs
                            
                            Vast Knowledge of:
                            
                            - Mobile development and best practices
                            - Application life cycle including Certificates, Profiles and Publishing to the App Store
                            - Strong understanding of security best practices at the application and network level
                            - UI and UX design experience
                            - Consuming REST APIs and JSON data.
                            - Apple Human Interface Guidelines
                            - Implementation of Push Notifications
                            - Git code repository technology
                            
                            Ideal / Optional / Plus:
                            
                            - TFS
                            - Jira
                            - Scrum and Agile methodologies",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
            new Project
             {
               Name = "FullStack .Net Developer",

               Description =@"Expeciencia y Conocimiento en las siguientes tecnologias:
        
                            C#
                            Angular 7, React o AngularJS
                            .NET Core 2.2, 3.1
                            HTML5, CSS3 y Bootstrap
                            Entity Framework / Core
                            MSSQL
                            Deseable que tenga experiencia con:
                
                            Azure Azure App Services
                            Azure Functions
                            API Management
                            Practicas tecnicas deseables:
                            Patrones de diseño de software
                            Principios SOLID
                            Unit Testing
                            Integration Testing
                            Git Flow
                            Continuous Integration
                            Beneficios:
        
                            Salario competitivo - Rango de RD$ 60,000.00 a RD$ 100,000.00 segun experiencia.
                            Beneficios de ley
                            100% de cobertura en el costo de Plan Royal (ARS Humano)
                            Buen ambiente de trabajo",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Angular Developer",

               Description =@"Experiencia comprobable en desarrollo de aplicaciones web con Angular 7 y AngularJS .
                                Experiencia con Git y en el uso del Git Workflow.
                                Capacidad de escribir buena documentación para el código y los procesos implementados.
                                Conocimiento de los principios SOLID y Clean Code
                                Tecnologias:
                 
                                JavaScript (ES6, Webpack, npm)
                                HTML
                                CSS
                                JSON and RESTful Web Services
                                JWT
                                bootstrap 3
                                GIT
                                Deseable que tenga experiencia con:
        
                                Azure App Services
                                Azure Functions
                                Azure API Management
                                Practicas tecnicas deseables:
                                Patrones de diseno
                                Principios SOLID
                                Unit Testing
                                Integration Testing
                                Git Flow
                                Continuous Integration
                                Beneficios:
        
                                Salario competitivo - Rango RD$ 60,000.00 a RD$ 100,000.00 segun experiencia y dominio de las practicas tecnicas.
                                Beneficios de ley
                                100% de cobertura en el costo de Plan Royal (ARS Humano)
                                Buen ambiente de trabajo
                                Trabajo remoto - 9:00 AM to 6:00PM",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Se Busca Desorrolladores En IONIc",

               Description =@"*SE BUSCA DESARROLLADOR EN IONIC* *SKILLS* Conocimientos en HTML,CSS, JavaScript , Angular y algun framework de diseño como BS Conocimientos en NodeJS Conocimientos de TypeORM y SQL *Horario* Lunes-Viernes 9AM-4PM *Localizacion* Actualmente remoto pero con posibilidad de movernos a una oficina en SFM. 
        
                             *Honorarios* Negociable+Incentivos.
        
                            *CONTACTOS* j.a.jerez88@gmail.com ",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Java Developer",

               Description =@"What’s in It for You
                            - The ability to make an impact and have a career path with a company that is passionate about growth.
                            - The chance to work on innovative solutions that transforms existing challenges and expanding your perspective, working with international and local clients.
                            - The opportunity to have a healthy, stable workplace environment and a geek culture.
        
                            Responsibilities:
                            • Application development and involvement throughout a typical application development lifecycle.
                            • Involvement in projects, where you'll be able to produce solutions for identified opportunities in a timely manner.
                            • Provide quality, robust and consistent solutions to project initiatives, in the time specified by the level of effort proposed.
                            • Handle fixes and enhancements for existing applications.
                            • Participate in internal technical forums and status meetings.
                            • Provide continuous oral and written status and feedbacks to management.
        
                            Must have:
                            • Java development experience.
        
                            Experience in:
                            • GIT or similar version control systems.
                            • RESTful services.
                            • SQL
        
                            Nice to have:
                            •Angular
                            •JavaScript
                            •CI/CD
                            •Spring MVC
                            •Spring boot
                            •Unit Testing",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             },
             new Project
             {
               Name = "Graphic Designer - Mid",

               Description =@"GBH is a company with specialized divisions in software (mobile, web, big data), information technology, consulting and execution of digital marketing initiatives. In GBH, we develop initiatives that provide measurable results to our clients in the aforementioned business units. We strive to serve as a strategic ally in the pursue of innovation, development and growth of their businesses.
        
                     Description
        
                    The Graphic Designer is responsible for preparing (designing) the posts and publications for the different accounts that the company manages. He/she must also make internal and external modifications(as requested by the client) of the parts produced by him/her or any of his colleagues.
        
        
                    Objectives
        
        
                    Help build or improve the graphic line of each of the brands you will work with.
                    Create as many memorable designs for the brand you work with.
                    Ensure the care and understanding of each of their designs, considering visual sensitivity and good taste.
                    Responsibilities
        
                    Make sketches and other graphic designs of your competition.
                    Make drawings and / or paintings for the preparation of advertising pieces.
                    Make illustrations, notices, articles and general advertising for the different media.
                    Create animated pieces like gifts or videos.
                    Review and correct the designed material.
                    Coordinate with the authors of the texts (community), the graphic design of the publications.
                    Comply with the rules and procedures on comprehensive security, established by the organization.
                    Keep equipment and work site in order, reporting any anomaly.
                    Participate in the creation or design of presentations to offer or sell products or services to clients or potential clients.
                    Stay up-to-date on the latest trends in the design area and news on the tools you use
                    Requirements
                    ",

               PublishDate = DateTime.Now,

               UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),

               PostulantsLimit = 10,

               CloseDate = DateTime.Now + TimeSpan.FromDays(15),

               IsOpen = true

             }

        };

    }
}
