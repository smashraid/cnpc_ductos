//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPC.SISDUC.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oleoducto
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
        public Nullable<int> Schedule1 { get; set; }
        public Nullable<int> Schedule2 { get; set; }
        public Nullable<int> Schedule3 { get; set; }
        public Nullable<int> BLPD { get; set; }
        public Nullable<decimal> Presion { get; set; }
        public Nullable<decimal> Temperatura { get; set; }
        public string BSW { get; set; }
        public Nullable<System.DateTime> FechaInspeccion { get; set; }
        public string Observaciones { get; set; }
        public string RowState { get; set; }
        public System.DateTime LastUpdate { get; set; }
    }
}
