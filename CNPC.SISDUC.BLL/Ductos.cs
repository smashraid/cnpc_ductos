using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model;

namespace CNPC.SISDUC.BLL
{
    public class Ductos
    {
        public Ducto Create(Ducto newDucto)
        {
            Ducto Result = null;
            using (var r = new Repository<Ducto>())
            {
                Ducto d = r.Retrieve(p => p.Ducto1 == newDucto.Ducto1);
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
        public Ducto RetrieveByID(int ID)
        {
            Ducto Result = null;
            using (var r = new Repository<Ducto>())
            {
                Result = r.Retrieve(p => p.Id == ID);
            }
            return Result;
        }
        public bool Update(Ducto ductoToUpdate)
        {
            bool Result = false;
            using (var r = new Repository<Ducto>())
            {
                Ducto d = r.Retrieve(p => p.Ducto1 == ductoToUpdate.Ducto1);
                if (d != null)
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
                    using (var r = new Repository<Ducto>())
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
        public List<Ducto> FilterByName(string Nombre)
        {
            List<Ducto> Result = null;
            using (var r = new Repository<Ducto>())
            {
                Result = r.Filter(p => p.Ducto1.Contains(Nombre));
            }
            return Result;
        }
        public Ducto FilterByID(int ID)
        {
            Ducto Result = null;
            using (var r = new Repository<Ducto>())
            {
                Result = r.Retrieve(p => p.Id == ID);
            }
            return Result;
        }
    }
}
