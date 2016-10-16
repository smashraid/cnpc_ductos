using CNPC.SISDUC.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CNPC.SISDUC.WEB.Models
{
    public class RegistroInspeccionVisualModel
    {
        public IEnumerable<SelectListItem> ListaTipoSoporte { get; set; }
        public IEnumerable<RegistroInspeccionVisual> List { get; set; }

        public List<RegistroInspeccionVisualModel> ListaEliminados { get; set; }
        public Oleoducto oleoducto { get; set; }
        public int Id { get; set; }
        public int OleoductoID { get; set; }
        public string CodigoDelTubo { get; set; }
        public string NumeroOleoducto { get; set; }
        public string CodigoDelTubo01 { get; set; }
        public string CodigoDelTubo02 { get; set; }
        public string CodigoDelTubo03 { get; set; }
        public int NumeroAnterior { get; set; }
        public decimal NPS { get; set; }
        public int Schedule { get; set; }
        public int SHC { get; set; }
        public string TipoMaterial { get; set; }
        public decimal Longitud { get; set; }
        public string CoordenadasUTM_X { get; set; }
        public string CoordenadasUTM_Y { get; set; }
        public decimal ExtremoInicial1 { get; set; }
        public decimal ExtremoInicial2 { get; set; }
        public decimal ExtremoInicial3 { get; set; }
        public decimal ExtremoInicial4 { get; set; }
        public decimal BSCAN { get; set; }
        public decimal EspesorPared { get; set; }
        public decimal ExtremoMedio1 { get; set; }
        public decimal ExtremoMedio2 { get; set; }
        public decimal ExtremoMedio3 { get; set; }
        public decimal ExtremoMedio4 { get; set; }
        public decimal MapeoCorrison { get; set; }
        public decimal PitCorrosion { get; set; }
        public decimal ExtremoFinal1 { get; set; }
        public decimal ExtremoFinal2 { get; set; }
        public decimal ExtremoFinal3 { get; set; }
        public decimal ExtremoFinal4 { get; set; }
        public decimal LEFT_MINIMO { get; set; }
        public decimal EspesorRemanente { get; set; }
        public decimal EspesorNominal { get; set; }
        public string Defecto { get; set; }
        public bool Defecto2 { get; set; }
        public int NumeroGrapas { get; set; }
        public string TipoSoporte { get; set; }
        public bool Elastomero { get; set; }
        public bool Maleza { get; set; }
        public bool TuberiaAlrededor { get; set; }
        public bool Pintura { get; set; }
        public bool CruceCarretera { get; set; }
        public string TipoProteccion { get; set; }
        public string EstadoProteccion { get; set; }
        public string EstadoTuberia { get; set; }
        public System.DateTime UltimaFechaDeInspeccion { get; set; }
        public string UltimaFechaDeInspeccionStr
        {
            get { return this.UltimaFechaDeInspeccion.ToString("dd/MM/yyyy"); }
        }
        public bool SeleccionarTuberia { get; set; }
        public string RowState { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public int TuberiaId { get; set; }
        public decimal EspesorMinimoRealRemanente { get; set; }
        public string ObservacionesDeLaInspeccionVisual { get; set; }
        public string CondicionDelTramo { get; set; }
    }
}