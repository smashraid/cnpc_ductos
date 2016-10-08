namespace CNPC.SISDUC.Web.Models
{
    public partial class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public bool ActiveDirectory { get; set; }
        public int RolId { get; set; }
        public int FiscalizadorId { get; set; }
        public string RowState { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public int FacilitadorId { get; set; }

    }
}