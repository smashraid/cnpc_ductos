using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CNPC.SISDUC.Presentacion.Models
{
    public class Ducto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Cliente { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ducto1 { get; set; }
        [Required]
        [MaxLength(50)]
        public string NoLamina { get; set; }
        [Required]
        [MaxLength(50)]
        public string Trayectoria { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ubicacion { get; set; }
        [Required]
        [MaxLength(100)]
        public string Inspector { get; set; }
        public Nullable<System.DateTime> FechaInspeccion { get; set; }
        public Nullable<int> NumeroTubos { get; set; }
        public Nullable<decimal> LongitudTotalTubo { get; set; }
        public Nullable<decimal> PresionDiseño { get; set; }
        public Nullable<decimal> PresionMaximaAdmisibleOperacion { get; set; }
        public Nullable<decimal> PresionMaximaOperacion { get; set; }
        public Nullable<decimal> PresionNormalOperacion { get; set; }
        public Nullable<decimal> TemperaturaMaximaOperacion { get; set; }
        public Nullable<decimal> TemperaturaNormalOperacion { get; set; }
        public Nullable<int> NPS { get; set; }
        public Nullable<decimal> Presion { get; set; }
        public Nullable<int> BLPD { get; set; }
        public Nullable<int> Shedule { get; set; }
        public string Material { get; set; }
        public Nullable<decimal> Temperatura { get; set; }
        public Nullable<int> Esfuerzo_S { get; set; }
        public Nullable<int> FactorJunta_E { get; set; }
        public Nullable<decimal> FactorSensibilidadError { get; set; }
        [Required]
        [MaxLength(1)]
        public string RowState { get; set; }
        [Required]
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
}