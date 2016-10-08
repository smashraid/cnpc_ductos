using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPC.SISDUC.Web.Models
{
    public class CuadrillaViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int? CantOperarios { get; set; }
        public string Nombre { get; set; }
        public string TipoCuadrilla { get; set; }
        public int? TipoCuadrillaId { get; set; }
        public int? ContrataId { get; set; }
        public string ContrataN { get; set; }
        public string TipoCuadrillaN { get; set; }
        public int? UsuarioId { get; set; }
        public string UsuarioN { get; set; }
    }
}