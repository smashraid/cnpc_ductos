using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
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
                Accesorio d = r.Retrieve(p => p.NombreAccesorio == ductoToUpdate.NombreAccesorio &
                    p.CodigoTuberia == ductoToUpdate.CodigoTuberia &
                    p.Correlativo == ductoToUpdate.Correlativo &
                    p.CodigoAccesorio == ductoToUpdate.CodigoAccesorio &
                    p.NPS == ductoToUpdate.NPS &
                    p.Schedule == ductoToUpdate.Schedule &
                    p.TipoMaterial == ductoToUpdate.TipoMaterial &
                    p.Longitud == ductoToUpdate.Longitud &
                    p.CoordenadasUTMX == ductoToUpdate.CoordenadasUTMX &
                    p.CoordenadasUTMY == ductoToUpdate.CoordenadasUTMY &
                    p.Observaciones == ductoToUpdate.Observaciones &
                    p.CondicionAccesorio == ductoToUpdate.CondicionAccesorio &
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
                Result = r.Filter(p => p.NombreAccesorio.Contains(Nombre));
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
