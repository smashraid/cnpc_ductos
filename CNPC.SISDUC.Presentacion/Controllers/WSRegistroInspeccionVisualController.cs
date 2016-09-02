using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Model;
using System.Configuration;

namespace CNPC.SISDUC.Presentacion.Controllers
{
    public class WSRegistroInspeccionVisualController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(int id = 1)
        {
            ServicioClient proxy = new ServicioClient();
            string error = String.Empty;
            RegistroInspeccionVisualResponse listado = proxy.RegistroInspeccionVisualListarEntidad(id, "", 1, 8);
            var result = Request.CreateResponse<RegistroInspeccionVisualResponse>(HttpStatusCode.OK, listado);
            return result;
        }
        [HttpGet]
        public HttpResponseMessage GetTuberia(int oleoductoid, string name, int page, int records)
        {
            ServicioClient proxy = new ServicioClient();
            string error = String.Empty;
            RegistroInspeccionVisualResponse listado = proxy.RegistroInspeccionVisualListarEntidad(oleoductoid, name, page, records);
            listado.ListTipoSoporte = proxy.TipoSoporteListarAllEntidad();
            var result = Request.CreateResponse<RegistroInspeccionVisualResponse>(HttpStatusCode.OK, listado);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]RegistroInspeccionVisual nuevoTuberia)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    registro.Item = nuevoTuberia;
                    registro.Operacion = Model.Operacion.Agregar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }

                if (nuevoTuberia == null || nuevoTuberia.CodigoDelTubo == string.Empty)
                {
                    return msg;
                }

                msg = new HttpResponseMessage(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + nuevoTuberia.Id.ToString());
            }
            return msg;
        }
        [HttpPut]
        public HttpResponseMessage Put([FromBody]RegistroInspeccionVisual editarTuberia)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                if (editarTuberia != null && editarTuberia.CodigoDelTubo != string.Empty)
                {
                    try
                    {
                        registro.Item = editarTuberia;
                        registro.Operacion = Model.Operacion.Actualizar;
                        resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                    }
                    catch (Exception ex)
                    {
                        resultado.MensajeError = ex.Message;
                    }
                    return Request.CreateResponse<Model.RegistroInspeccionVisual>(HttpStatusCode.OK, editarTuberia);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return msg;
            }
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            var proxy = new ServicioClient();
            try
            {
                try
                {
                    registro.Item.Id = id;
                    registro.Operacion = Model.Operacion.Eliminar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public string ReadSetting(string key)
        {
            string result;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                result = "Error";
            }
            return result;
        }
    }
}
