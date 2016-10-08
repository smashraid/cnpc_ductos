using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.WEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CNPC.SISDUC.WEB.Proxy
{
    public static class TuberiaListaAssembler
    {
        //public static RegistroInspeccionVisualModel ConvertToViewModel(this RegistroInspeccionVisualResponse response)
        //{
        //    RegistroInspeccionVisualModel Result = new RegistroInspeccionVisualModel();
        //    IList<SelectListItem> listaTipoSoporte = new List<SelectListItem>();
        //    IList<RegistroInspeccionVisual> lista = new List<RegistroInspeccionVisual>();
        //    listaTipoSoporte.Add(new SelectListItem { Text = "Seleccione...", Value = "0" });
        //    if (response.ListTipoSoporte != null)
        //    {
        //        foreach (var item in response.ListTipoSoporte.List)
        //        {
        //            listaTipoSoporte.Add(new SelectListItem
        //            {
        //                Text = item.Nombre,
        //                Value = item.Valor
        //            });
        //        }
        //    }
        //    Result.ListaTipoSoporte = listaTipoSoporte;

        //    if (response.Item != null)
        //    {
        //        Result.Id = response.Item.Id;
        //        Result.OleoductoID = response.Item.OleoductoID;
        //        Result.CodigoDelTubo = response.Item.CodigoDelTubo;
        //        Result.NumeroOleoducto = response.Item.NumeroOleoducto;
        //        Result.CodigoDelTubo01 = response.Item.CodigoDelTubo01;
        //        Result.CodigoDelTubo02 = response.Item.CodigoDelTubo02;
        //        Result.CodigoDelTubo03 = response.Item.CodigoDelTubo03;
        //        Result.NumeroAnterior = response.Item.NumeroAnterior.HasValue ? response.Item.NumeroAnterior.Value : 0;
        //        Result.NPS = response.Item.NPS.HasValue ? response.Item.NPS.Value : 0;
        //        Result.Schedule = response.Item.SHC.Value;
        //        Result.SHC = response.Item.SHC.HasValue ? response.Item.SHC.Value : 0;
        //        Result.TipoMaterial = response.Item.TipoMaterial;
        //        Result.Longitud = response.Item.Longitud.HasValue ? response.Item.Longitud.Value : 0;
        //        Result.CoordenadasUTM_X = response.Item.CoordenadasUTM_X;
        //        Result.CoordenadasUTM_Y = response.Item.CoordenadasUTM_Y;
        //        Result.ExtremoInicial1 = response.Item.ExtremoInicial1.HasValue ? response.Item.ExtremoInicial1.Value : 0;
        //        Result.ExtremoInicial2 = response.Item.ExtremoInicial2.HasValue ? response.Item.ExtremoInicial2.Value : 0;
        //        Result.ExtremoInicial3 = response.Item.ExtremoInicial3.HasValue ? response.Item.ExtremoInicial3.Value : 0;
        //        Result.ExtremoInicial4 = response.Item.ExtremoInicial4.HasValue ? response.Item.ExtremoInicial4.Value : 0;
        //        Result.BSCAN = response.Item.BSCAN.HasValue ? response.Item.BSCAN.Value : 0;
        //        Result.EspesorPared = response.Item.EspesorPared.HasValue ? response.Item.EspesorPared.Value : 0;
        //        Result.ExtremoMedio1 = response.Item.ExtremoMedio1.HasValue ? response.Item.ExtremoMedio1.Value : 0;
        //        Result.ExtremoMedio2 = response.Item.ExtremoMedio2.HasValue ? response.Item.ExtremoMedio2.Value : 0;
        //        Result.ExtremoMedio3 = response.Item.ExtremoMedio3.HasValue ? response.Item.ExtremoMedio3.Value : 0;
        //        Result.ExtremoMedio4 = response.Item.ExtremoMedio4.HasValue ? response.Item.ExtremoMedio4.Value : 0;
        //        Result.MapeoCorrison = response.Item.MapeoCorrison.HasValue ? response.Item.MapeoCorrison.Value : 0;
        //        Result.PitCorrosion = response.Item.PitCorrosion.HasValue ? response.Item.PitCorrosion.Value : 0;
        //        Result.ExtremoFinal1 = response.Item.ExtremoFinal1.HasValue ? response.Item.ExtremoFinal1.Value : 0;
        //        Result.ExtremoFinal2 = response.Item.ExtremoFinal2.HasValue ? response.Item.ExtremoFinal2.Value : 0;
        //        Result.ExtremoFinal3 = response.Item.ExtremoFinal3.HasValue ? response.Item.ExtremoFinal3.Value : 0;
        //        Result.ExtremoFinal4 = response.Item.ExtremoFinal4.HasValue ? response.Item.ExtremoFinal4.Value : 0;
        //        Result.LEFT_MINIMO = response.Item.LEFT_MINIMO.HasValue ? response.Item.LEFT_MINIMO.Value : 0;
        //        Result.EspesorRemanente = response.Item.EspesorRemanente.HasValue ? response.Item.EspesorRemanente.Value : 0;
        //        Result.Defecto = response.Item.Defecto;
        //        Result.Defecto2 = response.Item.Defecto2.HasValue ? response.Item.Defecto2.Value : false;
        //        Result.NumeroGrapas = response.Item.NumeroGrapas.HasValue ? response.Item.NumeroGrapas.Value : 0;
        //        Result.TipoSoporte = response.Item.TipoSoporte;
        //        Result.EspesorNominal = response.Item.EspesorNominal;
        //        Result.EspesorMinimoRealRemanente = response.Item.EspesorMinimoRealRemanente;
        //        Result.ObservacionesDeLaInspeccionVisual = response.Item.ObservacionesDeLaInspeccionVisual;
        //        Result.Elastomero = response.Item.Elastomero.HasValue ? response.Item.Elastomero.Value : false;
        //        Result.Maleza = response.Item.Maleza.HasValue ? response.Item.Maleza.Value : false;
        //        Result.TuberiaAlrededor = response.Item.TuberiaAlrededor.HasValue ? response.Item.TuberiaAlrededor.Value : false;
        //        Result.EstadoProteccion = response.Item.EstadoProteccion;
        //        Result.EstadoTuberia = response.Item.EstadoTuberia;
        //        Result.UltimaFechaDeInspeccion = response.Item.UltimaFechaDeInspeccion.HasValue ? response.Item.UltimaFechaDeInspeccion.Value : new System.DateTime(1950, 01, 01);
        //        Result.SeleccionarTuberia = response.Item.SeleccionarTuberia.HasValue ? response.Item.SeleccionarTuberia.Value : false;
        //        Result.RowState = response.Item.RowState;
        //        Result.LastUpdate = response.Item.LastUpdate.HasValue ? response.Item.LastUpdate.Value : new System.DateTime(1950, 01, 01);
        //        Result.TuberiaId = response.Item.TuberiaId.HasValue ? response.Item.TuberiaId.Value : 0;
        //    }
        //    if (response.List != null)
        //    {
        //        foreach (var item in response.List)
        //        {
        //            RegistroInspeccionVisual registro = new RegistroInspeccionVisual();
        //            registro.Id = item.Id;
        //            registro.OleoductoID = item.OleoductoID;
        //            registro.CodigoDelTubo = item.CodigoDelTubo;
        //            registro.NumeroOleoducto = item.NumeroOleoducto;
        //            registro.CodigoDelTubo01 = item.CodigoDelTubo01;
        //            registro.CodigoDelTubo02 = item.CodigoDelTubo02;
        //            registro.CodigoDelTubo03 = item.CodigoDelTubo03;
        //            registro.NumeroAnterior = item.NumeroAnterior.HasValue ? item.NumeroAnterior.Value : 0;
        //            registro.NPS = item.NPS.HasValue ? item.NPS.Value : 0;
        //            registro.Schedule = item.SHC.HasValue ? item.SHC.Value : 0;
        //            registro.SHC = item.SHC.HasValue ? item.SHC.Value : 0;
        //            registro.TipoMaterial = item.TipoMaterial;
        //            registro.Longitud = item.Longitud.HasValue ? item.Longitud.Value : 0;
        //            registro.CoordenadasUTM_X = item.CoordenadasUTM_X;
        //            registro.CoordenadasUTM_Y = item.CoordenadasUTM_Y;
        //            registro.ExtremoInicial1 = item.ExtremoInicial1.HasValue ? item.ExtremoInicial1.Value : 0;
        //            registro.ExtremoInicial2 = item.ExtremoInicial2.HasValue ? item.ExtremoInicial2.Value : 0;
        //            registro.ExtremoInicial3 = item.ExtremoInicial3.HasValue ? item.ExtremoInicial3.Value : 0;
        //            registro.ExtremoInicial4 = item.ExtremoInicial4.HasValue ? item.ExtremoInicial4.Value : 0;
        //            registro.BSCAN = item.BSCAN.HasValue ? item.BSCAN.Value : 0;
        //            registro.EspesorPared = item.EspesorPared.HasValue ? item.EspesorPared.Value : 0;
        //            registro.ExtremoMedio1 = item.ExtremoMedio1.HasValue ? item.ExtremoMedio1.Value : 0;
        //            registro.ExtremoMedio2 = item.ExtremoMedio2.HasValue ? item.ExtremoMedio2.Value : 0;
        //            registro.ExtremoMedio3 = item.ExtremoMedio3.HasValue ? item.ExtremoMedio3.Value : 0;
        //            registro.ExtremoMedio4 = item.ExtremoMedio4.HasValue ? item.ExtremoMedio4.Value : 0;
        //            registro.MapeoCorrison = item.MapeoCorrison.HasValue ? item.MapeoCorrison.Value : 0;
        //            registro.PitCorrosion = item.PitCorrosion.HasValue ? item.PitCorrosion.Value : 0;
        //            registro.ExtremoFinal1 = item.ExtremoFinal1.HasValue ? item.ExtremoFinal1.Value : 0;
        //            registro.ExtremoFinal2 = item.ExtremoFinal2.HasValue ? item.ExtremoFinal2.Value : 0;
        //            registro.ExtremoFinal3 = item.ExtremoFinal3.HasValue ? item.ExtremoFinal3.Value : 0;
        //            registro.ExtremoFinal4 = item.ExtremoFinal4.HasValue ? item.ExtremoFinal4.Value : 0;
        //            registro.LEFT_MINIMO = item.LEFT_MINIMO.HasValue ? item.LEFT_MINIMO.Value : 0;
        //            registro.EspesorRemanente = item.EspesorRemanente.HasValue ? item.EspesorRemanente.Value : 0;
        //            registro.Defecto = item.Defecto;
        //            registro.Defecto2 = item.Defecto2.HasValue ? item.Defecto2.Value : false;
        //            registro.NumeroGrapas = item.NumeroGrapas.HasValue ? item.NumeroGrapas.Value : 0;
        //            registro.TipoSoporte = item.TipoSoporte;
        //            registro.Elastomero = item.Elastomero.HasValue ? item.Elastomero.Value : false;
        //            registro.Maleza = item.Maleza.HasValue ? item.Maleza.Value : false;
        //            registro.TuberiaAlrededor = item.TuberiaAlrededor.HasValue ? item.TuberiaAlrededor.Value : false;
        //            registro.EstadoProteccion = item.EstadoProteccion;
        //            registro.EstadoTuberia = item.EstadoTuberia;
        //            registro.UltimaFechaDeInspeccion = item.UltimaFechaDeInspeccion.HasValue ? item.UltimaFechaDeInspeccion.Value : new System.DateTime(1950, 01, 01);
        //            registro.SeleccionarTuberia = item.SeleccionarTuberia.HasValue ? item.SeleccionarTuberia.Value : false;
        //            registro.RowState = item.RowState;
        //            registro.LastUpdate = item.LastUpdate.HasValue ? item.LastUpdate.Value : new System.DateTime(1950, 01, 01);
        //            registro.TuberiaId = item.TuberiaId.HasValue ? item.TuberiaId.Value : 0;

        //            lista.Add(registro);
        //        }
        //        Result.List = lista;
        //    }
        //    return Result;
        //}
        public static List<RegistroInspeccionVisualModel> ConvertToViewModel(this RegistroInspeccionVisualResponse response)
        {
            List<RegistroInspeccionVisualModel> Result = new List<RegistroInspeccionVisualModel>();
            IList<SelectListItem> listaTipoSoporte = new List<SelectListItem>();
            IList<RegistroInspeccionVisual> lista = new List<RegistroInspeccionVisual>();
            listaTipoSoporte.Add(new SelectListItem { Text = "Seleccione...", Value = "0" });
            if (response.ListTipoSoporte != null)
            {
                foreach (var item in response.ListTipoSoporte.List)
                {
                    listaTipoSoporte.Add(new SelectListItem
                    {
                        Text = item.Nombre,
                        Value = item.Valor
                    });
                }
            }
            Result.ListaTipoSoporte = listaTipoSoporte;

            if (response.Item != null)
            {
                Result.Id = response.Item.Id;
                Result.OleoductoID = response.Item.OleoductoID;
                Result.CodigoDelTubo = response.Item.CodigoDelTubo;
                Result.NumeroOleoducto = response.Item.NumeroOleoducto;
                Result.CodigoDelTubo01 = response.Item.CodigoDelTubo01;
                Result.CodigoDelTubo02 = response.Item.CodigoDelTubo02;
                Result.CodigoDelTubo03 = response.Item.CodigoDelTubo03;
                Result.NumeroAnterior = response.Item.NumeroAnterior.HasValue ? response.Item.NumeroAnterior.Value : 0;
                Result.NPS = response.Item.NPS.HasValue ? response.Item.NPS.Value : 0;
                Result.Schedule = response.Item.SHC.Value;
                Result.SHC = response.Item.SHC.HasValue ? response.Item.SHC.Value : 0;
                Result.TipoMaterial = response.Item.TipoMaterial;
                Result.Longitud = response.Item.Longitud.HasValue ? response.Item.Longitud.Value : 0;
                Result.CoordenadasUTM_X = response.Item.CoordenadasUTM_X;
                Result.CoordenadasUTM_Y = response.Item.CoordenadasUTM_Y;
                Result.ExtremoInicial1 = response.Item.ExtremoInicial1.HasValue ? response.Item.ExtremoInicial1.Value : 0;
                Result.ExtremoInicial2 = response.Item.ExtremoInicial2.HasValue ? response.Item.ExtremoInicial2.Value : 0;
                Result.ExtremoInicial3 = response.Item.ExtremoInicial3.HasValue ? response.Item.ExtremoInicial3.Value : 0;
                Result.ExtremoInicial4 = response.Item.ExtremoInicial4.HasValue ? response.Item.ExtremoInicial4.Value : 0;
                Result.BSCAN = response.Item.BSCAN.HasValue ? response.Item.BSCAN.Value : 0;
                Result.EspesorPared = response.Item.EspesorPared.HasValue ? response.Item.EspesorPared.Value : 0;
                Result.ExtremoMedio1 = response.Item.ExtremoMedio1.HasValue ? response.Item.ExtremoMedio1.Value : 0;
                Result.ExtremoMedio2 = response.Item.ExtremoMedio2.HasValue ? response.Item.ExtremoMedio2.Value : 0;
                Result.ExtremoMedio3 = response.Item.ExtremoMedio3.HasValue ? response.Item.ExtremoMedio3.Value : 0;
                Result.ExtremoMedio4 = response.Item.ExtremoMedio4.HasValue ? response.Item.ExtremoMedio4.Value : 0;
                Result.MapeoCorrison = response.Item.MapeoCorrison.HasValue ? response.Item.MapeoCorrison.Value : 0;
                Result.PitCorrosion = response.Item.PitCorrosion.HasValue ? response.Item.PitCorrosion.Value : 0;
                Result.ExtremoFinal1 = response.Item.ExtremoFinal1.HasValue ? response.Item.ExtremoFinal1.Value : 0;
                Result.ExtremoFinal2 = response.Item.ExtremoFinal2.HasValue ? response.Item.ExtremoFinal2.Value : 0;
                Result.ExtremoFinal3 = response.Item.ExtremoFinal3.HasValue ? response.Item.ExtremoFinal3.Value : 0;
                Result.ExtremoFinal4 = response.Item.ExtremoFinal4.HasValue ? response.Item.ExtremoFinal4.Value : 0;
                Result.LEFT_MINIMO = response.Item.LEFT_MINIMO.HasValue ? response.Item.LEFT_MINIMO.Value : 0;
                Result.EspesorRemanente = response.Item.EspesorRemanente.HasValue ? response.Item.EspesorRemanente.Value : 0;
                Result.Defecto = response.Item.Defecto;
                Result.Defecto2 = response.Item.Defecto2.HasValue ? response.Item.Defecto2.Value : false;
                Result.NumeroGrapas = response.Item.NumeroGrapas.HasValue ? response.Item.NumeroGrapas.Value : 0;
                Result.TipoSoporte = response.Item.TipoSoporte;
                Result.EspesorNominal = response.Item.EspesorNominal;
                Result.EspesorMinimoRealRemanente = response.Item.EspesorMinimoRealRemanente;
                Result.ObservacionesDeLaInspeccionVisual = response.Item.ObservacionesDeLaInspeccionVisual;
                Result.Elastomero = response.Item.Elastomero.HasValue ? response.Item.Elastomero.Value : false;
                Result.Maleza = response.Item.Maleza.HasValue ? response.Item.Maleza.Value : false;
                Result.TuberiaAlrededor = response.Item.TuberiaAlrededor.HasValue ? response.Item.TuberiaAlrededor.Value : false;
                Result.EstadoProteccion = response.Item.EstadoProteccion;
                Result.EstadoTuberia = response.Item.EstadoTuberia;
                Result.UltimaFechaDeInspeccion = response.Item.UltimaFechaDeInspeccion.HasValue ? response.Item.UltimaFechaDeInspeccion.Value : new System.DateTime(1950, 01, 01);
                Result.SeleccionarTuberia = response.Item.SeleccionarTuberia.HasValue ? response.Item.SeleccionarTuberia.Value : false;
                Result.RowState = response.Item.RowState;
                Result.LastUpdate = response.Item.LastUpdate.HasValue ? response.Item.LastUpdate.Value : new System.DateTime(1950, 01, 01);
                Result.TuberiaId = response.Item.TuberiaId.HasValue ? response.Item.TuberiaId.Value : 0;
            }
            if (response.List != null)
            {
                foreach (var item in response.List)
                {
                    RegistroInspeccionVisual registro = new RegistroInspeccionVisual();
                    registro.Id = item.Id;
                    registro.OleoductoID = item.OleoductoID;
                    registro.CodigoDelTubo = item.CodigoDelTubo;
                    registro.NumeroOleoducto = item.NumeroOleoducto;
                    registro.CodigoDelTubo01 = item.CodigoDelTubo01;
                    registro.CodigoDelTubo02 = item.CodigoDelTubo02;
                    registro.CodigoDelTubo03 = item.CodigoDelTubo03;
                    registro.NumeroAnterior = item.NumeroAnterior.HasValue ? item.NumeroAnterior.Value : 0;
                    registro.NPS = item.NPS.HasValue ? item.NPS.Value : 0;
                    registro.Schedule = item.SHC.HasValue ? item.SHC.Value : 0;
                    registro.SHC = item.SHC.HasValue ? item.SHC.Value : 0;
                    registro.TipoMaterial = item.TipoMaterial;
                    registro.Longitud = item.Longitud.HasValue ? item.Longitud.Value : 0;
                    registro.CoordenadasUTM_X = item.CoordenadasUTM_X;
                    registro.CoordenadasUTM_Y = item.CoordenadasUTM_Y;
                    registro.ExtremoInicial1 = item.ExtremoInicial1.HasValue ? item.ExtremoInicial1.Value : 0;
                    registro.ExtremoInicial2 = item.ExtremoInicial2.HasValue ? item.ExtremoInicial2.Value : 0;
                    registro.ExtremoInicial3 = item.ExtremoInicial3.HasValue ? item.ExtremoInicial3.Value : 0;
                    registro.ExtremoInicial4 = item.ExtremoInicial4.HasValue ? item.ExtremoInicial4.Value : 0;
                    registro.BSCAN = item.BSCAN.HasValue ? item.BSCAN.Value : 0;
                    registro.EspesorPared = item.EspesorPared.HasValue ? item.EspesorPared.Value : 0;
                    registro.ExtremoMedio1 = item.ExtremoMedio1.HasValue ? item.ExtremoMedio1.Value : 0;
                    registro.ExtremoMedio2 = item.ExtremoMedio2.HasValue ? item.ExtremoMedio2.Value : 0;
                    registro.ExtremoMedio3 = item.ExtremoMedio3.HasValue ? item.ExtremoMedio3.Value : 0;
                    registro.ExtremoMedio4 = item.ExtremoMedio4.HasValue ? item.ExtremoMedio4.Value : 0;
                    registro.MapeoCorrison = item.MapeoCorrison.HasValue ? item.MapeoCorrison.Value : 0;
                    registro.PitCorrosion = item.PitCorrosion.HasValue ? item.PitCorrosion.Value : 0;
                    registro.ExtremoFinal1 = item.ExtremoFinal1.HasValue ? item.ExtremoFinal1.Value : 0;
                    registro.ExtremoFinal2 = item.ExtremoFinal2.HasValue ? item.ExtremoFinal2.Value : 0;
                    registro.ExtremoFinal3 = item.ExtremoFinal3.HasValue ? item.ExtremoFinal3.Value : 0;
                    registro.ExtremoFinal4 = item.ExtremoFinal4.HasValue ? item.ExtremoFinal4.Value : 0;
                    registro.LEFT_MINIMO = item.LEFT_MINIMO.HasValue ? item.LEFT_MINIMO.Value : 0;
                    registro.EspesorRemanente = item.EspesorRemanente.HasValue ? item.EspesorRemanente.Value : 0;
                    registro.Defecto = item.Defecto;
                    registro.Defecto2 = item.Defecto2.HasValue ? item.Defecto2.Value : false;
                    registro.NumeroGrapas = item.NumeroGrapas.HasValue ? item.NumeroGrapas.Value : 0;
                    registro.TipoSoporte = item.TipoSoporte;
                    registro.Elastomero = item.Elastomero.HasValue ? item.Elastomero.Value : false;
                    registro.Maleza = item.Maleza.HasValue ? item.Maleza.Value : false;
                    registro.TuberiaAlrededor = item.TuberiaAlrededor.HasValue ? item.TuberiaAlrededor.Value : false;
                    registro.EstadoProteccion = item.EstadoProteccion;
                    registro.EstadoTuberia = item.EstadoTuberia;
                    registro.UltimaFechaDeInspeccion = item.UltimaFechaDeInspeccion.HasValue ? item.UltimaFechaDeInspeccion.Value : new System.DateTime(1950, 01, 01);
                    registro.SeleccionarTuberia = item.SeleccionarTuberia.HasValue ? item.SeleccionarTuberia.Value : false;
                    registro.RowState = item.RowState;
                    registro.LastUpdate = item.LastUpdate.HasValue ? item.LastUpdate.Value : new System.DateTime(1950, 01, 01);
                    registro.TuberiaId = item.TuberiaId.HasValue ? item.TuberiaId.Value : 0;

                    lista.Add(registro);
                }
                Result.List = lista;
            }
            return Result;
        }
    }
}