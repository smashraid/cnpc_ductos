﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPC.SISDUC.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CNPC_DuctosEntities : DbContext
    {
        public CNPC_DuctosEntities()
            : base("name=CNPC_DuctosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accesorio> Accesorios { get; set; }
        public virtual DbSet<Oleoducto> Oleoductos { get; set; }
        public virtual DbSet<RegistroInspeccionVisual> RegistroInspeccionVisuals { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<CambiosTuberia> CambiosTuberias { get; set; }
    
        public virtual ObjectResult<uspGetListOleoductos_Result> uspGetListOleoductos(string nombre, Nullable<int> page, Nullable<int> records, ObjectParameter totalPage)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var pageParameter = page.HasValue ?
                new ObjectParameter("Page", page) :
                new ObjectParameter("Page", typeof(int));
    
            var recordsParameter = records.HasValue ?
                new ObjectParameter("Records", records) :
                new ObjectParameter("Records", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetListOleoductos_Result>("uspGetListOleoductos", nombreParameter, pageParameter, recordsParameter, totalPage);
        }
    
        public virtual ObjectResult<uspGetCountOleoductos_Result> uspGetCountOleoductos(string nombre, Nullable<int> page, Nullable<int> records)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var pageParameter = page.HasValue ?
                new ObjectParameter("Page", page) :
                new ObjectParameter("Page", typeof(int));
    
            var recordsParameter = records.HasValue ?
                new ObjectParameter("Records", records) :
                new ObjectParameter("Records", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetCountOleoductos_Result>("uspGetCountOleoductos", nombreParameter, pageParameter, recordsParameter);
        }
    
        public virtual ObjectResult<usp_ValidarUsuario_Result> usp_ValidarUsuario(string usuario, string contrasenia, Nullable<bool> activeDirectory)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contraseniaParameter = contrasenia != null ?
                new ObjectParameter("Contrasenia", contrasenia) :
                new ObjectParameter("Contrasenia", typeof(string));
    
            var activeDirectoryParameter = activeDirectory.HasValue ?
                new ObjectParameter("ActiveDirectory", activeDirectory) :
                new ObjectParameter("ActiveDirectory", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_ValidarUsuario_Result>("usp_ValidarUsuario", usuarioParameter, contraseniaParameter, activeDirectoryParameter);
        }
    
        public virtual int usp_ValidaRolconAccion(Nullable<int> rolid, string controller)
        {
            var rolidParameter = rolid.HasValue ?
                new ObjectParameter("rolid", rolid) :
                new ObjectParameter("rolid", typeof(int));
    
            var controllerParameter = controller != null ?
                new ObjectParameter("controller", controller) :
                new ObjectParameter("controller", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_ValidaRolconAccion", rolidParameter, controllerParameter);
        }
    }
}
