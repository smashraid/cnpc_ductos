using System;

namespace CNPC.SISDUC.Presentacion.Models
{
    public class OleoductoViewModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public string NoLamina { get; set; }
        public string Ubicacion { get; set; }
        public string Material1 { get; set; }
        public string Material2 { get; set; }
        public string Material3 { get; set; }
        public Nullable<int> Schedule1 { get; set; }
        public Nullable<int> Schedule2 { get; set; }
        public Nullable<int> Schedule3 { get; set; }
        public Nullable<int> BLPD { get; set; }
        public Nullable<decimal> Presion { get; set; }
        public Nullable<decimal> Temperatura { get; set; }
        public string BSW { get; set; }
        public Nullable<System.DateTime> FechaInspeccion { get; set; }
        public string RowState { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}