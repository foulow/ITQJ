using ITQJ.WebPWA.Entidades;
using System.Collections.Generic;

namespace ITQJ.WebPWA.VMs
{
    public class PersonalInfoVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string PagLink { get; set; }

        public virtual LegalDocumentVM LegalDocument { get; set; }

        public virtual UserVM User { get; set; }

        public virtual ICollection<Skill> ProfesionalSkills { get; set; }
    }
}
