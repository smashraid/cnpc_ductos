using CNPC.SISDUC.BLL;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CNPC.SISDUC.Presentacion.Controllers
{
    public class WSDuctoController : ApiController
    {
        Oleoductos _db = new Oleoductos();
        [HttpGet]
        public HttpResponseMessage Get()
        {
            //IEnumerable<Ducto> ducto = _db.FilterByName("");
            //var result = Request.CreateResponse<IEnumerable<Ducto>>(HttpStatusCode.OK, ducto);
            OleoductoResponse ductos = _db.FilterByName("", 1, 8);
            var result = Request.CreateResponse<OleoductoResponse>(HttpStatusCode.OK, ductos);
            return result;
        }
        [HttpGet]
        public HttpResponseMessage GetOleoductos(string name, int page, int records)
        {
            OleoductoResponse ductos = _db.FilterByName(name, page, records);
            var result = Request.CreateResponse<OleoductoResponse>(HttpStatusCode.OK, ductos);
            return result;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Oleoducto nuevoDucto)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            if (ModelState.IsValid)
            {
                if (nuevoDucto == null || nuevoDucto.Codigo == string.Empty)
                {
                    return msg;
                }
                nuevoDucto.Cliente = ReadSetting("Empresa");
                _db.Create(nuevoDucto);
                msg = new HttpResponseMessage(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + nuevoDucto.Id.ToString());
            }
            return msg;
        }
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Oleoducto editarDucto)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.NotFound);
            if (ModelState.IsValid)
            {
                if (editarDucto != null && editarDucto.Codigo != string.Empty)
                {
                    _db.Update(editarDucto);
                    return Request.CreateResponse<Oleoducto>(HttpStatusCode.OK, editarDucto);
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
                result = "Error en Empresa";
            }
            return result;
        }

    }
}
