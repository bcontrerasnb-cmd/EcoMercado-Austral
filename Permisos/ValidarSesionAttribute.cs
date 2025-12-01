using System.Web;
using System.Web.Mvc;

namespace Examen_BastianContreras_NicoleAlegria.Permisos
{
    // Este filtro se ejecutará antes de cargar cualquier controlador donde lo pongamos
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Verificamos si la variable de sesión está vacía
            if (HttpContext.Current.Session["Usuario"] == null)
            {
                // Si está vacía, lo mandamos al Login
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}