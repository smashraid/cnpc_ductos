using System;
using System.Collections.Generic;
using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;

namespace CNPC.SISDUC.BLL
{
    public class Oleoductos : IDisposable
    {
        public Oleoducto Create(Oleoducto newDucto)
        {
            Oleoducto Result = null;
            using (var r = new Repository<Oleoducto>())
            {
                Oleoducto d = r.Retrieve(p => p.Codigo == newDucto.Codigo);
                if (d == null)
                {
                    Result = r.Create(newDucto);
                }
                else
                {
                    throw (new Exception("El Ducto especificado ya existe"));
                }
            }
            return Result;
        }
        public Oleoducto RetrieveByID(int ID)
        {
            Oleoducto Result = null;
            using (var r = new Repository<Oleoducto>())
            {
                Result = r.Retrieve(p => p.Id == ID);
            }
            return Result;
        }
        public bool Update(Oleoducto ductoToUpdate)
        {
            bool Result = false;
            using (var r = new Repository<Oleoducto>())
            {
                Oleoducto d = r.Retrieve(p => p.Codigo == ductoToUpdate.Codigo &
                    p.Descripcion == ductoToUpdate.Descripcion &
                    p.Codigo == ductoToUpdate.Codigo &
                    p.Cliente == ductoToUpdate.Cliente &
                    p.BLPD == ductoToUpdate.BLPD &
                    p.BSW == ductoToUpdate.BSW &
                    p.FechaInspeccion == ductoToUpdate.FechaInspeccion &
                    p.Material1 == ductoToUpdate.Material1 &
                    p.Material2 == ductoToUpdate.Material2 &
                    p.Material3 == ductoToUpdate.Material3 &
                    p.NoLamina == ductoToUpdate.NoLamina &
                    p.Presion == ductoToUpdate.Presion &
                    p.Schedule1 == ductoToUpdate.Schedule1 &
                    p.Schedule2 == ductoToUpdate.Schedule2 &
                    p.Schedule3 == ductoToUpdate.Schedule3 &
                    p.Temperatura == ductoToUpdate.Temperatura &
                    p.Ubicacion == ductoToUpdate.Ubicacion);
                if (d == null)
                {
                    Result = r.Update(ductoToUpdate);
                }
                else
                {
                    throw (new Exception("El Ducto especificado No existe"));
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
                    using (var r = new Repository<Oleoducto>())
                    {
                        Result = r.Delete(d);
                    }
                }
                else
                {
                    throw (new Exception("El Ducto ya fue eliminado"));
                }
            }
            else
            {
                throw (new Exception("El Ducto especificado no existe"));
            }
            return Result;
        }
        public List<Oleoducto> FilterByName(string Nombre)
        {
            List<Oleoducto> Result = null;
            using (var r = new Repository<Oleoducto>())
            {
                Result = r.Filter(p => p.Codigo.Contains(Nombre));
            }
            return Result;
        }
        public OleoductoResponse FilterByName(string Nombre, int page, int records)
        {
            OleoductoResponse Result = null;
            try
            {
                using (var r = new Repository<Oleoducto>())
                {
                    Result = r.FilterByNameOleoducto(Nombre, page, records);
                }
            }
            catch (Exception ex)
            {
                Result.Resultado = false;
                Result.MensajeError += " Capa BLL: " + ex.Message;
            }
            return Result;
        }
        public Oleoducto FilterByID(int ID)
        {
            Oleoducto Result = null;
            using (var r = new Repository<Oleoducto>())
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
