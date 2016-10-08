using System;
using System.Configuration;
using System.DirectoryServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using formsAuth = System.Web.Security.FormsAuthentication;
using System.DirectoryServices.Protocols;
using System.Net;
using CNPC.SISDUC.Web.Models;
using CNPC.SISDUC.Web.Filtros;
using CNPC.SISDUC.Web.Proxy;

namespace CNPC.SISDUC.WEB.Controllers
{
    [ValidarAcceso]
    public class CuentasController : Controller
    {
        [AllowAnonymous]
        public ActionResult IniciarSesion(string returnUrl)
        {
            if (Request.Cookies[".ASPXAUTH"] == null)
            {
                var dispositivoId = new HttpCookie(".ASPXAUTH")
                {
                    Value = Guid.NewGuid().ToString("N"),
                    Expires = DateTime.Now.AddYears(1)
                };
                Response.Cookies.Add(dispositivoId);
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        public static bool FnValidateUser(string username, string pass)
        {
            bool validation;
            try
            {
                var lcon = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false));
                var nc = new NetworkCredential(username, pass, Environment.UserDomainName);
                lcon.Credential = nc;
                lcon.AuthType = AuthType.Negotiate;
                // user has authenticated at this point,
                // as the credentials were used to login to the dc.
                lcon.Bind(nc);
                validation = true;
            }
            catch (LdapException)
            {
                validation = false;
            }
            return validation;
        }

        [AllowAnonymous]
        public ActionResult Recuperausuario()
        {
            var ret = Environment.UserName;
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        public bool ValidarEnActiveDirectory(string dominioLdap, string nombre, string clave)
        {
            var entry = new DirectoryEntry(dominioLdap, nombre, clave);
            var search = new DirectorySearcher(entry) { Filter = "(SAMAccountName=" + nombre + ")" };
            search.PropertiesToLoad.Add("cn");
            search.PropertiesToLoad.Add("displayName");
            try
            {
                var result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // POST: /Account/Login
        //[ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> IniciarSesion(UsuarioViewModel model, string returnUrl)
        {
            if (model.ActiveDirectory)
            {
                var authenticated = ValidarEnActiveDirectory(ConfigurationManager.AppSettings["ldap"], model.Usuario1, model.Contrasenia);
                if (!authenticated)
                {
                    ModelState.AddModelError("", "User NO Existe");
                    return View(model);
                }
            }
            UsuarioViewModel usuariologueado = null;
            if (ModelState.IsValid)
            {
                var proxy = new UsuarioAgenteProxy();
                usuariologueado = proxy.ValidaLogin(model);
                if (usuariologueado != null) //existe y se valido correctamente
                {
                    SesionActual.Usuario = usuariologueado;
                    if (usuariologueado.RolId != 1) return Redirect(formsAuth.DefaultUrl);
                    formsAuth.SetAuthCookie(model.Nombre, true);
                    Session["credencial"] = model;
                    SesionActual.EstaAutenticado = true;
                    return Redirect(formsAuth.DefaultUrl);
                }
            }
            ModelState.AddModelError("", "Credencial Invalida");
            return View(usuariologueado);
        }
    }
}