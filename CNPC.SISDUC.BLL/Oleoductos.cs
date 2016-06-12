﻿using System;
using System.Collections.Generic;
using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model;

namespace CNPC.SISDUC.BLL
{
    public class Oleoductos:IDisposable
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
                Oleoducto d = r.Retrieve(p => p.Codigo == ductoToUpdate.Codigo);
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
            using (var r = new Repository<Oleoducto>())
            {
                Result = r.FilterByName(Nombre,page,records);
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