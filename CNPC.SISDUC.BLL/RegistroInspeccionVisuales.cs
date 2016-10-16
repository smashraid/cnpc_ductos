using System;
using System.Collections.Generic;
using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;

namespace CNPC.SISDUC.BLL
{
    public class RegistroInspeccionVisuales : IDisposable
    {
        public RegistroInspeccionVisual Create(RegistroInspeccionVisual newRegistro)
        {
            RegistroInspeccionVisual Result = null;
            using (var r = new Repository<RegistroInspeccionVisual>())
            {
                RegistroInspeccionVisual d = r.Retrieve(p => p.CodigoDelTubo == newRegistro.CodigoDelTubo);
                if (d == null)
                {
                    Result = r.Create(newRegistro);
                }
                else
                {
                    throw (new Exception("El Registro Inspección Visual especificado ya existe"));
                }
            }
            return Result;
        }
        public RegistroInspeccionVisual RetrieveByID(int ID)
        {
            RegistroInspeccionVisual Result = null;
            using (var r = new Repository<RegistroInspeccionVisual>())
            {
                Result = r.Retrieve(p => p.Id == ID);
            }
            return Result;
        }
        public bool Update(RegistroInspeccionVisual registroToUpdate)
        {
            bool Result = false;
            using (var r = new Repository<RegistroInspeccionVisual>())
            {
                RegistroInspeccionVisual d = r.Retrieve(p => p.CodigoDelTubo == registroToUpdate.CodigoDelTubo &
                    p.NumeroAnterior == registroToUpdate.NumeroAnterior &
                    p.NPS == registroToUpdate.NPS &
                    p.Schedule == registroToUpdate.Schedule &
                    p.SHC == registroToUpdate.SHC &
                    p.TipoMaterial == registroToUpdate.TipoMaterial &
                    p.Longitud == registroToUpdate.Longitud &
                    p.CoordenadasUTM_X == registroToUpdate.CoordenadasUTM_X &
                    p.CoordenadasUTM_Y == registroToUpdate.CoordenadasUTM_Y &
                    p.ExtremoInicial1 == registroToUpdate.ExtremoInicial1 &
                    p.ExtremoInicial2 == registroToUpdate.ExtremoInicial2 &
                    p.ExtremoInicial3 == registroToUpdate.ExtremoInicial3 &
                    p.ExtremoInicial4 == registroToUpdate.ExtremoInicial4 &
                    p.BSCAN == registroToUpdate.BSCAN &
                    p.EspesorPared == registroToUpdate.EspesorPared &
                    p.ExtremoMedio1 == registroToUpdate.ExtremoMedio1 &
                    p.ExtremoMedio2 == registroToUpdate.ExtremoMedio2 &
                    p.ExtremoMedio3 == registroToUpdate.ExtremoMedio3 &
                    p.ExtremoMedio4 == registroToUpdate.ExtremoMedio4 &
                    p.MapeoCorrison == registroToUpdate.MapeoCorrison &
                    p.PitCorrosion == registroToUpdate.PitCorrosion &
                    p.ExtremoFinal1 == registroToUpdate.ExtremoFinal1 &
                    p.ExtremoFinal2 == registroToUpdate.ExtremoFinal2 &
                    p.ExtremoFinal3 == registroToUpdate.ExtremoFinal3 &
                    p.ExtremoFinal4 == registroToUpdate.ExtremoFinal4 &
                    p.LEFT_MINIMO == registroToUpdate.LEFT_MINIMO &
                    p.EspesorRemanente == registroToUpdate.EspesorRemanente &
                    p.Defecto == registroToUpdate.Defecto &
                    p.Defecto2 == registroToUpdate.Defecto2 &
                    p.NumeroGrapas == registroToUpdate.NumeroGrapas &
                    p.TipoSoporte == registroToUpdate.TipoSoporte &
                    p.Elastomero == registroToUpdate.Elastomero &
                    p.Maleza == registroToUpdate.Maleza &
                    p.TuberiaAlrededor == registroToUpdate.TuberiaAlrededor &
                    p.Pintura == registroToUpdate.Pintura &
                    p.CruceCarretera == registroToUpdate.CruceCarretera &
                    p.TipoProteccion == registroToUpdate.TipoProteccion &
                    p.EstadoProteccion == registroToUpdate.EstadoProteccion &
                    p.EstadoTuberia == registroToUpdate.EstadoTuberia &
                    p.UltimaFechaDeInspeccion == registroToUpdate.UltimaFechaDeInspeccion &
                    p.SeleccionarTuberia == registroToUpdate.SeleccionarTuberia &
                    p.RowState == registroToUpdate.RowState &
                    p.LastUpdate == registroToUpdate.LastUpdate
                    );
                if (d == null)
                {

                    Result = r.Update(registroToUpdate);
                }
                else
                {
                    throw (new Exception("El Registro de Inspección Visual especificado No existe"));
                }
            }
            return Result;
        }
        public bool Delete(int ID)
        {
            bool Result = false;
            var d = RetrieveByID(ID);
            if (d != null)
            {
                if (d.RowState != "D")
                {
                    using (var r = new Repository<RegistroInspeccionVisual>())
                    {
                        d.RowState = "D";
                        Result = r.Update(d);
                        //Result = r.Delete(d);
                    }
                }
                else
                {
                    throw (new Exception("El Registro de Inspeccion Visual ya fue eliminado"));
                }
            }
            else
            {
                throw (new Exception("El Registro de Inspeccion Visual especificado no existe"));
            }
            return Result;
        }
        public List<RegistroInspeccionVisual> FilterByName(string Nombre)
        {
            List<RegistroInspeccionVisual> Result = null;
            using (var r = new Repository<RegistroInspeccionVisual>())
            {
                Result = r.Filter(p => p.CodigoDelTubo.Contains(Nombre));
            }
            return Result;
        }
        public RegistroInspeccionVisualResponse FilterByNameRegistroInspeccionVisual(int OleoductoId, string Nombre, int page, int records)
        {
            RegistroInspeccionVisualResponse Result = null;
            Oleoducto ducto = null;
            using (var r = new Repository<RegistroInspeccionVisual>())
            {
                Result = r.FilterByNameRegistroInspeccionVisual(OleoductoId, Nombre, page, records);
            }
            using (var p = new Repository<Oleoducto>())
            {
                ducto = p.Retrieve(q => q.Id == OleoductoId);
                ducto.LongitudTotal = p.LongitudOleoducto(OleoductoId);
            }
            using (var q = new Repository<TipoSoporte>())
            {
                Result.ListTipoSoporte.List = q.Filter(p=>p.Nombre.Contains(""));
            }
            Result.oleoducto = ducto;
            return Result;
        }
        public RegistroInspeccionVisualResponse FilterByDuctoIdRegistroInspeccionVisual(int ductoId, string Nombre, string Estado)
        {
            RegistroInspeccionVisualResponse Result = new RegistroInspeccionVisualResponse();
            Oleoducto ducto = null;
            using (var r = new Repository<RegistroInspeccionVisual>())
            {
                Result.List = r.Filter(p => p.OleoductoID == ductoId && p.CodigoDelTubo.Contains(Nombre) && p.RowState == Estado);
            }
            using (var p = new Repository<Oleoducto>())
            {
                ducto = p.Retrieve(q => q.Id == ductoId);
                ducto.LongitudTotal = p.LongitudOleoducto(ductoId);
            }
            Result.oleoducto = ducto;
            return Result;
        }
        public RegistroInspeccionVisual FilterByID(int ID)
        {
            RegistroInspeccionVisual Result = null;
            using (var r = new Repository<RegistroInspeccionVisual>())
            {
                Result = r.Retrieve(p => p.Id == ID);
            }
            return Result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
