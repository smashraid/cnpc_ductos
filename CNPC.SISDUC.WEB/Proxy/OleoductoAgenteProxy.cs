using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Web.Models;
using System;
using System.Collections.Generic;

namespace CNPC.SISDUC.Presentacion.Proxy
{
    public class OleoductoAgenteProxy
    {
        public IEnumerable<OleoductoViewModel> GetLista(ref string error, int n = 1, int f = 10, string search = null)
        {
            IEnumerable<OleoductoViewModel> lista = null;
            try
            {
                OleoductoResponse response;
                using (var proxy = new ServicioClient())
                {
                    response = proxy.OleoductoListarEntidad(search, n, f);
                }
                if (response.List == null)
                {
                    error = "No se encontraron registros";
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return lista;
        }

        public int ListCount(ref string error)
        {
            var result = 0;
            try
            {
                using (var proxy = new ServicioClient())
                {
                    //result = proxy.ListCountActividad(ref error);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return result;
        }
    }
}