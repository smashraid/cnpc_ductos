
using CNPC.SISDUC.Presentacion.Models;
using CNPC.SISDUC.Presentacion.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPC.SISDUC.Presentacion.Controllers
{
    [Authorize]
    public class OleoductoController : Controller
    {
        [OutputCache(Duration = 0)]
        public ActionResult Listado(string search = null, int n = 1, int f = 10)
        {
            var proxy = new OleoductoAgenteProxy();
            var error = String.Empty;
            var listado = proxy.GetLista(ref error, n, f, search).ToList();
            ViewBag.MensajeError = error;
            var nr = proxy.ListCount(ref error);
            var ret = listado;
            ret.Insert(0, new OleoductoViewModel { Id = nr });
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
    }
}