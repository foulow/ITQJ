using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ITQJ.WebClient.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public IActionResult Index()
        {
            PaginaVM paginaVM = new PaginaVM();
            paginaVM.PaginaActual = 1;
            paginaVM.PaginasTotales = 10;
            paginaVM.OnParametersSet();

            List<Object> listobject = new List<Object>();

            listobject.Add(ListPer);
            listobject.Add(paginaVM.paginas);

            return View(listobject);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public List<projectt> ListPer = new List<projectt>()
        {
            new projectt()
            {
                nombre = "En una cartulina grande, necesito una pintura o un dibujo de un anillo de compromiso y un arte romántico que lo rodea. Necesito poder recoger esto en el área del DMV antes del viernes por la tarde.",
                fechaPublicacion = "14/7/2020",
                fechaCierre = "20/7/2020",
                empleador = "Jian contrerar",
                AbilidadesRequeridas = "Caricature & Cartoons Illustrator Photoshop",
                descriccionEmpleo = " lista de las cosas india necesaria proyecto cartulina , grandes plantillas de carteles photoshop , 50 de cartulina , para imprimir grandes carteles adicional , Adobe aplicación de aire de pintura dibujar , chicas del manga dibujan pintura pdf descarga, Proyecto terminado cartulina mirada , cartulina casino , Adobe Flex dibujar pintura , gran photoshop plantilla del cartel , chicas del manga dibujan pdf pintura , las partidas de cartulina, pintura de dibujo flexible , cartulina para hacer pancartas , diseños creativos de cartulina , dibujar pintura , dibujar aplicación de pintura as3 , dibujar ilustrador de pintura, cómo hacer una cartulina en powerpoint , cómo hacer un collage de imágenes en cartulina"
            },
            new projectt()
            {
                nombre = "palacio salvo ",
                fechaPublicacion = "11/7/2020",
                fechaCierre = "5/8/2020",
                empleador = "marlon martines",
                AbilidadesRequeridas = "Modelado 3D 3ds Max AutoCAD ",
                descriccionEmpleo = "buen dia. Estoy evaluando apoyo para poder asumir un proyecto personal. Lo que adjunto son referencias visuales para comprender el volumen general. Al ser el edificio parametrico puede apreciarse que solo es necesario resolver una cara y las demas son iguales. Se dispone de un dossier con..."
            },
            new projectt()
            {
                nombre = "Inteligencia Artificial Faltan",
                fechaPublicacion = "5/7/2020",
                fechaCierre = "15/7/2020",
                empleador = "maria",
                AbilidadesRequeridas = "Python de codificación de inteligencia artificial",
                descriccionEmpleo = "Necesito un experto en inteligencia artificial que me ayude con un proyecto."
            },
            new projectt()
            {
                nombre = "Volver a dibujar dibujos de ilustradores Faltan",
                fechaPublicacion = "20/6/2020",
                fechaCierre = "",
                empleador = "Team Cherry",
                AbilidadesRequeridas = "Adobe Illustrator Diseño gráfico",
                descriccionEmpleo = "Tenemos un conjunto de dibujos lineales de piscinas que deben limpiarse. Se adjunta un PDF de todos los grupos, así como un PDF con instrucciones específicas. Necesitamos a alguien con un excelente conocimiento de Adobe Illustrator y un ojo para los detalles para completar este trabajo. Una vez..."
            },
            new projectt()
            {
                nombre = "Firma PDF a HTML - 2",
                fechaPublicacion = "12/7/2020",
                fechaCierre = "15/8/2020",
                empleador = "jose luis ledesma",
                AbilidadesRequeridas = "CSS HTML PHP PSD a HTML Diseño de sitios web",
                descriccionEmpleo = "Hola, tengo un PDF e imágenes sueltas que me gustaría que alguien codifique con una firma HTML."
            },
            new projectt()
            {
                nombre = "El experto en necesidades está familiarizado con el problema del stock de corte ",
                fechaPublicacion = "12/7/2020",
                fechaCierre = "15/8/2020",
                empleador = "jose luis ledesma",
                AbilidadesRequeridas = "CSS HTML JavaScript PHP Vue.js",
                descriccionEmpleo = "Tengo un proyecto (problema de corte de material) fue construido Vue. Necesito un código javascript diseñado con html para reducir el problema de stock usando el algoritmo Best Fit. Por el momento se utiliza un algoritmo de disminución de primer ajuste que no está dando la mejor solución. Necesito que..."
            },
            new projectt()
            {
                nombre = "Sitio web para completar en 2 días ",
                fechaPublicacion = "12/7/2020",
                fechaCierre = "15/8/2020",
                empleador = "jose luis ledesma",
                AbilidadesRequeridas = "Diseño gráfico HTML PHP Diseño de sitios web WordPress",
                descriccionEmpleo = "Hola, Necesitamos que se haga un sitio web rápidamente. Necesito personas con experiencia."
            }
        };

    }

}

public class projectt
{
    public string nombre { get; set; }
    public string fechaPublicacion { get; set; }
    public string fechaCierre { get; set; }
    public string empleador { get; set; }
    public string descriccionEmpleo { get; set; }
    public string AbilidadesRequeridas { get; set; }
}