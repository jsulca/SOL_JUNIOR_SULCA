using System.Web;
using System.Web.Mvc;

namespace SOL_JUNIOR_SULCA.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
