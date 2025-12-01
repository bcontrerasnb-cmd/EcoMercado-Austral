using Examen_BastianContreras_NicoleAlegria.Models;
using Examen_BastianContreras_NicoleAlegria.Permisos;
using System.Linq;
using System.Web.Mvc;

namespace Examen_BastianContreras_NicoleAlegria.Controllers
{
    
    public class AccesoController : Controller
    {
        private EcoMercadoEntities db = new EcoMercadoEntities();

        // GET: Acceso/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Acceso/Login
        [HttpPost]
        public ActionResult Login(string NombreUsuario, string Password)
        {
            // 1. Buscamos el usuario en la BD
            var usuario = db.Usuarios
                            .FirstOrDefault(u => u.NombreUsuario == NombreUsuario && u.Password == Password);

            // 2. Si existe, creamos la sesión
            if (usuario != null)
            {
                Session["Usuario"] = usuario.NombreUsuario;
                return RedirectToAction("Index", "Home"); // Va al inicio si todo está bien
            }

            // 3. Si no existe, mandamos error a la vista
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        // GET: Acceso/Logout
        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            Session.Abandon(); // Destruye toda la sesión
            return RedirectToAction("Login", "Acceso");
        }
    }
}