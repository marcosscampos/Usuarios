using System.Web;
using System.Web.Mvc;

namespace Marcos_Vinicius_DR2_TP3 {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
