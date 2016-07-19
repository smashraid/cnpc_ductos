using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CNPC.SISDUC.BLL
{
    public class UsuarioBLL : IDisposable
    {
        public Usuario Create(Usuario newItem)
        {
            Usuario result;
            var estado = EEstadoRowState.D.ToString();
            using (var r = new Repository<Usuario>())
            {
                var pbuscado =
                    r.Retrieve(q => q.Usuario1 == newItem.Usuario1 && q.RowState != estado);
                if (pbuscado == null)
                {
                    newItem.RowState = "A";
                    newItem.LastUpdate = DateTime.Now;
                    result = r.Create(newItem);
                }
                else
                {
                    throw new Exception("El Usuario ya fue registrado");
                }
            }
            return result;
        }
        public bool UsuarioActivo(string usuario)
        {
            bool result;
            using (var r = new Repository<Usuario>())
            {
                result = r.Retrieve(q => q.Usuario1 == usuario).RowState != "D";
            }
            return result;
        }
        public Usuario RetrieveByID(int ID)
        {
            Usuario result;
            using (var r = new Repository<Usuario>())
            {
                result = r.Retrieve(q => q.Id == ID);
                if (result == null)
                {
                    throw new Exception("El Usuario no fue localizado");
                }
            }
            return result;
        }
        public Usuario ValidaLogin(Usuario toItem)
        {
            Usuario result = null;
            using (var r = new Repository<Usuario>())
            {
                result= r.usp_ValidarUsuario(toItem.Usuario1, toItem.Contrasenia, toItem.ActiveDirectory);
            }
            return result;
        }
        public bool Update(Usuario toItem)
        {
            bool result;
            using (var r = new Repository<Usuario>())
            {

                var tExistente =
                    r.Retrieve(q => q.Id > 0 && q.Contrasenia == toItem.Contrasenia && q.Usuario1 == toItem.Usuario1 && q.RolId == toItem.RolId && q.FacilitadorId == toItem.FacilitadorId
                  && q.Nombre == toItem.Nombre && q.Apellido == toItem.Apellido && q.FiscalizadorId == toItem.FiscalizadorId
                  && q.ActiveDirectory == toItem.ActiveDirectory);
                if (tExistente == null)
                {

                    toItem.LastUpdate = DateTime.Now;
                    toItem.RowState = EEstadoRowState.M.ToString();
                    result = r.Update(toItem);
                }
                else
                {
                    throw new Exception("Usuario no Existe");
                }
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result;
            var tExistente = RetrieveByID(id);
            var rowState = EEstadoRowState.D.ToString();
            if (tExistente != null)
            {
                if (tExistente.RowState == EEstadoRowState.D.ToString())
                {
                    throw new Exception("Usuario Inxistente");
                }
                
                using (var r = new Repository<Usuario>())
                {
                    tExistente.RowState = EEstadoRowState.D.ToString(); ;
                    result = r.Update(tExistente);
                }
            }
            else
            {
                throw new Exception("Usuario Inexistente");
            }
            return result;
        }
        public IEnumerable<Usuario> List(string rowState = "T")
        {
            using (var r = new Repository<Usuario>())
            {
                List<Usuario> result;
                switch (rowState)
                {
                    case "T":
                        result = r.Filter(q => q.Id > 0).OrderBy(q => q.Id).ToList();
                        return result
                            .ToList();
                    case "DU":
                        result = r.Filter(q => q.RowState != "U").OrderBy(q => q.Id).ToList();
                        return result
                            .ToList();
                    default:
                        result = r.Filter(q => q.RowState == rowState).OrderBy(q => q.Id).ToList();
                        return result
                            .ToList();
                }
            }
        }
        public int ListCount()
        {
            var rowstate = EEstadoRowState.D.ToString();
            var Result = 0;
            using (var r = new Repository<Usuario>())
            {
                Result = r.Filter(q => q.Id > 0 && q.RowState != rowstate).Count();
            }
            return Result;
        }
        public IEnumerable<Usuario> Create(IEnumerable<Usuario> newItems)
        {
            List<Usuario> results = new List<Usuario>();
            Usuario result;
            using (var r = new Repository<Usuario>())
            {
                {
                    foreach (var newItem in newItems)
                    {
                        var pbuscado =
                          r.Retrieve(q => q.Usuario1 == newItem.Usuario1);
                        if (pbuscado == null)
                        {
                            result = r.Create(newItem);
                        }
                        else
                        {
                            results.Add(newItem);
                            throw new Exception("Usuario Existente");
                        }
                    }
                }
            }
            return results;
        }
        public IEnumerable<Usuario> Update(IEnumerable<Usuario> toItems)
        {
            List<Usuario> result = new List<Usuario>();
            using (var r = new Repository<Usuario>())
            {
                {
                    foreach (var toItem in toItems)
                    {
                        if (!r.Update(toItem))
                        {
                            result.Add(toItem);
                        }
                    }
                }
            }
            return result;
        }
        public IEnumerable<Usuario> Delete(IEnumerable<Usuario> toItems)
        {
            List<Usuario> result = new List<Usuario>();
            foreach (var toItem in toItems)
            {
                var tExistente = RetrieveByID(toItem.Id);
                if (tExistente != null)
                {
                    if (tExistente.RowState == EEstadoRowState.D.ToString())
                    {
                        throw new Exception("Usuario Inexistente");
                    }
                    using (var r = new Repository<Usuario>())
                    {
                        tExistente.RowState = EEstadoRowState.D.ToString(); ;
                        if (!r.Update(toItem))
                        {
                            result.Add(toItem);
                        }
                    }
                }
                else
                {
                    throw new Exception("Usuario Inexistente");
                }
            }
            return result;
        }
        public bool ValidaRolconAccion(int rolid, string controller)
        {
            
                int nroRegistros =  new CNPC_DuctosEntities().usp_ValidaRolconAccion(rolid, controller);
                return nroRegistros > 0;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
