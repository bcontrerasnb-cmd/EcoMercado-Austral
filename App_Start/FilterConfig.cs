using System.Web;
using System.Web.Mvc;

namespace Examen_BastianContreras_NicoleAlegria
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
