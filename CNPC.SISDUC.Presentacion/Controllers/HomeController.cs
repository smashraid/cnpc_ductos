using CNPC.SISDUC.Presentacion.Models;
using System.Web.Mvc;

using formsAuth = System.Web.Security.FormsAuthentication;

namespace CNPC.SISDUC.Presentacion.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CerrarSesion()
        {
            var entrada = SesionActual.Usuario;

            if (entrada != null)
            {
                SesionActual.Usuario = null;
            }

            formsAuth.SignOut();
            SesionActual.EstaAutenticado = false;
            Session.Clear();
            Session.Abandon();
            return Redirect(formsAuth.DefaultUrl);
        }
    }
}