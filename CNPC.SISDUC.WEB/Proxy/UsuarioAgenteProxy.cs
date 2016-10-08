using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPC.SISDUC.Web.Proxy
{
    public class UsuarioAgenteProxy
    {
        public UsuarioViewModel ValidaLogin(UsuarioViewModel request)
        {
            UsuarioViewModel resultado = null;
            UsuarioResponse response;
            Usuario usuario = request.ConvertToModel();
            //Usuario req = new Usuario();
            using (var proxy = new ServicioClient())
            {
                response = proxy.ValidaLogin(new UsuarioRequest { Item = usuario });
            }
            if (response.Item != null)
            {
                resultado = response.Item.ConvertToViewModel();
            }
            return resultado;
        }
        public UsuarioViewModel GetUsuarioByID(int id, ref string error)
        {
            UsuarioViewModel resultado = null;
            try
            {
                UsuarioResponse response;
                var reqobj = new Usuario() { Id = id };
                var req = new UsuarioRequest() { Item = reqobj };
                using (var proxy = new ServicioClient())
                {
                    response = proxy.UsuarioBuscarEntidad(req);
                }
                if (response.Item == null)
                {
                    error = "Usuario no valido";
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resultado;
        }
        public bool ValidaRolconAccion(int rolid, string controller)
        {
            //IEnumerable<UsuarioViewModel> resultado = null;
            bool response;

            using (var proxy = new ServicioClient())
            {
                response = proxy.ValidaRolconAccion(rolid, controller);
            }

            return response;
        }
        public UsuarioViewModel Create(UsuarioViewModel toCreate, ref string error)
        {
            UsuarioViewModel resultado = null;
            try
            {

                var request = toCreate.ConvertToModel();
                UsuarioResponse response;

                var objReq = new UsuarioRequest
                {
                    Item = request,
                    Operacion = Operacion.Agregar
                };
                using (var proxy = new ServicioClient())
                {
                    response = proxy.UsuarioEjecutarOperacion(objReq);
                }
                if (!response.Resultado)
                {
                    error = response.MensajeError;
                    return null;
                }
                resultado = response.Item.ConvertToViewModel();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resultado;
        }
        public bool Update(UsuarioViewModel toEdit, ref string error)
        {
            UsuarioResponse response = null;
            try
            {
                var ttoEdit = toEdit.ConvertToModel();
                var objReq = new UsuarioRequest
                {
                    Item = ttoEdit,
                    Operacion = Operacion.Actualizar
                };
                using (var proxy = new ServicioClient())
                {
                    response = proxy.UsuarioEjecutarOperacion(objReq);
                }
                error = !response.Resultado ? response.MensajeError : "";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return response != null && response.Resultado;
        }
        public bool Delete(ref string error, int id)
        {
            UsuarioResponse response = null;
            try
            {
                var obj = new Usuario() { Id = id };
                var objReq = new UsuarioRequest
                {
                    Item = obj,
                    Operacion = Operacion.Eliminar
                };
                using (var proxy = new ServicioClient())
                {
                    response = proxy.UsuarioEjecutarOperacion(objReq);

                }
                error = !response.Resultado ? response.MensajeError : "";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return response != null && response.Resultado;
        }
    }
}