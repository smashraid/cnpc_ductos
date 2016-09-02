using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using System;
using System.Collections.Generic;

namespace CNPC.SISDUC.BLL
{
    public class CambiosTuberiaBLL : IDisposable
    {
        public CambiosTuberia Create(CambiosTuberia registro)
        {
            CambiosTuberia Result = null;
            using (var r = new Repository<CambiosTuberia>())
            {
                CambiosTuberia d = r.Retrieve(p => p.Id == registro.Id);
                if (d == null)
                {
                    Result = r.Create(registro);
                }
                else
                {
                    throw (new Exception("Error al guardar el Cambios Tuberia"));
                }
            }
            return Result;
        }
        public CambiosTuberia RetrieveByID(int ID)
        {
            CambiosTuberia Result = null;
            using (var r = new Repository<CambiosTuberia>())
            {
                Result = r.Retrieve(p => p.Id == ID);
            }
            return Result;
        }
        public bool Update(CambiosTuberia registro)
        {
            bool Result = false;
            using (var r = new Repository<CambiosTuberia>())
            {
                CambiosTuberia d = r.Retrieve(p => p.Motivo == registro.Motivo &
                    p.OrdenServicio == registro.OrdenServicio &
                    p.RowState == registro.RowState &
                    p.LastUpdate == registro.LastUpdate 
                    );
                if (d == null)
                {
                    Result = r.Update(registro);
                }
                else
                {
                    throw (new Exception("Error al actualizar el Cambios Tuberia"));
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
                    using (var r = new Repository<CambiosTuberia>())
                    {
                        Result = r.Delete(d);
                    }
                }
                else
                {
                    throw (new Exception("El Cambios de Tuberia ya fue eliminado"));
                }
            }
            else
            {
                throw (new Exception("Error al eliminar el Cambio de Tuberia"));
            }
            return Result;
        }
        public List<CambiosTuberia> FilterByName(string Nombre)
        {
            List<CambiosTuberia> Result = null;
            using (var r = new Repository<CambiosTuberia>())
            {
                Result = r.Filter(p => p.Motivo.Contains(Nombre));
            }
            return Result;
        }
        public CambiosTuberiaResponse FilterByName(int TuberiaID, string Nombre, int page, int records)
        {
            CambiosTuberiaResponse Result = null;
            using (var r = new Repository<CambiosTuberia>())
            {
                Result = r.FilterByMotivoCambiosTuberia(TuberiaID, Nombre, page, records);
            }
            return Result;
        }
        public CambiosTuberiaResponse GetListCambiosTuberia(string NumeroOleoducto, int TuberiaID,  int page, int records)
        {
            CambiosTuberiaResponse Result = null;
            using (var r = new Repository<CambiosTuberia>())
            {
                Result = r.usp_GetListCambiosTuberia(NumeroOleoducto, TuberiaID, records, page);
            }
            return Result;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
