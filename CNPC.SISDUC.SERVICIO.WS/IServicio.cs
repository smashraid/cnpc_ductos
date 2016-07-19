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
        OleoductoResponse OleoductoListarAllEntidad();
        [OperationContract]
        OleoductoResponse OleoductoListarEntidad(string search = null, int page = 1, int rowsPerPage = 10);

        //TODO: agregue aquí sus operaciones de servicio
        [OperationContract]
        RegistroInspeccionVisualResponse RegistroInspeccionVisualEjecutarOperacion(RegistroInspeccionVisualRequest request);
        [OperationContract]
        RegistroInspeccionVisualResponse RegistroInspeccionVisualListarAllEntidad();
        [OperationContract]
        RegistroInspeccionVisualResponse RegistroInspeccionVisualListarEntidad(int oleoductoId, string search = null, int page = 1, int rowsPerPage = 10);

        //TODO: agregue aquí sus operaciones de Accesorios
        [OperationContract]
        AccesorioResponse AccesoriosEjecutarOperacion(AccesoriosRequest request);
        [OperationContract]
        AccesorioResponse AccesoriosListarAllEntidad();
        [OperationContract]
        AccesorioResponse AccesoriosListarEntidad(int oleoductoId, string search = null, int page = 1, int rowsPerPage = 10);

        //TODO: agregue aquí sus operaciones de Usuario
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
