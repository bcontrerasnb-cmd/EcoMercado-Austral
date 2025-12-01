using Examen_BastianContreras_NicoleAlegria.Helpers;
using Examen_BastianContreras_NicoleAlegria.Models;
using System.Linq;
using System.Web.Mvc;


namespace Examen_BastianContreras_NicoleAlegria.Controllers
{
    public class ReportesController : Controller
    {
        private EcoMercadoEntities db = new EcoMercadoEntities();

        public ActionResult Index()
        {

            var data = db.Clientes
                .SelectMany(c => c.Ciudades) 
                .GroupBy(city => new { city.Region, city.Nombre })
                .Select(g => new ReporteCiudadData
                {
                    Region = g.Key.Region,
                    NombreCiudad = g.Key.Nombre,
                    CantidadClientes = g.Count()
                })
                .OrderBy(r => r.Region)
                .ThenByDescending(r => r.CantidadClientes)
                .ToList();

            return View(data);
        }
        public ActionResult Segmentos()
        {
            // Cargar Regiones para el filtro
            ViewBag.ListaRegiones = new SelectList(LocalidadesHelper.GetRegiones());

            // Datos Globales: Agrupar TODOS los clientes por Segmento
            var totalClientes = db.Clientes.Count();

            var data = db.Clientes
                .GroupBy(c => c.Segmento != null ? c.Segmento.Nombre : "Sin Asignar")
                .Select(g => new
                {
                    Nombre = g.Key,
                    Conteo = g.Count()
                })
                .ToList() // Traemos a memoria para calcular porcentaje
                .Select(x => new ReporteSegmentoData
                {
                    Segmento = x.Nombre,
                    Cantidad = x.Conteo,
                    // Calculamos porcentaje formato texto
                    Porcentaje = totalClientes > 0 ? ((double)x.Conteo / totalClientes * 100).ToString("0.0") : "0"
                })
                .ToList();

            return View(data);
        }

        // 2. AJAX: Datos filtrados por CIUDAD (Comuna)
        public JsonResult ObtenerDatosSegmentoLocal(string nombreCiudad)
        {
            // Buscamos clientes que tengan ESA ciudad en su lista de Ciudades
            var clientesEnCiudad = db.Clientes
                .Where(c => c.Ciudades.Any(city => city.Nombre == nombreCiudad));

            var totalEnCiudad = clientesEnCiudad.Count();

            var data = clientesEnCiudad
                .GroupBy(c => c.Segmento != null ? c.Segmento.Nombre : "Sin Asignar")
                .Select(g => new
                {
                    Nombre = g.Key,
                    Conteo = g.Count()
                })
                .ToList()
                .Select(x => new ReporteSegmentoData
                {
                    Segmento = x.Nombre,
                    Cantidad = x.Conteo,
                    Porcentaje = totalEnCiudad > 0 ? ((double)x.Conteo / totalEnCiudad * 100).ToString("0.0") : "0"
                })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}