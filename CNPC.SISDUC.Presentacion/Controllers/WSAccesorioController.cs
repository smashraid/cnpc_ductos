using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CNPC.SISDUC.Presentacion.Controllers
{
    public class WSAccesorioController : ApiController
    {
        //RegistroInspeccionVisuales _dbTuberia = new RegistroInspeccionVisuales();
        //Accesorios _dbAccesorio = new Accesorios();
        //[HttpGet]
        //public HttpResponseMessage Get(int id = 1)
        //{
        //    AccesorioResponse respuesta = _dbAccesorio.FilterByName(id, "", 1, 8);
        //    var result = Request.CreateResponse<AccesorioResponse>(HttpStatusCode.OK, respuesta);
        //    return result;
        //}
        //[HttpGet]
        //public HttpResponseMessage GetAccesorio(int TuberiaId, string name, int page, int records)
        //{

        //    //Oleoducto oleoducto = _dbAccesorio.FilterByName(TuberiaId);
        //    RegistroInspeccionVisualResponse respuesta = _dbTuberia.FilterByNameRegistroInspeccionVisual(TuberiaId, name, page, records);
        //    var result = Request.CreateResponse<RegistroInspeccionVisualResponse>(HttpStatusCode.OK, respuesta);
        //    return result;
        //}
        //[HttpPost]
        //public HttpResponseMessage Post([FromBody]RegistroInspeccionVisual nuevoTuberia)
        //{
        //    var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
        //    if (ModelState.IsValid)
        //    {
        //        if (nuevoTuberia == null || nuevoTuberia.CodigoDelTubo == string.Empty)
        //        {
        //            return msg;
        //        }

        //        _dbTuberia.Create(nuevoTuberia);
        //        msg = new HttpResponseMessage(HttpStatusCode.Created);
        //        msg.Headers.Location = new Uri(Request.RequestUri + nuevoTuberia.Id.ToString());
        //    }
        //    return msg;
        //}
        //[HttpPut]
        //public HttpResponseMessage Put([FromBody]RegistroInspeccionVisual editarTuberia)
        //{
        //    var msg = new HttpResponseMessage(HttpStatusCode.NotFound);
        //    if (ModelState.IsValid)
        //    {
        //        if (editarTuberia != null && editarTuberia.CodigoDelTubo != string.Empty)
        //        {
        //            _dbTuberia.Update(editarTuberia);
        //            return Request.CreateResponse<RegistroInspeccionVisual>(HttpStatusCode.OK, editarTuberia);
        //        }
        //        else
        //        {
        //            throw new HttpResponseException(HttpStatusCode.NotFound);
        //        }
        //    }
        //    else
        //    {
        //        return msg;
        //    }
        //}
        //[HttpDelete]
        //public HttpResponseMessage Delete(int id)
        //{
        //    try
        //    {
        //        var Existe = _dbTuberia.Delete(id);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //}
        //public string ReadSetting(string key)
        //{
        //    string result;
        //    try
        //    {
        //        var appSettings = ConfigurationManager.AppSettings;
        //        result = appSettings[key] ?? "Not Found";
        //    }
        //    catch (ConfigurationErrorsException)
        //    {
        //        result = "Error";
        //    }
        //    return result;
        //}
    }
}
