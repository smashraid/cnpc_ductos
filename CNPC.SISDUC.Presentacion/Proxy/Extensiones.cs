using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPC.SISDUC.Presentacion.Proxy
{
    public static class UsuarioAssembler
    {
        public static UsuarioViewModel ConvertToViewModel(this Usuario request)
        {
            var resultado = new UsuarioViewModel
            {
                Id = request.Id,
                Usuario1 = request.Usuario1,
                Activo = request.Activo ,
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
               Id= model.Id,
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
        public static OleoductoViewModel ConvertToViewModel(this Oleoducto request)
        {
            var resultado = new OleoductoViewModel
            {
                Id = request.Id,
                Cliente = request.Cliente,
                Descripcion = request.Descripcion,
                NoLamina = request.NoLamina,
                Ubicacion = request.Ubicacion,
                Material1 = request.Material1,
                Material2 = request.Material2,
                Material3 = request.Material3,
                Schedule1 = request.Schedule1,
                Schedule2 = request.Schedule2,
                Schedule3 = request.Schedule3,
                BLPD = request.BLPD,
                Presion = request.Presion,
                Temperatura = request.Temperatura,
                BSW = request.BSW,
                FechaInspeccion = request.FechaInspeccion,
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
}