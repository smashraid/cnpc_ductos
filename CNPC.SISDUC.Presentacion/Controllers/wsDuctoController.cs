using CNPC.SISDUC.BLL;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CNPC.SISDUC.Presentacion.Controllers
{
    public class WSDuctoController : ApiController
    {
        Ductos _db = new Ductos();
        public HttpResponseMessage Get()
        {
            IEnumerable<Ducto> ducto = _db.FilterByName("OLB");
            var result = Request.CreateResponse<IEnumerable<Ducto>>(HttpStatusCode.OK, ducto);
            return result;
        }
    }
}
