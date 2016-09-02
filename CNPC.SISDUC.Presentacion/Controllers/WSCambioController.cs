﻿using CNPC.SISDUC.Model.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CNPC.SISDUC.Presentacion.Controllers
{
    public class WSCambioController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Model.CambiosTuberia registro)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            CambiosTuberiaRequest RegistroRequest = new CambiosTuberiaRequest();
            CambiosTuberiaResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    RegistroRequest.Item = registro;
                    RegistroRequest.Operacion = Model.Operacion.Agregar;
                    resultado = proxy.CambiosTuberiaEjecutarOperacion(RegistroRequest);
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
            msg.Headers.Location = new Uri(Request.RequestUri + resultado.Item.Id.ToString());
            return msg;

        }
    }
}
