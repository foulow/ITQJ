using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Models
{
    public class SkillM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public int Percentage { get; set; }

        public bool Active { get; set; }
    }
}
