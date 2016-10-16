using CNPC.SISDUC.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CNPC.SISDUC.WEB.Models
{
    public class AccesoriosModels
    {
        public int Id { get; set; }
        public string NombreAccesorio { get; set; }
        public string CodigoTuberia { get; set; }
        public string Correlativo { get; set; }
        public decimal NPS { get; set; }
        public int Schedule { get; set; }
        public string TipoMaterial { get; set; }
        public decimal Longitud { get; set; }
        public int CoordenadasUTMX { get; set; }
        public int CoordenadasUTMY { get; set; }
        public string Observaciones { get; set; }
        public string CondicionAccesorio { get; set; }
        public string RowState { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}