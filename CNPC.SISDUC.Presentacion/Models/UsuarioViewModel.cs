using System;

namespace CNPC.SISDUC.Presentacion.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string Ad { get; set; }
        public bool Activo { get; set; }
        public bool ActiveDirectory { get; set; }
        public string RowState { get; set; }
        public DateTime LastUpdate { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public int? FacilitadorId { get; set; }
        public string facilitadorNombre { get; set; }
        public string fiscalizadorNombre { get; set; }
        public int? FiscalizadorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}