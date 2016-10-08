using CNPC.SISDUC.Web.Models;
using CNPC.SISDUC.Web.Proxy;
using System.Web;
using System.Web.Mvc;
namespace CNPC.SISDUC.Web
    .Filtros
{
    public class ValidarAccesoAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var omitirAutorizacion =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (!omitirAutorizacion)
                base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SesionActual.Usuario == null)
                return false;


            //CHECA SI EL ROL PUEDE  VER ESA ACCION DE ESE CONTROLLER
            var proxy = new UsuarioAgenteProxy();
            var controller = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("controller");
            var action = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action");
            var url = controller + "/" + action;
            if (!proxy.ValidaRolconAccion(SesionActual.Usuario.RolId, url))
            {
                SesionActual.Usuario = null;
                return false;
            }

            // Obtenemos la ruta real de acceso segun los valores combinados de la URL y la tabla de rutas.
            // Esto nos evita tener que quitar la QueryString y parametros en el Path
            var rutaSimple = "";

            var h = httpContext.CurrentHandler as MvcHandler;

            //rutaSimple = String.Format("/{0}/{1}",
            //    h.RequestContext.RouteData.Values["controller"],
            //    h.RequestContext.RouteData.Values["action"]);

            //Obtenemos lista de opciones y comparamos el acceso bloqueado en el menu segun el plan (aprobador/cerrado)
            //var esCicloActual = SesionActual.EsCicloActual;
            //if (esCicloActual) return true;
            //foreach (Opcion hijo in SesionActual.MenuArbol.SelectMany(padre => padre.Hijos.Where(hijo => hijo.Ruta == rutaSimple)))
            //{
            //    return hijo.CargaId != null && hijo.CargaId == 1;
            //}
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (SesionActual.Usuario != null)
            {
                //  filterContext.Result = SesionActual.EsCicloActual ? new RedirectResult("~/Inicio/NoAutorizado") : new RedirectResult("~/Inicio/PlanCerrado");

            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}