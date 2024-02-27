using System.Web;
using System.Web.Mvc;

namespace BE_U2_W1_D1_D2_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
