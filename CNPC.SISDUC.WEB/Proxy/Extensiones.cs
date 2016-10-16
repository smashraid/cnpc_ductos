using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Web.Models;
using CNPC.SISDUC.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CNPC.SISDUC.Web.Proxy
{
    public static class UsuarioAssembler
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
        {

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var result = from TEnum e in values
                         select new { ID = (int)Enum.Parse(typeof(TEnum), e.ToString()), Name = e.ToString() };

            var tempValue = new { ID = 0, Name = "-- Select --" };

            var list = result.ToList(); // Create mutable list

            list.Insert(0, tempValue); // Add at beginning of list

            return new SelectList(list, "Id", "Name", enumObj);
        }

        public static UsuarioViewModel ConvertToViewModel(this Usuario request)
        {
            var resultado = new UsuarioViewModel
            {
                Id = request.Id,
                Usuario1 = request.Usuario1,
                Activo = request.Activo,
                ActiveDirectory = request.ActiveDirectory,
                Contrasenia = request.Contrasenia,
                RolId = request.RolId,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                FacilitadorId = request.FacilitadorId,
                FiscalizadorId = request.FiscalizadorId
            };
            return resultado;
        }
        public static Usuario ConvertToModel(this UsuarioViewModel model)
        {
            Usuario resultado = new Usuario
            {
                Id = model.Id,
                Usuario1 = model.Usuario1,
                Activo = model.Activo,
                ActiveDirectory = model.ActiveDirectory,
                Contrasenia = model.Contrasenia,
                RolId = model.RolId,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                FacilitadorId = model.FacilitadorId,
                FiscalizadorId = model.FiscalizadorId
            };
            return resultado;
        }
    }
    public static class OleoductoAssembler
    {
        public static List<OleoductoViewModel> ConvertToViewModel(this OleoductoResponse request)
        {
            List<OleoductoViewModel> Result = new List<OleoductoViewModel>();
            foreach (var item in request.List)
            {
                Result.Add(new OleoductoViewModel
                {
                    Id = item.Id,
                    Cliente = item.Cliente,
                    Descripcion = item.Descripcion,
                    NoLamina = item.NoLamina,
                    Ubicacion = item.Ubicacion,
                    Material1 = item.Material1,
                    Material2 = item.Material2,
                    Material3 = item.Material3,
                    Schedule1 = item.Schedule1.HasValue ? item.Schedule1.Value : 0,
                    Schedule2 = item.Schedule2.HasValue ? item.Schedule2.Value : 0,
                    Schedule3 = item.Schedule3.HasValue ? item.Schedule3.Value : 0,
                    BLPD = item.BLPD.HasValue ? item.BLPD.Value : 0,
                    Presion = item.Presion.HasValue ? item.Presion.Value : 0,
                    Temperatura = item.Temperatura.HasValue ? item.Temperatura.Value : 0,
                    BSW = item.BSW,
                    FechaInspeccion = item.FechaInspeccion.HasValue ? item.FechaInspeccion.Value : new System.DateTime(1950, 01, 01),
                    RowState = item.RowState,
                    LastUpdate = item.LastUpdate,
                    Codigo = item.Codigo,
                    LongitudTotal = item.LongitudTotal
                });
            }
            return Result;
        }
        public static OleoductoViewModel ConvertToViewModel(this Oleoducto request)
        {
            var resultado = new OleoductoViewModel
            {
                Id = request.Id,
                Codigo = request.Codigo,
                Cliente = request.Cliente,
                Descripcion = request.Descripcion,
                NoLamina = request.NoLamina,
                Ubicacion = request.Ubicacion,
                Material1 = request.Material1,
                Material2 = request.Material2,
                Material3 = request.Material3,
                Schedule1 = request.Schedule1.HasValue ? request.Schedule1.Value : 0,
                Schedule2 = request.Schedule2.HasValue ? request.Schedule2.Value : 0,
                Schedule3 = request.Schedule3.HasValue ? request.Schedule3.Value : 0,
                BLPD = request.BLPD.HasValue ? request.BLPD.Value : 0,
                Presion = request.Presion.HasValue ? request.Presion.Value : 0,
                Temperatura = request.Temperatura.HasValue ? request.Temperatura.Value : 0,
                BSW = request.BSW,
                FechaInspeccion = request.FechaInspeccion.HasValue ? request.FechaInspeccion.Value : new System.DateTime(1950, 01, 01),
                RowState = request.RowState,
                LastUpdate = request.LastUpdate
            };
            return resultado;
        }
        public static Oleoducto ConvertToModel(this OleoductoViewModel model)
        {
            Oleoducto resultado = new Oleoducto
            {
                Id = model.Id,
                Cliente = model.Cliente,
                Descripcion = model.Descripcion,
                NoLamina = model.NoLamina,
                Ubicacion = model.Ubicacion,
                Material1 = model.Material1,
                Material2 = model.Material2,
                Material3 = model.Material3,
                Schedule1 = model.Schedule1,
                Schedule2 = model.Schedule2,
                Schedule3 = model.Schedule3,
                BLPD = model.BLPD,
                Presion = model.Presion,
                Temperatura = model.Temperatura,
                BSW = model.BSW,
                FechaInspeccion = model.FechaInspeccion,
                RowState = model.RowState,
                LastUpdate = model.LastUpdate
            };
            return resultado;
        }
    }
    public static class TuberiaAssembler
    {
        public static List<RegistroInspeccionVisualModel> ConvertToViewModel(this RegistroInspeccionVisualResponse request)
        {
            List<RegistroInspeccionVisualModel> Result = new List<RegistroInspeccionVisualModel>();
            foreach (var item in request.List)
            {
                Result.Add(new RegistroInspeccionVisualModel
                {
                    Id = item.Id,
                    BSCAN = item.BSCAN.HasValue?item.BSCAN.Value:0,
                    CodigoDelTubo = item.CodigoDelTubo,
                    CodigoDelTubo01 = item.CodigoDelTubo01,
                    CodigoDelTubo02 = item.CodigoDelTubo02,
                    CodigoDelTubo03 = item.CodigoDelTubo03,
                    CondicionDelTramo = item.CondicionDelTramo,
                    CoordenadasUTM_X = item.CoordenadasUTM_X,
                    CoordenadasUTM_Y = item.CoordenadasUTM_Y,  //item.Schedule1.HasValue ? item.Schedule1.Value : 0,
                    CruceCarretera = item.CruceCarretera.HasValue ? item.CruceCarretera.Value : false,
                    Defecto = item.Defecto,
                    Defecto2 = item.Defecto2.HasValue ? item.Defecto2.Value : false,
                    Elastomero = item.Elastomero.HasValue ? item.Elastomero.Value : false,
                    EspesorMinimoRealRemanente = item.EspesorMinimoRealRemanente,
                    EspesorNominal = item.EspesorNominal,
                    EspesorPared = item.EspesorPared.HasValue ? item.EspesorPared.Value : 0,
                    RowState = item.RowState,
                    LastUpdate = item.LastUpdate.HasValue ? item.LastUpdate.Value : DateTime.Now,
                    EspesorRemanente = item.EspesorPared.HasValue ? item.EspesorPared.Value : 0,
                    EstadoProteccion = item.EstadoProteccion,
                    EstadoTuberia = item.EstadoTuberia,
                    ExtremoFinal1 = item.ExtremoFinal1.HasValue ? item.ExtremoFinal1.Value : 0,
                    ExtremoFinal2 = item.ExtremoFinal2.HasValue ? item.ExtremoFinal2.Value : 0,
                    ExtremoFinal3 = item.ExtremoFinal3.HasValue ? item.ExtremoFinal3.Value : 0,
                    ExtremoFinal4 = item.ExtremoFinal4.HasValue ? item.ExtremoFinal4.Value : 0,
                    ExtremoInicial1 = item.ExtremoInicial1.HasValue ? item.ExtremoInicial1.Value : 0,
                    ExtremoInicial2 = item.ExtremoInicial2.HasValue ? item.ExtremoInicial2.Value : 0,
                    ExtremoInicial3 = item.ExtremoInicial3.HasValue ? item.ExtremoInicial3.Value : 0,
                    ExtremoInicial4 = item.ExtremoInicial4.HasValue ? item.ExtremoInicial4.Value : 0,
                    ExtremoMedio1 = item.ExtremoMedio1.HasValue ? item.ExtremoMedio1.Value : 0,
                    ExtremoMedio2 = item.ExtremoMedio2.HasValue ? item.ExtremoMedio2.Value : 0,
                    ExtremoMedio3 = item.ExtremoMedio3.HasValue ? item.ExtremoMedio3.Value : 0,
                    ExtremoMedio4 = item.ExtremoMedio4.HasValue ? item.ExtremoMedio4.Value : 0,
                    LEFT_MINIMO = item.LEFT_MINIMO.HasValue ? item.LEFT_MINIMO.Value : 0,
                    List = new List<RegistroInspeccionVisual> { },
                    ListaTipoSoporte = new List<SelectListItem> { },
                    Longitud = item.Longitud.HasValue ? item.Longitud.Value : 0,
                    Maleza = item.Maleza.HasValue ? item.Maleza.Value : false,
                    MapeoCorrison = item.MapeoCorrison.HasValue ? item.MapeoCorrison.Value : 0,
                    NPS = item.NPS.HasValue ? item.NPS.Value : 0,
                    NumeroAnterior = item.NumeroAnterior.HasValue ? item.NumeroAnterior.Value : 0,
                    NumeroGrapas = item.NumeroGrapas.HasValue ? item.NumeroGrapas.Value : 0,
                    NumeroOleoducto = item.NumeroOleoducto,
                    ObservacionesDeLaInspeccionVisual = item.ObservacionesDeLaInspeccionVisual,
                    oleoducto = new Oleoducto() { Id = item.OleoductoID },
                    OleoductoID = item.OleoductoID,
                    Pintura = item.Pintura.HasValue ? item.Pintura.Value : false,
                    PitCorrosion = item.PitCorrosion.HasValue ? item.PitCorrosion.Value : 0,
                    Schedule = item.Schedule.HasValue ? item.Schedule.Value : 0,
                    SeleccionarTuberia = item.SeleccionarTuberia.HasValue ? item.SeleccionarTuberia.Value : false,
                    SHC = item.SHC.HasValue ? item.SHC.Value : 0,
                    TipoMaterial = item.TipoMaterial,
                    TipoProteccion = item.TipoProteccion,
                    TipoSoporte = item.TipoSoporte,
                    TuberiaAlrededor = item.TuberiaAlrededor.HasValue ? item.TuberiaAlrededor.Value : false,
                    TuberiaId = item.TuberiaId.HasValue ? item.TuberiaId.Value : 0,
                    UltimaFechaDeInspeccion = item.UltimaFechaDeInspeccion.HasValue ? item.UltimaFechaDeInspeccion.Value : DateTime.Now

                });
            }
            return Result;
        }
        public static RegistroInspeccionVisualModel ConvertToViewModel(this RegistroInspeccionVisual request)
        {
            var resultado = new RegistroInspeccionVisualModel
            {
                Id = request.Id,
                BSCAN = request.BSCAN.HasValue ? request.BSCAN.Value : 0,
                CodigoDelTubo = request.CodigoDelTubo,
                CodigoDelTubo01 = request.CodigoDelTubo01,
                CodigoDelTubo02 = request.CodigoDelTubo02,
                CodigoDelTubo03 = request.CodigoDelTubo03,
                CondicionDelTramo = request.CondicionDelTramo,
                CoordenadasUTM_X = request.CoordenadasUTM_X,
                CoordenadasUTM_Y = request.CoordenadasUTM_Y,  //request.Schedule1.HasValue ? request.Schedule1.Value : 0,
                CruceCarretera = request.CruceCarretera.HasValue ? request.CruceCarretera.Value : false,
                Defecto = request.Defecto,
                Defecto2 = request.Defecto2.HasValue ? request.Defecto2.Value : false,
                Elastomero = request.Elastomero.HasValue ? request.Elastomero.Value : false,
                EspesorMinimoRealRemanente = request.EspesorMinimoRealRemanente,
                EspesorNominal = request.EspesorNominal,
                EspesorPared = request.EspesorPared.HasValue ? request.EspesorPared.Value : 0,
                RowState = request.RowState,
                LastUpdate = request.LastUpdate.HasValue ? request.LastUpdate.Value : DateTime.Now,
                EspesorRemanente = request.EspesorPared.HasValue ? request.EspesorPared.Value : 0,
                EstadoProteccion = request.EstadoProteccion,
                EstadoTuberia = request.EstadoTuberia,
                ExtremoFinal1 = request.ExtremoFinal1.HasValue ? request.ExtremoFinal1.Value : 0,
                ExtremoFinal2 = request.ExtremoFinal2.HasValue ? request.ExtremoFinal2.Value : 0,
                ExtremoFinal3 = request.ExtremoFinal3.HasValue ? request.ExtremoFinal3.Value : 0,
                ExtremoFinal4 = request.ExtremoFinal4.HasValue ? request.ExtremoFinal4.Value : 0,
                ExtremoInicial1 = request.ExtremoInicial1.HasValue ? request.ExtremoInicial1.Value : 0,
                ExtremoInicial2 = request.ExtremoInicial2.HasValue ? request.ExtremoInicial2.Value : 0,
                ExtremoInicial3 = request.ExtremoInicial3.HasValue ? request.ExtremoInicial3.Value : 0,
                ExtremoInicial4 = request.ExtremoInicial4.HasValue ? request.ExtremoInicial4.Value : 0,
                ExtremoMedio1 = request.ExtremoMedio1.HasValue ? request.ExtremoMedio1.Value : 0,
                ExtremoMedio2 = request.ExtremoMedio2.HasValue ? request.ExtremoMedio2.Value : 0,
                ExtremoMedio3 = request.ExtremoMedio3.HasValue ? request.ExtremoMedio3.Value : 0,
                ExtremoMedio4 = request.ExtremoMedio4.HasValue ? request.ExtremoMedio4.Value : 0,
                LEFT_MINIMO = request.LEFT_MINIMO.HasValue ? request.LEFT_MINIMO.Value : 0,
                List = new List<RegistroInspeccionVisual> { },
                ListaTipoSoporte = new List<SelectListItem> { },
                Longitud = request.Longitud.HasValue ? request.Longitud.Value : 0,
                Maleza = request.Maleza.HasValue ? request.Maleza.Value : false,
                MapeoCorrison = request.MapeoCorrison.HasValue ? request.MapeoCorrison.Value : 0,
                NPS = request.NPS.HasValue ? request.NPS.Value : 0,
                NumeroAnterior = request.NumeroAnterior.HasValue ? request.NumeroAnterior.Value : 0,
                NumeroGrapas = request.NumeroGrapas.HasValue ? request.NumeroGrapas.Value : 0,
                NumeroOleoducto = request.NumeroOleoducto,
                ObservacionesDeLaInspeccionVisual = request.ObservacionesDeLaInspeccionVisual,
                oleoducto = new Oleoducto() { Id = request.OleoductoID },
                OleoductoID = request.OleoductoID,
                Pintura = request.Pintura.HasValue ? request.Pintura.Value : false,
                PitCorrosion = request.PitCorrosion.HasValue ? request.PitCorrosion.Value : 0,
                Schedule = request.Schedule.HasValue ? request.Schedule.Value : 0,
                SeleccionarTuberia = request.SeleccionarTuberia.HasValue ? request.SeleccionarTuberia.Value : false,
                SHC = request.SHC.HasValue ? request.SHC.Value : 0,
                TipoMaterial = request.TipoMaterial,
                TipoProteccion = request.TipoProteccion,
                TipoSoporte = request.TipoSoporte,
                TuberiaAlrededor = request.TuberiaAlrededor.HasValue ? request.TuberiaAlrededor.Value : false,
                TuberiaId = request.TuberiaId.HasValue ? request.TuberiaId.Value : 0,
                UltimaFechaDeInspeccion = request.UltimaFechaDeInspeccion.HasValue ? request.UltimaFechaDeInspeccion.Value : DateTime.Now

            };
            return resultado;
        }
        public static RegistroInspeccionVisual ConvertToModel(this RegistroInspeccionVisualModel model)
        {
            RegistroInspeccionVisual resultado = new RegistroInspeccionVisual
            {
                Id = model.Id,
                BSCAN = model.BSCAN,
                CodigoDelTubo = model.CodigoDelTubo,
                CodigoDelTubo01 = model.CodigoDelTubo01,
                CodigoDelTubo02 = model.CodigoDelTubo02,
                CodigoDelTubo03 = model.CodigoDelTubo03,
                CondicionDelTramo = model.CondicionDelTramo,
                CoordenadasUTM_X = model.CoordenadasUTM_X,
                CoordenadasUTM_Y = model.CoordenadasUTM_Y,  //model.Schedule1.HasValue ? model.Schedule1.Value : 0,
                CruceCarretera = model.CruceCarretera,
                Defecto = model.Defecto,
                Defecto2 = model.Defecto2,
                Elastomero = model.Elastomero,
                EspesorMinimoRealRemanente = model.EspesorMinimoRealRemanente,
                EspesorNominal = model.EspesorNominal,
                EspesorPared = model.EspesorPared,
                RowState = model.RowState,
                LastUpdate = model.LastUpdate,
                EspesorRemanente = model.EspesorPared,
                EstadoProteccion = model.EstadoProteccion,
                EstadoTuberia = model.EstadoTuberia,
                ExtremoFinal1 = model.ExtremoFinal1,
                ExtremoFinal2 = model.ExtremoFinal2,
                ExtremoFinal3 = model.ExtremoFinal3,
                ExtremoFinal4 = model.ExtremoFinal4,
                ExtremoInicial1 = model.ExtremoInicial1,
                ExtremoInicial2 = model.ExtremoInicial2,
                ExtremoInicial3 = model.ExtremoInicial3,
                ExtremoInicial4 = model.ExtremoInicial4,
                ExtremoMedio1 = model.ExtremoMedio1,
                ExtremoMedio2 = model.ExtremoMedio2,
                ExtremoMedio3 = model.ExtremoMedio3,
                ExtremoMedio4 = model.ExtremoMedio4,
                LEFT_MINIMO = model.LEFT_MINIMO,
                Longitud = model.Longitud,
                Maleza = model.Maleza,
                MapeoCorrison = model.MapeoCorrison,
                NPS = model.NPS,
                NumeroAnterior = model.NumeroAnterior,
                NumeroGrapas = model.NumeroGrapas,
                NumeroOleoducto = model.NumeroOleoducto,
                ObservacionesDeLaInspeccionVisual = model.ObservacionesDeLaInspeccionVisual,
                OleoductoID = model.OleoductoID,
                Pintura = model.Pintura,
                PitCorrosion = model.PitCorrosion,
                Schedule = model.Schedule,
                SeleccionarTuberia = model.SeleccionarTuberia,
                SHC = model.SHC,
                TipoMaterial = model.TipoMaterial,
                TipoProteccion = model.TipoProteccion,
                TipoSoporte = model.TipoSoporte,
                TuberiaAlrededor = model.TuberiaAlrededor,
                TuberiaId = model.TuberiaId,
                UltimaFechaDeInspeccion = model.UltimaFechaDeInspeccion
            };
            return resultado;
        }
    }

    public static class AccesoriosAssembler
    {
        public static List<AccesoriosModels> ConvertToViewModel(this AccesorioResponse request)
        {
            List<AccesoriosModels> Result = new List<AccesoriosModels>();
            foreach (var item in request.List)
            {
                Result.Add(new AccesoriosModels
                {
                    Id = item.Id,
                    NombreAccesorio = item.NombreAccesorio,
                    CodigoTuberia = item.CodigoTuberia,
                    Correlativo = item.Correlativo,
                    NPS = item.NPS.HasValue ? item.NPS.Value : 0,
                    Schedule = item.Schedule.HasValue ? item.Schedule.Value : 0,
                    TipoMaterial = item.TipoMaterial,
                    Longitud = item.Longitud.HasValue ? item.Longitud.Value : 0,
                    CoordenadasUTMX = item.CoordenadasUTMX.HasValue ? item.CoordenadasUTMX.Value : 0,
                    CoordenadasUTMY = item.CoordenadasUTMY.HasValue ? item.CoordenadasUTMY.Value : 0,
                    Observaciones = item.Observaciones,
                    CondicionAccesorio = item.CondicionAccesorio,
                    RowState = item.RowState,
                    LastUpdate = item.LastUpdate.HasValue ? item.LastUpdate.Value : DateTime.Now
                });
            }
            return Result;
        }
        public static AccesoriosModels ConvertToViewModel(this Accesorio request)
        {
            var resultado = new AccesoriosModels
            {
                Id = request.Id,
                NombreAccesorio = request.NombreAccesorio,
                CodigoTuberia = request.CodigoTuberia,
                Correlativo = request.Correlativo,
                NPS = request.NPS.HasValue ? request.NPS.Value : 0,
                Schedule = request.Schedule.HasValue ? request.Schedule.Value : 0,
                TipoMaterial = request.TipoMaterial,
                Longitud = request.Longitud.HasValue ? request.Longitud.Value : 0,
                CoordenadasUTMX = request.CoordenadasUTMX.HasValue ? request.CoordenadasUTMX.Value : 0,
                CoordenadasUTMY = request.CoordenadasUTMY.HasValue ? request.CoordenadasUTMY.Value : 0,
                Observaciones = request.Observaciones,
                CondicionAccesorio = request.CondicionAccesorio,
                RowState = request.RowState,
                LastUpdate = request.LastUpdate.HasValue ? request.LastUpdate.Value : DateTime.Now
            };
            return resultado;
        }
        public static Accesorio ConvertToModel(this AccesoriosModels model)
        {
            Accesorio resultado = new Accesorio
            {
                Id = model.Id,
                NombreAccesorio = model.NombreAccesorio,
                CodigoTuberia = model.CodigoTuberia,
                Correlativo = model.Correlativo,
                NPS = model.NPS,
                Schedule = model.Schedule,
                TipoMaterial = model.TipoMaterial,
                Longitud = model.Longitud,
                CoordenadasUTMX = model.CoordenadasUTMX,
                CoordenadasUTMY = model.CoordenadasUTMY,
                Observaciones = model.Observaciones,
                CondicionAccesorio = model.CondicionAccesorio,
                RowState = model.RowState,
                LastUpdate = model.LastUpdate
            };
            return resultado;
        }
    }
}