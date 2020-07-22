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
                new Skill { Name = "C"},
                new Skill { Name = "C++"},
                new Skill { Name = "C#"},
                new Skill { Name = "VB.Net"},
                new Skill { Name = "Objective-C"},
                new Skill { Name = "Swift"},
                new Skill { Name = "Java"},
                new Skill { Name = "JavaScript"},
                new Skill { Name = "Python"},
                new Skill { Name = "PHP"},
                new Skill { Name = "Go"},
                new Skill { Name = "Dark"},
                new Skill { Name = "SQL"},
                new Skill { Name = "T-SQL"},
                new Skill { Name = "MySQL"},
                new Skill { Name = "PostgreSQL"},
                new Skill { Name = "Git"},
                new Skill { Name = "HTML"},
                new Skill { Name = "CSS"},
                new Skill { Name = "Boostrap"},
            };

        public static IEnumerable<User> Users =>
            new User[]
            {
                new User
                {
                    Email = "jeffreyissaul@hotmail.com",
                    UserName = "issaul",
                    //Password = "password".ToSha256(),
                    Password = "password",
                    RolId = 1
                },
                new User
                {
                    Email = "luis@hotmail.com",
                    UserName = "luis",
                    //Password = "password".ToSha256(),
                    Password = "password",
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
                    PersonalInfoId = 1,
                    SkillId = 1
                },
                new ProfesionalSkill
                {
                    PersonalInfoId = 1,
                    SkillId = 5
                },
                new ProfesionalSkill
                {
                    PersonalInfoId = 1,
                    SkillId = 12
                }
            };
    }
}
