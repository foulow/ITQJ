using IdentityModel;
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
    }
}
