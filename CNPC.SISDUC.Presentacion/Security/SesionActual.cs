using CNPC.SISDUC.Model;
using CNPC.SISDUC.Presentacion.Models;
using System.Web;

namespace CNPC.SISDUC.Presentacion.Security
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
        public static Usuario Usuario
        {
            get { return Obtener<Usuario>("usuario"); }
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