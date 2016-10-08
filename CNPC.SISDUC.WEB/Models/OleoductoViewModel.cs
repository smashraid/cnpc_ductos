using System;
using System.ComponentModel.DataAnnotations;

namespace CNPC.SISDUC.Web.Models
{
    public class OleoductoViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string NoLamina { get; set; }
        public string Ubicacion { get; set; }
        public string Material1 { get; set; }
        public string Material2 { get; set; }
        public string Material3 { get; set; }
        public int Schedule1 { get; set; }
        public int Schedule2 { get; set; }
        public int Schedule3 { get; set; }
        public int BLPD { get; set; }
        public decimal Presion { get; set; }
        public decimal Temperatura { get; set; }
        public string BSW { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime FechaInspeccion { get; set; }
        public decimal LongitudTotal { get; set; }
        public string RowState { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}