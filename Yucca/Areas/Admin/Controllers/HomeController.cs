using System.Web.Mvc;
using Yucca.Filter;

namespace Yucca.Areas.Admin.Controllers
{

    [RouteArea("Admin")]
    [Route("{action}")]
    [SiteAuthorize(Roles = "admin")]
    public class HomeController : Controller
    {
        [Route("Home")]
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}