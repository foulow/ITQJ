using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebPWA.Entitdades
{
    public class Skill
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public int Percentage { get; set; } = 10;

        public bool Active { get; set; } = false;

    }
}
