using System.Collections.Generic;
using System.Web.Mvc;
using Examen_BastianContreras_NicoleAlegria.Models;

namespace Examen_BastianContreras_NicoleAlegria.Models
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }

        // Para el desplegable de Segmentos
        public SelectList ListaSegmentos { get; set; }

        // Para las casillas de verificación de Ciudades
        public List<CheckBoxItem> ListaCiudades { get; set; }
    }

    public class CheckBoxItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public bool IsSelected { get; set; }
    }
}