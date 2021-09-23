using System.Web;
using System.Web.Mvc;

namespace WebApplication_WCF_Movies_Prc2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
