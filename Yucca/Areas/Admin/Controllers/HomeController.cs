using System.Web.Mvc;
using Yucca.Filter;

namespace Yucca.Areas.Admin.Controllers
{

    [RouteArea("Admin")]
    [RoutePrefix("Home")]
    [Route("{action}")]
    [SiteAuthorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}