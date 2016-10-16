using CNPC.SISDUC.Model.Servicio;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CNPC.SISDUC.SERVICIO.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicio
    {
        //Oleoducto
        [OperationContract]
        OleoductoResponse OleoductoEjecutarOperacion(OleoductoRequest request);
        [OperationContract]
        OleoductoResponse OleoductoEnviarActualizaciones(OleoductoListaRequest request);
        [OperationContract]
        OleoductoResponse OleoductoListarEntidad(string search = null, int page = 1, int rowsPerPage = 10);
        [OperationContract]
        OleoductoResponse OleoductoListarAllEntidad(string nombre);

        //Registro de Inspeccion Visual
        [OperationContract]
        RegistroInspeccionVisualResponse RegistroInspeccionVisualEjecutarOperacion(RegistroInspeccionVisualRequest request);
        [OperationContract]
        RegistroInspeccionVisualResponse RegistroInspeccionVisualListarAllEntidad();
        [OperationContract]
        RegistroInspeccionVisualResponse RegistroInspeccionVisualListarEntidad(int oleoductoId, string search = null, int page = 1, int rowsPerPage = 10);
        [OperationContract]
        RegistroInspeccionVisualResponse RegistroInspeccionVisualListarByDucto(int ductoId, string search = null, string Estado = null);

        //Registro de Cambios Tubería
        [OperationContract]
        CambiosTuberiaResponse CambiosTuberiaEjecutarOperacion(CambiosTuberiaRequest request);
        [OperationContract]
        CambiosTuberiaResponse CambiosTuberiaListarAllEntidad();
        [OperationContract]
        CambiosTuberiaResponse CambiosTuberiaListarEntidad(string oleoducto, int TuberiaId = 0, int page = 1, int rowsPerPage = 10);

        //Accesorios
        [OperationContract]
        AccesorioResponse AccesoriosEjecutarOperacion(AccesoriosRequest request);
        [OperationContract]
        AccesorioResponse AccesoriosListarAllEntidad();
        [OperationContract]
        AccesorioResponse AccesoriosListarEntidad(int oleoductoId, string search = null, int page = 1, int rowsPerPage = 10);
        [OperationContract]
        AccesorioResponse AccesoriosListarByTuberia(string IdTuberia, string search = null);
        //Servicio para las Constantes
        [OperationContract]
        TipoSoporteResponse TipoSoporteListarAllEntidad();

        //Ooperaciones de Usuario
        [OperationContract]
        int ListCountUsuario(ref string error);
        [OperationContract]
        UsuarioResponse UsuarioEjecutarOperacion(UsuarioRequest request);
        [OperationContract]
        UsuarioResponse UsuarioBuscarEntidad(UsuarioRequest request);
        [OperationContract]
        UsuarioResponse UsuarioListarAllEntidad(string rowState);
        [OperationContract]
        UsuarioResponse ValidaLogin(UsuarioRequest request);
        [OperationContract]
        bool ValidaRolconAccion(int rolid, string controller);

    }
}
