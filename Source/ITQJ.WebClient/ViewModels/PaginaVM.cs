using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebClient.ViewModels
{
    public class PaginaVM
    {
        public int PaginaActual { get; set; } = 1;
        public int PaginasTotales { get; set; }
        public int Radio { get; set; } = 3;
        public EventCallback<int> PaginaSeleccionada { get; set; }

        public List<PaginaM> paginas = new List<PaginaM>();

        public void OnParametersSet()
        {
            CargarPaginas();
        }

        private async Task PaginaSeleccionadaInterno(PaginaM pagina)
        {
            if (pagina.Pagina == PaginaActual)
            {
                return;
            }

            if (!pagina.Habilitada)
            {
                return;
            }

            PaginaActual = pagina.Pagina;

            CargarPaginas();

            await PaginaSeleccionada.InvokeAsync(pagina.Pagina);
        }


        private void CargarPaginas()
        {
            paginas = new List<PaginaM>
                ();
            var PaginaAnteriorHabilitada = PaginaActual != 1;
            var paginaAnterior = (PaginaActual == 1) ? 1 : PaginaActual - 1;
            paginas.Add(new PaginaM(paginaAnterior, PaginaAnteriorHabilitada, "Anterior"));

            for (int i = 1; i <= PaginasTotales; i++)
            {
                if (i >= PaginaActual - Radio && i <= PaginaActual + Radio)
                {
                    paginas.Add(new PaginaM(i) { Activa = PaginaActual == i });
                }
            }

            var paginaSiguienteHabilitada = PaginaActual != PaginasTotales;
            var paginaSiguiente = (PaginaActual == PaginasTotales) ? PaginasTotales : PaginaActual + 1;
            paginas.Add(new PaginaM(paginaSiguiente, paginaSiguienteHabilitada, "Siguiente"));
        }

    }
}
