using System;
using System.Collections.Generic;

namespace ITQJ.WebPWA.VMs
{
    public class ProjectVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime CloseDate { get; set; }

        public int PostulantsLimit { get; set; }

        public bool IsOpen { get; set; }

        public ICollection<PostulantVM> Postulants { get; set; }
        public ICollection<MessageVM> Messages { get; set; }
    }
}
