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
                new DocumentType { Name = "Lisencia de conducir"}
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
    }
}
