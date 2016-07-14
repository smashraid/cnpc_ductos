using CNPC.SISDUC.BLL;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPC.SISDUC.Presentacion.Security
{
    public class UsuarioAgenteProxy
    {
      

        public Usuario ValidaLogin(Usuario request)
        {
            Usuario resultado = new Usuario();
            using (var proxy = new UsuarioBLL())
            {
                resultado = proxy.ValidaLogin(request);
            }
            
            return resultado != null ? resultado : null;
        }
        public Usuario Create(Usuario toCreate, ref string error)
        {
            Usuario resultado = null;
            try
            {
                using (var proxy = new UsuarioBLL())
                {
                    resultado = proxy.Create(toCreate);
                }

                return resultado != null ? resultado : null;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resultado;
        }
        public bool Update(Usuario toEdit, ref string error)
        {
            bool resultado = false;
            try
            {
                using (var proxy = new UsuarioBLL())
                {
                    resultado = proxy.Update(toEdit);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resultado;
        }
        public bool Delete(ref string error, int id)
        {
            bool resultado = false;
            try
            {
                using (var proxy = new UsuarioBLL())
                {
                    resultado = proxy.Delete(id);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resultado;
        }
    }
}