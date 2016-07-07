using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model;
using System;
using System.Collections.Generic;

namespace CNPC.SISDUC.BLL
{
    public class Accesorios : IDisposable
    {
        public Accesorio Create(Accesorio newAccesorio)
        {
            Accesorio Result = null;
            using (var r = new Repository<Accesorio>())
            {
                Accesorio d = r.Retrieve(p => p.Id == newAccesorio.Id);
                if (d == null)
                {
                    Result = r.Create(newAccesorio);
                }
                else
                {
                    throw (new Exception("El Accesorio especificado ya existe"));
                }
            }
            return Result;
        }
        public Accesorio RetrieveByID(int ID)
        {
            Accesorio Result = null;
            using (var r = new Repository<Accesorio>())
            {
                Result = r.Retrieve(p => p.Id == ID);
            }
            return Result;
        }
        public bool Update(Accesorio ductoToUpdate)
        {
            bool Result = false;
            using (var r = new Repository<Accesorio>())
            {
                Accesorio d = r.Retrieve(p => p.TuberiaId == ductoToUpdate.TuberiaId &
                    p.Accesorio1 == ductoToUpdate.Accesorio1 &
                    p.TipoAccesorio == ductoToUpdate.TipoAccesorio &
                    p.CodigoAccesorio1 == ductoToUpdate.CodigoAccesorio1 &
                    p.CodigoAccesorio2 == ductoToUpdate.CodigoAccesorio2 &
                    p.CodigoAccesorio3 == ductoToUpdate.CodigoAccesorio3 &
                    p.NPS == ductoToUpdate.NPS &
                    p.Schedule == ductoToUpdate.Schedule &
                    p.TipoMaterial == ductoToUpdate.TipoMaterial &
                    p.Longitud == ductoToUpdate.Longitud &
                    p.CoordenadasUTMX == ductoToUpdate.CoordenadasUTMX &
                    p.CoordenadasUTMY == ductoToUpdate.CoordenadasUTMY &
                    p.ExtremoInicial == ductoToUpdate.ExtremoInicial &
                    p.ExtremoFinal == ductoToUpdate.ExtremoFinal &
                    p.ExtremoMedio == ductoToUpdate.ExtremoMedio &
                    p.BSCAN == ductoToUpdate.BSCAN &
                    p.MapeoCorrosion == ductoToUpdate.MapeoCorrosion &
                    p.InspeccionSonica == ductoToUpdate.InspeccionSonica &
                    p.EspesorPared == ductoToUpdate.EspesorPared &
                    p.PitCorrosion == ductoToUpdate.PitCorrosion &
                    p.EspesorRemanente == ductoToUpdate.EspesorRemanente &
                    p.EstadoAccesorio == ductoToUpdate.EstadoAccesorio &
                    p.Pintura == ductoToUpdate.Pintura &
                    p.Defecto1 == ductoToUpdate.Defecto1 &
                    p.Defecto2 == ductoToUpdate.Defecto2 &
                    p.NumeroGrapas == ductoToUpdate.NumeroGrapas &
                    p.Observaciones == ductoToUpdate.Observaciones &
                    p.RowState == ductoToUpdate.RowState &
                    p.LastUpdate == ductoToUpdate.LastUpdate 
                    );
                if (d == null)
                {
                    Result = r.Update(ductoToUpdate);
                }
                else
                {
                    throw (new Exception("El Accesorio especificado No existe"));
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
                    using (var r = new Repository<Accesorio>())
                    {
                        Result = r.Delete(d);
                    }
                }
                else
                {
                    throw (new Exception("El Accesorio ya fue eliminado"));
                }
            }
            else
            {
                throw (new Exception("El Accesorio especificado no existe"));
            }
            return Result;
        }
        public List<Accesorio> FilterByName(string Nombre)
        {
            List<Accesorio> Result = null;
            using (var r = new Repository<Accesorio>())
            {
                Result = r.Filter(p => p.Accesorio1.Contains(Nombre));
            }
            return Result;
        }
        public AccesorioResponse FilterByName(int TuberiaID, string Nombre, int page, int records)
        {
            AccesorioResponse Result = null;
            using (var r = new Repository<Accesorio>())
            {
                Result = r.FilterByNameAccesorio(TuberiaID, Nombre, page, records);
            }
            return Result;
        }
        public AccesorioResponse FilterByNameAccesorio(int TuberiaId, string Nombre, int page, int records)
        {
            AccesorioResponse Result = null;
            using (var r = new Repository<Accesorio>())
            {
                Result = r.FilterByNameAccesorio(TuberiaId, Nombre, page, records);
            }
           
            return Result;
        }
        public Accesorio FilterByID(int ID)
        {
            Accesorio Result = null;
            using (var r = new Repository<Accesorio>())
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
