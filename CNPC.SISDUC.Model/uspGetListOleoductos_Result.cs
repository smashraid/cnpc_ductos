//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPC.SISDUC.Model
{
    using System;
    
    public partial class uspGetListOleoductos_Result
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Codigo { get; set; }
        public string NoLamina { get; set; }
        public string Trayectoria { get; set; }
        public string Ubicacion { get; set; }
        public string Inspector { get; set; }
        public Nullable<System.DateTime> FechaInspeccion { get; set; }
        public Nullable<int> NumeroTubos { get; set; }
        public Nullable<decimal> Longitud01 { get; set; }
        public Nullable<decimal> Longitud02 { get; set; }
        public Nullable<decimal> Longitud03 { get; set; }
        public Nullable<decimal> Longitud04 { get; set; }
        public Nullable<decimal> Longitud05 { get; set; }
        public Nullable<decimal> LongitudTotal { get; set; }
        public Nullable<decimal> PresionDiseño { get; set; }
        public Nullable<decimal> PresionMaximaAdmisibleOperacion { get; set; }
        public Nullable<decimal> PresionMaximaOperacion { get; set; }
        public Nullable<decimal> PresionNormalOperacion { get; set; }
        public Nullable<decimal> TemperaturaMaximaOperacion { get; set; }
        public Nullable<decimal> TemperaturaNormalOperacion { get; set; }
        public Nullable<int> NPS01 { get; set; }
        public Nullable<int> NPS02 { get; set; }
        public Nullable<int> NPS03 { get; set; }
        public Nullable<int> NPS04 { get; set; }
        public Nullable<int> NPS05 { get; set; }
        public Nullable<decimal> Presion { get; set; }
        public Nullable<int> BLPD { get; set; }
        public Nullable<int> Schedule1 { get; set; }
        public Nullable<int> Schedule2 { get; set; }
        public Nullable<int> Schedule3 { get; set; }
        public string Material1 { get; set; }
        public string Material2 { get; set; }
        public string Material3 { get; set; }
        public Nullable<decimal> Temperatura { get; set; }
        public string BSW { get; set; }
        public Nullable<int> Esfuerzo_S { get; set; }
        public Nullable<int> FactorJunta_E { get; set; }
        public Nullable<decimal> FactorSensibilidadError { get; set; }
        public string RowState { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
}