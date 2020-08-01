using IdentityModel;
using ITQJ.Domain.DTOs;
using ITQJ.Domain.Models;
using System;
using System.Collections.Generic;

namespace ITQJ.EFCore
{
    public class DataConfig
    {
        public static IEnumerable<Role> Roles =>
            new Role[]
            {
                new Role {
                    Id = Guid.Parse("31BE72FD-BE58-492A-8976-57FF74DAEB7A"),
                    Name = "Profesional"
                },
                new Role {
                    Id = Guid.Parse("3D3B586A-EC26-42A3-A63A-026492FFC298"),
                    Name = "Contratista"
                }
            };

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
                new Skill {
                    Id = Guid.Parse("0F5F4AE9-4E26-4A38-B2D1-A5338AF48BAA"),
                    Name = "C",
                    Path = "/icon-Tecnology/C.png"
                },
                new Skill {
                    Id = Guid.Parse("D99EBA61-53CC-41E1-AFEE-5C99A6AF102A"),
                    Name = "C++",
                    Path = "/icon-Tecnology/CPlus.png"
                },
                new Skill {
                    Id = Guid.Parse("1EA43D00-8DC7-4B82-96E0-EABFEA74C9B9"),
                    Name = "C#",
                    Path = "/icon-Tecnology/CSharp.png"
                },
                new Skill { Name = "VB.Net", Path = "/icon-Tecnology/CPlus.png"},
                new Skill { Name = "Objective-C", Path = "/icon-Tecnology/visual-basic.png"},
                new Skill { Name = "Swift", Path = "/icon-Tecnology/swift.png"},
                new Skill { Name = "Java", Path = "/icon-Tecnology/java.png"},
                new Skill { Name = "JavaScript", Path = "/icon-Tecnology/javascript.png"},
                new Skill { Name = "Python", Path = "/icon-Tecnology/python.png"},
                new Skill { Name = "PHP", Path = "/icon-Tecnology/php.png"},
                new Skill { Name = "Go", Path = "/icon-Tecnology/Go.png"},
                new Skill { Name = "Dark", Path = "/icon-Tecnology/Dart.png"},
                new Skill { Name = "SQL", Path = "/icon-Tecnology/SQL.png"},
                new Skill { Name = "T-SQL", Path = "/icon-Tecnology/T-SQL.png"},
                new Skill { Name = "MySQL", Path = "/icon-Tecnology/CPlus.png"},
                new Skill { Name = "PostgreSQL", Path = "/icon-Tecnology/mysql.png"},
                new Skill { Name = "Git", Path = "/icon-Tecnology/github.png"},
                new Skill { Name = "HTML5", Path = "/icon-Tecnology/html5.png"},
                new Skill { Name = "CSS3", Path = "/icon-Tecnology/css3.png"},
                new Skill { Name = "Boostrap", Path = "/icon-Tecnology/bootstrap.png"},
            };

        public static IEnumerable<User> Users =>
            new User[]
            {
                new User
                {
                    Id = Guid.Parse("7A5B3C6E-7E95-435E-B46F-1F449F49BE04"),
                    Email = "jeffreyissaul@hotmail.com",
                    UserName = "issaul",
                    Password = "password".ToSha256(),
                    RoleId = Guid.Parse("31BE72FD-BE58-492A-8976-57FF74DAEB7A")
                },
                new User
                {
                    Id = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84"),
                    Email = "luis@hotmail.com",
                    UserName = "luis",
                    Password = "password".ToSha256(),
                    RoleId = Guid.Parse("3D3B586A-EC26-42A3-A63A-026492FFC298")
                }
            };

        public static IEnumerable<LegalDocument> LegalDocuments =>
            new LegalDocument[]
            {
                new LegalDocument
                {
                    Id = Guid.Parse("8B817101-C051-4BF4-8A1E-ECC2BB32B613"),
                    Number = "123-4567789-0",
                    Image = new byte[] { 1,1,1,1,1,1,1,1 },
                    DocumentTypeId = Guid.Parse("189EE312-AFD2-4145-9687-585D001F23E7")
                },
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
                new PersonalInfo
                {
                    Id = Guid.Parse("73415AAD-60B5-4179-8E2E-C76D9CA64529"),
                    Name = "Jeffrey Jose",
                    PhoneNumber = "8091234567",
                    Description = "abc",
                    PagLink = "www.abc.com",
                    LegalDocumentId = Guid.Parse("8B817101-C051-4BF4-8A1E-ECC2BB32B613"),
                    UserId = Guid.Parse("7A5B3C6E-7E95-435E-B46F-1F449F49BE04")
                },
                new PersonalInfo
                {
                    Id = Guid.Parse("02F30D25-73D1-47DA-83FB-07753ED4DD83"),
                    Name = "Luis Eduardo",
                    PhoneNumber = "8097654321",
                    Description = "def",
                    PagLink = "www.def.com",
                    LegalDocumentId = Guid.Parse("CE3695B2-CCF1-4521-A3EB-DAE703FFBDFB"),
                    UserId = Guid.Parse("E80F88AF-C61E-4500-A77E-8EDE80538B84")
                }
            };

        public static IEnumerable<ProfesionalSkill> ProfesionalSkills =>
            new ProfesionalSkill[]
            {
                new ProfesionalSkill
                {
                    Percentage = 70,
                    PersonalInfoId = Guid.Parse("73415AAD-60B5-4179-8E2E-C76D9CA64529"),
                    SkillId = Guid.Parse("0F5F4AE9-4E26-4A38-B2D1-A5338AF48BAA")
                },
                new ProfesionalSkill
                {
                    Percentage = 80,
                    PersonalInfoId = Guid.Parse("73415AAD-60B5-4179-8E2E-C76D9CA64529"),
                    SkillId = Guid.Parse("D99EBA61-53CC-41E1-AFEE-5C99A6AF102A")
                },
                new ProfesionalSkill
                {
                    Percentage = 50,
                    PersonalInfoId = Guid.Parse("73415AAD-60B5-4179-8E2E-C76D9CA64529"),
                    SkillId = Guid.Parse("1EA43D00-8DC7-4B82-96E0-EABFEA74C9B9")
                }
            };


            public static IEnumerable<Project> Project =>
            new Project[]
            {
                 new Project
                 {
                   Name = "Administrador de seguridad y sistema",

                   Description ="Experiencia administrando: -Windows Server (Active Directory, DNS, GPO, Webserver IISS, Cluster, NPS, Certificados) -Virtualizacion (WMWare, Hiper V) -Office 365 -Servidores de Almacenamiento Storage -Azure -Seguridad Endpoint Protection Preparación Académica -Ingeniero en Sistemas -Certificaciones en Windows Server y Comptia Mínimo dos años de experiencia en Labores Similares (Deseable)",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "Administrador de Base de Datos Senior, (DBA)",

                   Description = "Necesitamos un candidato con experiencia ADMINISTRADOR DE BASE DE DATOS (DBA)   Profesional del área de informática. Conocimientos MySQL, ORACLE, SQL, ETC Poseer un buen conocimiento técnico de las bases de datos y lenguajes de consulta Mínimo 2 años de experiencia en posiciones similares Tener capacidad de organización. Tener un enfoque lógico para la resolución de problemas. Prestar atención a los detalles. Tener capacidad de planificación y de previsión. Poseer aptitudes para el trabajo en equipo Competencias Aptitudes para la comunicación verbal y escrita. Aptitudes para la planificación. Asesora a directivos sobre problemas relacionados con bases de datos. Capacidad para trabajar en equipo. Capacidades organizativas. Capaz de mantenerse al día de los avances tecnológicos. Capaz de prestar atención al detalle. Capaz de trabajar bajo presión. Conocimientos especializados en informática.   El salario según experiencia.",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "DESARROLLADOR LIDER TECNICO (LEAD TECHNICAL DEVELOPER)",

                   Description = "Frameworks: .NET Core, Angular (Avanzado) Metodología Scrum (Avanzado) DevOps (Continuous Integration / Deployment) Database deployment (SQL Server / Oracle) Conocimiento arquitectura N-Tier Experiencia mínima de 8 años / Hoja de proyectos comprobable como Desarrollador Líder",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "PRODUCT OWNER",

                   Description ="Certificaciones como Product Owner Scrum (o cursos realizados) Experiencia / Hoja de proyectos realizados en este rol Excelentes habilidades de comunicación, presentación de informes. Trabajo en un proyecto de 6 meses de duración, Salario negociable y excelentes beneficios",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "Sr. ERP Developer Analyst",

                   Description ="Sr. ERP Developer Analyst Location: Santiago de los Caballeros, DR IT Professional or equivalent experience. 4 years of experience in web development in any language/platform. Experience in business needs and reports, using PowerPlatform (PowerApps, PowerBI and Flow). Develop solutions for SharePoint, Infopath and ERP systems, such as Ms Dynamics Nav. Work on the integration of multiples systems. Intermediate level of English skill. Curently reside at Santiago, DR or availability to change residence.",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "Data Analyst - Power BI",

                   Description ="Data Analyst - Power BI Location: Santiago de los Caballeros, DR - On site Computer Science Professional / Student. 3 years of experience in data analystics using Ms Power Bi (required). Expert analizing data using Ms Power Bi. Responsible of analyzing/understanding the data structure and developing insightful reports based on each company/department needs. High domain on collects and analyzes data to evaluating and developing reports using Power BI. Develop database solution to retrieve and store data from multiple sources. Intermediate English skills. Strong analytical and problem solving skills, detail oriented, organization, strong collaboration and team work. Curently reside at Santiago de los Caballeros DR or availability to change residence.",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "Front End Developer",

                   Description ="Front End Developer Full contract - Remote A degree in a CS, design-related field, or equivalent experience. 3 years of experience building awesome interfaces of web developement in HTML, CSS and JavaScript. Experience in web design to work with the EH development team on web application. Solid understanding of UX and SEO management. Excellent knowledge of front-end web technologies and frameworks. Experience implementing cross-browser compatible sites. Advanced English skills, both oral and written. (indispensable).",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "Software QA Engineerr",

                   Description ="Software QA Engineer Location: Santo Domingo, DR. - On site Computer Science Professional / Student. + 3 years of experience software development and software quality assurance (is a must). Responsible of review requirements, specifications, and technical design documents to provide timely and meaningful feedback. Strong knowledge of software QA methodologies, tools and processes. Hands-on experience with automated testing tools. Experience working in an Agile/Scrum development process. Create detailed, comprehensive, and well-structured test plans and test cases. Design, develop, and execute automation scripts using open source tools. Perform thorough regression testing when bugs are resolved. Identify, record, document thoroughly and track bugs. Advanced English skills.",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "Full Stack Developer",

                   Description ="Full Stack Developer Full contract - Remote Computer Science Professional or equivalent experience. 3 years experience in software development, in at least one of the following - Python, C++, C# Experience in back end and front end development. High domain with a compiled, strongly-typed language. and HTML, CSS, JS and SQL. Work in an Agile/Scrum environment to deliver high quality software. Advanced English skills, both oral and written (indispensable). Data science and machine learning experience is a plus.",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "Remote HTML/CSS and WordPress Develope",

                   Description ="--",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "QUALITY ASSURANCE",

                   Description ="---",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

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

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

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

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

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

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 },
                 new Project
                 {
                   Name = "Se Busca Desorrolladores En IONIc",

                   Description =@"*SE BUSCA DESARROLLADOR EN IONIC* *SKILLS* Conocimientos en HTML,CSS, JavaScript , Angular y algun framework de diseño como BS Conocimientos en NodeJS Conocimientos de TypeORM y SQL *Horario* Lunes-Viernes 9AM-4PM *Localizacion* Actualmente remoto pero con posibilidad de movernos a una oficina en SFM. 

                                 *Honorarios* Negociable+Incentivos.

                                *CONTACTOS* j.a.jerez88@gmail.com ",

                   PublishDate = DateTime.Now,

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

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

                   UserId = Guid.Parse(""),

                   PostulantsLimit = 0,

                   CloseDate = DateTime.Now,

                   IsOpen = true

                 }

            };

    }
}
