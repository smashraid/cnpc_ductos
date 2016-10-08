using System.Web;

namespace CNPC.SISDUC.Web.Models
{
    public static class SesionActual
    {
        public static string Idioma
        {
            get { return Obtener<string>("Idioma"); }
            set { Asignar("Idioma", value); }
        }
        public static bool EstaAutenticado
        {
            get { return Obtener<bool>("EstaAutenticado"); }
            set { Asignar("EstaAutenticado", value); }
        }

        /// <summary>
        /// Usuario actual.
        /// </summary>
        public static UsuarioViewModel Usuario
        {
            get { return Obtener<UsuarioViewModel>("usuario"); }
            set { Asignar("usuario", value); }
        }
        public static CuadrillaViewModel Cuadrilla
        {
            get { return Obtener<CuadrillaViewModel>("cuadrilla"); }
            set { Asignar("cuadrilla", value); }
        }

        private static void Asignar<T>(string key, T value)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                HttpContext.Current.Session.Add(key, value);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        private static T Obtener<T>(string key)
        {
            var x = new HttpContextWrapper(HttpContext.Current);

            var y = x.Session[key];

            return (T)HttpContext.Current.Session[key];
        }

        private static bool Existe(string key)
        {
            var retval = HttpContext.Current.Session[key] != null;

            return retval;
        }
        
    }
}