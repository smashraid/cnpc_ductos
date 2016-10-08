using System;
using CNPC.SISDUC.Model.Servicio;
using CNPC.SISDUC.BLL;
using CNPC.SISDUC.Model;
using System.Linq;
using CNPC.SISDUC.DAL;

namespace CNPC.SISDUC.SERVICIO.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Servicio : IServicio
    {
        //Servicio para Oleoductos
        public OleoductoResponse OleoductoEjecutarOperacion(OleoductoRequest request)
        {
            var response = new OleoductoResponse { Item = request.Item };
            try
            {
                using (var dominio = new Oleoductos())
                {
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {
                                response.Item = dominio.Create(request.Item);
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Update(request.Item);
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Delete(request.Item.Id);
                            }

                            break;
                        case Operacion.BuscarPorId:
                            {
                                response.Item = dominio.FilterByID(request.Item.Id);
                                if (response.Item != null)
                                {
                                    response.Resultado = true;
                                }
                                else
                                {
                                    response.Resultado = false;
                                }
                            }
                            break;
                    }
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;// + " "+ ex.InnerException + " " + ex.StackTrace;;
            }

            return response;
        }
        public OleoductoResponse OleoductoEnviarActualizaciones(OleoductoListaRequest request)
        {
            throw new NotImplementedException();
        }
        public OleoductoResponse OleoductoListarAllEntidad(string nombre)
        {
            OleoductoResponse response = new OleoductoResponse();
            try
            {
                using (var dominio = new Oleoductos())
                {
                    response.List = dominio.GetListOleoductosByNombre("");
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError += "Error: " + ex.Message + " " + ex.InnerException;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        public OleoductoResponse OleoductoListarEntidad(string search = null, int page = 1, int rowsPerPage = 10)
        {
            OleoductoResponse response = null;
            try
            {
                using (var dominio = new Oleoductos())
                {
                    response = dominio.FilterByName(search, page, rowsPerPage);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError += "Error: " + ex.Message + " " + ex.InnerException;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }

        //Servicio para RegistroInspeccionVisual
        public RegistroInspeccionVisualResponse RegistroInspeccionVisualEjecutarOperacion(RegistroInspeccionVisualRequest request)
        {
            RegistroInspeccionVisualResponse response = new RegistroInspeccionVisualResponse();
            try
            {
                using (var dominio = new RegistroInspeccionVisuales())
                {
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {
                                response.Item = dominio.Create(request.Item);
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Update(request.Item);
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Delete(request.Item.Id);
                            }
                            break;
                        case Operacion.BuscarPorId:
                            {
                                response.Item = dominio.FilterByID(request.Item.Id);
                                if (response.Item != null)
                                {
                                    response.Resultado = true;
                                }
                                else
                                {
                                    response.Resultado = false;
                                }
                            }
                            break;
                    }
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;// + " "+ ex.InnerException + " " + ex.StackTrace;;
            }

            return response;
        }
        public RegistroInspeccionVisualResponse RegistroInspeccionVisualListarAllEntidad()
        {
            RegistroInspeccionVisualResponse response = new RegistroInspeccionVisualResponse();
            try
            {
                using (var dominio = new RegistroInspeccionVisuales())
                {
                    response = dominio.FilterByNameRegistroInspeccionVisual(0, "", 1, 10);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        public RegistroInspeccionVisualResponse RegistroInspeccionVisualListarByDucto(int ductoId, string search = null)
        {
            RegistroInspeccionVisualResponse response = new RegistroInspeccionVisualResponse();
            try
            {
                using (var dominio = new RegistroInspeccionVisuales())
                {
                    response = dominio.FilterByDuctoIdRegistroInspeccionVisual(ductoId, search);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        public RegistroInspeccionVisualResponse RegistroInspeccionVisualListarEntidad(int oleoductoId, string search = null, int page = 1, int rowsPerPage = 10)
        {
            RegistroInspeccionVisualResponse response = new RegistroInspeccionVisualResponse();
            try
            {
                using (var dominio = new RegistroInspeccionVisuales())
                {
                    response = dominio.FilterByNameRegistroInspeccionVisual(oleoductoId, search, page, rowsPerPage);
                    response.Resultado = true;
                }
                using (var dominio = new TipoSoportes())
                {
                    response.ListTipoSoporte = dominio.GetListTipoSoporte();
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message + " " + ex.InnerException + " " + ex.StackTrace;
            }
            return response;
        }

        //Servicio para CambiosTuberia
        public CambiosTuberiaResponse CambiosTuberiaEjecutarOperacion(CambiosTuberiaRequest request)
        {
            CambiosTuberiaResponse response = new CambiosTuberiaResponse();
            try
            {
                using (var dominio = new CambiosTuberiaBLL())
                {
                    CambiosTuberia item = request.Item;
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {

                                response = dominio.Create(item);
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Update(item);
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Delete(item.Id);
                            }
                            break;
                    }
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;// + " "+ ex.InnerException + " " + ex.StackTrace;;
            }

            return response;
        }
        public CambiosTuberiaResponse CambiosTuberiaListarAllEntidad()
        {
            CambiosTuberiaResponse response = new CambiosTuberiaResponse();
            try
            {
                using (var dominio = new CambiosTuberiaBLL())
                {
                    response = dominio.GetListCambiosTuberia("", 0, 1, 10);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        public CambiosTuberiaResponse CambiosTuberiaListarEntidad(string oleoducto, int TuberiaId = 0, int page = 1, int rowsPerPage = 10)
        {
            CambiosTuberiaResponse response = new CambiosTuberiaResponse();
            try
            {
                using (var dominio = new CambiosTuberiaBLL())
                {
                    response = dominio.GetListCambiosTuberia(oleoducto, TuberiaId, page, rowsPerPage);
                    response.Resultado = true;
                }

            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message + " " + ex.InnerException + " " + ex.StackTrace;
            }
            return response;
        }

        //Servicio para Accesorios
        public AccesorioResponse AccesoriosEjecutarOperacion(AccesoriosRequest request)
        {
            AccesorioResponse response = new AccesorioResponse();
            try
            {
                using (var dominio = new Accesorios())
                {
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {
                                response.Item = dominio.Create(request.Item);
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Update(request.Item);
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Delete(request.Item.Id);
                            }
                            break;
                    }
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;// + " "+ ex.InnerException + " " + ex.StackTrace;;
            }

            return response;
        }
        public AccesorioResponse AccesoriosListarAllEntidad()
        {
            AccesorioResponse response = new AccesorioResponse();
            try
            {
                using (var dominio = new Accesorios())
                {
                    response = dominio.FilterByNameAccesorio(0, "", 1, 10);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }
        public AccesorioResponse AccesoriosListarEntidad(int oleoductoId, string search = null, int page = 1, int rowsPerPage = 10)
        {
            AccesorioResponse response = new AccesorioResponse();
            try
            {
                using (var dominio = new Accesorios())
                {
                    response = dominio.FilterByNameAccesorio(oleoductoId, search, page, rowsPerPage);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace; 
            }
            return response;
        }

        //Servicio para las Constantes
        public TipoSoporteResponse TipoSoporteListarAllEntidad()
        {
            var response = new TipoSoporteResponse();
            try
            {
                using (var dominio = new TipoSoportes())
                {
                    response = dominio.GetListTipoSoporte();
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message + "\n " + ex.InnerException + " " + ex.StackTrace;
            }
            return response;
        }

        //Servicio para Usuario
        public int ListCountUsuario()
        {
            var result = 0;
            try
            {
                using (var proxy = new UsuarioBLL())
                {
                    result = proxy.ListCount();
                }
            }
            catch (Exception ex)
            {
                //error = ex.Message;
            }
            return result;
        }
        public UsuarioResponse UsuarioEjecutarOperacion(UsuarioRequest request)
        {
            var response = new UsuarioResponse { Item = request.Item };
            try
            {
                using (var dominio = new UsuarioBLL())
                {
                    request.Item.Contrasenia = SHA1.Encode(request.Item.Contrasenia);
                    switch (request.Operacion)
                    {
                        case Operacion.Agregar:
                            {
                                response.Item = dominio.Create(request.Item);
                            }
                            break;
                        case Operacion.Actualizar:
                            {
                                response.Resultado = dominio.Update(request.Item);
                            }
                            break;
                        case Operacion.Eliminar:
                            {
                                response.Resultado = dominio.Delete(request.Item.Id);
                            }
                            break;
                    }
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace;
            }

            return response;
        }
        public UsuarioResponse UsuarioBuscarEntidad(UsuarioRequest request)
        {
            var response = new UsuarioResponse();
            try
            {
                using (var dominio = new UsuarioBLL())
                {
                    response.Item = dominio.RetrieveByID(request.Item.Id);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace;
            }

            return response;
        }
        public UsuarioResponse UsuarioListarAllEntidad(string rowState)
        {
            var response = new UsuarioResponse();
            try
            {
                using (var dominio = new UsuarioBLL())
                {
                    response.List = dominio.List(rowState).ToList();
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace;
            }
            return response;
        }

        public UsuarioResponse ValidaLogin(UsuarioRequest request)
        {
            UsuarioResponse response = new UsuarioResponse();
            try
            {
                response.Item = null;
                response.Resultado = false;
                using (var dominio = new UsuarioBLL())
                {
                    response.Item = dominio.ValidaLogin(request.Item);
                    response.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                response.Resultado = false;
                response.MensajeError = ex.Message;//+ " "+ ex.InnerException + " " + ex.StackTrace;
            }
            return response;
        }
        public bool ValidaRolconAccion(int rolid, string controller)
        {
            var response = false;
            try
            {
                using (var dominio = new UsuarioBLL())
                {
                    response = dominio.ValidaRolconAccion(rolid, controller);

                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public int ListCountUsuario(ref string error)
        {
            throw new NotImplementedException();
        }

    }
}
