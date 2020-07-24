using IdentityModel;
using ITQJ.Domain.Models;
using System.Collections.Generic;

namespace ITQJ.EFCore
{
    public class DataConfig
    {
        public static IEnumerable<Rol> Roles =>
            new Rol[]
            {
                new Rol { Name = "Profesional" },
                new Rol { Name = "Contratista" }
            };

        public static IEnumerable<DocumentType> DocumentTypes =>
            new DocumentType[]
            {
                new DocumentType { Name = "Cédula"},
                new DocumentType { Name = "Pasaporte"},
                new DocumentType { Name = "RCN"}
            };

        public static IEnumerable<Skill> Skills =>
            new Skill[]
            {
                new Skill { Name = "C", Path = "/icon-Tecnology/C.png"},
                new Skill { Name = "C++", Path = "/icon-Tecnology/CPlus.png"},
                new Skill { Name = "C#", Path = "/icon-Tecnology/CSharp.png"},
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
                    Email = "jeffreyissaul@hotmail.com",
                    UserName = "issaul",
                    Password = "password".ToSha256(),
                    RolId = 1
                },
                new User
                {
                    Email = "luis@hotmail.com",
                    UserName = "luis",
                    Password = "password".ToSha256(),
                    RolId = 2
                }
            };

        public static IEnumerable<LegalDocument> LegalDocuments =>
            new LegalDocument[]
            {
                new LegalDocument
                {
                    Number = "123-4567789-0",
                    Image = new byte[] { 1,1,1,1,1,1,1,1 },
                    DocumentTypeId = 1
                },
                new LegalDocument
                {
                    Number = "123-4567789-0",
                    Image = new byte[] { 1,1,1,1,1,1,1,1 },
                    DocumentTypeId = 3
                }
            };
        public static IEnumerable<PersonalInfo> PersonalInfos =>
            new PersonalInfo[]
            {
                new PersonalInfo
                {
                    Name = "Jeffrey Jose",
                    PhoneNumber = "8091234567",
                    Description = "abc",
                    PagLink = "www.abc.com",
                    LegalDocumentId = 1,
                    UserId = 1
                },
                new PersonalInfo
                {
                    Name = "Luis Eduardo",
                    PhoneNumber = "8097654321",
                    Description = "def",
                    PagLink = "www.def.com",
                    LegalDocumentId = 2,
                    UserId = 2
                }
            };

        public static IEnumerable<ProfesionalSkill> ProfesionalSkills =>
            new ProfesionalSkill[]
            {
                new ProfesionalSkill
                {
                    Percentage = 70,
                    PersonalInfoId = 1,
                    SkillId = 1
                },
                new ProfesionalSkill
                {
                    Percentage = 80,
                    PersonalInfoId = 1,
                    SkillId = 5
                },
                new ProfesionalSkill
                {
                    Percentage = 50,
                    PersonalInfoId = 1,
                    SkillId = 12
                }
            };
    }
}
