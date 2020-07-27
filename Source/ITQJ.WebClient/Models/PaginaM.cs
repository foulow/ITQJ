namespace ITQJ.WebClient.Models
{
    public class PaginaM
    {
        public PaginaM(int pagina) : this(pagina, true)
        {

        }

        public PaginaM(int pagina, bool habilitada) : this(pagina, habilitada, pagina.ToString())
        {

        }

        public PaginaM(int pagina, bool habilitada, string texto)
        {
            Pagina = pagina;
            Habilitada = habilitada;
            Texto = texto;
        }

        public string Texto { get; set; }
        public int Pagina { get; set; }
        public bool Habilitada { get; set; }
        public bool Activa { get; set; }
    }
}
