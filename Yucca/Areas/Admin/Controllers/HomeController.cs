using System.Web.Mvc;

namespace Yucca.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}