using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CNPC.SISDUC.Model.Servicio;

namespace CNPC.SISDUC.Presentacion.Controllers
{
    [Authorize]
    public class WSDuctoController : ApiController
    {
        public HttpResponseMessage Listado(int n = 1, int f = 8, string search = null)
        {
            ServicioClient proxy = new ServicioClient();
            string error = String.Empty;
            OleoductoResponse listado = proxy.OleoductoListarEntidad(search, n, f);
            var result = Request.CreateResponse<OleoductoResponse>(HttpStatusCode.OK, listado);
            return result;
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var proxy = new ServicioClient();
            var error = String.Empty;
            OleoductoResponse listado = proxy.OleoductoListarEntidad("", 1, 8);
            var result = Request.CreateResponse<OleoductoResponse>(HttpStatusCode.OK, listado);
            return result;
        }
        [HttpGet]
        public HttpResponseMessage GetOleoductos(string name, int page, int records)
        {
            var proxy = new ServicioClient();
            var error = String.Empty;
            OleoductoResponse listado = proxy.OleoductoListarEntidad(name, page, records);
            var result = Request.CreateResponse<OleoductoResponse>(HttpStatusCode.OK, listado);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Model.Oleoducto nuevoDucto)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            OleoductoRequest registro = new OleoductoRequest();
            OleoductoResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    registro.Item = nuevoDucto;
                    registro.Operacion = Model.Operacion.Agregar;
                    resultado = proxy.OleoductoEjecutarOperacion(registro);
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }
            }
            else
            {
                resultado.MensajeError = "Error en el ingreso de Datos";
            }
            msg = new HttpResponseMessage(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + nuevoDucto.Id.ToString());
            return msg;

        }
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Model.Oleoducto editarDucto)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            OleoductoRequest registro = new OleoductoRequest();
            OleoductoResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    registro.Item = editarDucto;
                    registro.Operacion = Model.Operacion.Actualizar;
                    resultado = proxy.OleoductoEjecutarOperacion(registro);
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }
            }
            else
            {
                resultado.MensajeError = "Error en el ingreso de Datos";
            }
            msg = new HttpResponseMessage(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + editarDucto.Id.ToString());
            return msg;
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            OleoductoRequest registro = new OleoductoRequest();
            OleoductoResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    registro.Item.Id = id;
                    registro.Operacion = Model.Operacion.Eliminar;
                    resultado = proxy.OleoductoEjecutarOperacion(registro);
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }
            }
            else
            {
                resultado.MensajeError = "Error en el ingreso de Datos";
            }
            msg = new HttpResponseMessage(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + id.ToString());
            return msg;
        }
    }
}
