namespace ITQJ.WebPWA.Entidades
{
    public class Skill
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public int Percentage { get; set; } = 10;

        public bool Active { get; set; } = false;
    }
}
