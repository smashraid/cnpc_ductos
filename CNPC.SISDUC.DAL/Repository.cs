using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Entity.Core.EntityClient;

namespace CNPC.SISDUC.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        CNPC_DuctosEntities Context = null;
        public Repository()
        {
            EntityConnectionStringBuilder csb = new EntityConnectionStringBuilder();
            csb.Metadata = "res://*/DuctosDBModel.csdl|res://*/DuctosDBModel.ssdl|res://*/DuctosDBModel.msl";
            csb.Provider = "System.Data.SqlClient";
            csb.ProviderConnectionString = ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString;
            String entityConnStr = csb.ToString();
            Context = new CNPC_DuctosEntities(entityConnStr);
        }
        public DbSet<TEntity> EntitySet
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }
        public TEntity Create(TEntity toCreate)
        {
            TEntity Result = null;
            try
            {
                EntitySet.Add(toCreate);
                Context.SaveChanges();
                Result = toCreate;
            }
            catch (Exception ex)
            {
                string error = "Error: " + ex.InnerException;
                throw (new Exception(error));
            }
            return Result;
        }
        public bool Delete(TEntity toDelete)
        {
            bool Result = false;
            try
            {
                EntitySet.Attach(toDelete);
                EntitySet.Remove(toDelete);
                Result = Context.SaveChanges() > 0;
            }
            catch
            {
            }
            return Result;
        }
        public bool Update(TEntity toUpdate)
        {
            bool Result = false;
            try
            {

                EntitySet.Attach(toUpdate);
                Context.Entry<TEntity>(toUpdate).State = EntityState.Modified;
                Result = Context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Result = false;
            }
            return Result;
        }
        public TEntity Retrieve(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria)
        {
            TEntity Result = null;
            try
            {
                Result = EntitySet.FirstOrDefault(criteria);
            }
            catch
            {

            }
            return Result;
        }
        public List<TEntity> Filter(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria)
        {
            List<TEntity> Result = null;
            try
            {
                Result = EntitySet.Where(criteria).ToList();
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
            return Result;
        }
        public List<Oleoducto> GetListOleoductosByNombre(string Nombre)
        {
            List<Oleoducto> ductos = new List<Oleoducto>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspGetListOleoductosByNombre", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;

                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Oleoducto d = new Oleoducto();
                        d.Id = reader.SafeGetInt32("Id", 0);
                        d.Cliente = reader.SafeGetString("Cliente", "");
                        d.Codigo = reader.SafeGetString("Codigo", "");
                        d.Descripcion = reader.SafeGetString("Descripcion", "");
                        d.Ubicacion = reader.SafeGetString("Ubicacion", "");
                        d.NoLamina = reader.SafeGetString("NoLamina", "");
                        d.FechaInspeccion = reader.SafeGetDateTime("FechaInspeccion", new DateTime(1950, 01, 01));
                        d.Presion = reader.SafeGetDecimal("Presion", 0);
                        d.Temperatura = reader.SafeGetDecimal("Temperatura", 0);
                        d.BLPD = reader.SafeGetInt32("BLPD", 0);
                        d.Schedule1 = reader.SafeGetInt32("Schedule1", 0);
                        d.Schedule2 = reader.SafeGetInt32("Schedule2", 0);
                        d.Schedule3 = reader.SafeGetInt32("Schedule3", 0);
                        d.Material1 = reader.SafeGetString("Material1", "");
                        d.Material2 = reader.SafeGetString("Material2", "");
                        d.Material3 = reader.SafeGetString("Material3", "");
                        d.LongitudTotal = reader.SafeGetDecimal("LongitudTotal", 0);
                        d.BSW = reader.SafeGetString("BSW", "");
                        d.RowState = reader.SafeGetString("RowState", "");
                        d.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                        ductos.Add(d);
                    }
                    cnn.Close();
                }
                //using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
                //{

                //    SqlCommand cmd = new SqlCommand("uspGetCountOleoductos", cnn);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                //    cnn.Open();
                //    SqlDataReader reader = cmd.ExecuteReader();

                //    cnn.Close();
                //}
            }
            catch (Exception ex)
            {
                throw (new Exception("Error: " + ex.Message));
            }

            return ductos;
        }
        public OleoductoResponse FilterByNameOleoducto(string Nombre, int page, int records)
        {
            OleoductoResponse ductos = new OleoductoResponse();
            ductos.List = new List<Oleoducto>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("uspGetListOleoductos", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                    cmd.Parameters.Add("@Records", SqlDbType.Int).Value = records;
                    cmd.Parameters.Add("@Page", SqlDbType.Int).Value = page;
                    cmd.Parameters.Add("@TotalPage", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Oleoducto d = new Oleoducto();
                        d.Id = reader.SafeGetInt32("Id", 0);
                        d.Cliente = reader.SafeGetString("Cliente", "");
                        d.Codigo = reader.SafeGetString("Codigo", "");
                        d.Descripcion = reader.SafeGetString("Descripcion", "");
                        d.Ubicacion = reader.SafeGetString("Ubicacion", "");
                        d.NoLamina = reader.SafeGetString("NoLamina", "");
                        d.FechaInspeccion = reader.SafeGetDateTime("FechaInspeccion", new DateTime(1950, 01, 01));
                        d.Presion = reader.SafeGetDecimal("Presion", 0);
                        d.Temperatura = reader.SafeGetDecimal("Temperatura", 0);
                        d.BLPD = reader.SafeGetInt32("BLPD", 0);
                        d.Schedule1 = reader.SafeGetInt32("Schedule1", 0);
                        d.Schedule2 = reader.SafeGetInt32("Schedule2", 0);
                        d.Schedule3 = reader.SafeGetInt32("Schedule3", 0);
                        d.Material1 = reader.SafeGetString("Material1", "");
                        d.Material2 = reader.SafeGetString("Material2", "");
                        d.Material3 = reader.SafeGetString("Material3", "");
                        d.LongitudTotal = reader.SafeGetDecimal("LongitudTotal", 0);
                        d.BSW = reader.SafeGetString("BSW", "");
                        d.RowState = reader.SafeGetString("RowState", "");
                        d.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                        ductos.List.Add(d);
                    }
                    ductos.Page = page;
                    ductos.Records = records;
                    cnn.Close();
                }
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand("uspGetCountOleoductos", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                    cmd.Parameters.Add("@Records", SqlDbType.Int).Value = records;
                    cmd.Parameters.Add("@Page", SqlDbType.Int).Value = page;

                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ductos.TotalPages = reader.SafeGetInt32("TotalPage", 0);
                        ductos.TotalRecords = reader.SafeGetInt32("TotalRecords", 0);
                    }
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                ductos.Resultado = false;
                ductos.MensajeError = "Capa BLL: " + ex.Message;
            }

            return ductos;
        }
        public RegistroInspeccionVisualResponse FilterByNameRegistroInspeccionVisual(int OleoductoID, string Nombre, int page, int records)
        {
            RegistroInspeccionVisualResponse registros = new RegistroInspeccionVisualResponse();
            registros.List = new List<RegistroInspeccionVisual>();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("uspGetListRegistroInspeccionVisual", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OleoductoID", SqlDbType.Int).Value = OleoductoID;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                cmd.Parameters.Add("@Records", SqlDbType.Int).Value = records;
                cmd.Parameters.Add("@Page", SqlDbType.Int).Value = page;
                cmd.Parameters.Add("@TotalPage", SqlDbType.Int).Direction = ParameterDirection.Output;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RegistroInspeccionVisual d = new RegistroInspeccionVisual();
                    d.Id = reader.SafeGetInt32("Id", 0);
                    d.OleoductoID = reader.SafeGetInt32("OleoductoID", 0);
                    d.CodigoDelTubo = reader.SafeGetString("CodigoDelTubo", "");
                    d.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    d.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "00000");
                    d.CodigoDelTubo02 = reader.SafeGetString("CodigoDelTubo02", "0");
                    d.CodigoDelTubo03 = reader.SafeGetString("CodigoDelTubo03", "0000");
                    d.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    d.NPS = reader.SafeGetDecimal("NPS", 0);
                    d.Schedule = reader.SafeGetInt32("Schedule", 0);
                    d.SHC = reader.SafeGetInt32("SHC", 0);
                    d.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    d.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    d.CoordenadasUTM_X = reader.SafeGetString("CoordenadasUTM_X", "");
                    d.CoordenadasUTM_Y = reader.SafeGetString("CoordenadasUTM_Y", "");
                    d.ExtremoInicial1 = reader.SafeGetDecimal("ExtremoInicial1", 0);
                    d.ExtremoInicial2 = reader.SafeGetDecimal("ExtremoInicial2", 0);
                    d.ExtremoInicial3 = reader.SafeGetDecimal("ExtremoInicial3", 0);
                    d.ExtremoInicial4 = reader.SafeGetDecimal("ExtremoInicial4", 0);
                    d.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    d.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    d.ExtremoMedio1 = reader.SafeGetDecimal("ExtremoMedio1", 0);
                    d.ExtremoMedio2 = reader.SafeGetDecimal("ExtremoMedio2", 0);
                    d.ExtremoMedio3 = reader.SafeGetDecimal("ExtremoMedio3", 0);
                    d.ExtremoMedio4 = reader.SafeGetDecimal("ExtremoMedio4", 0);
                    d.MapeoCorrison = reader.SafeGetDecimal("MapeoCorrison", 0);
                    d.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    d.ExtremoFinal1 = reader.SafeGetDecimal("ExtremoFinal1", 0);
                    d.ExtremoFinal2 = reader.SafeGetDecimal("ExtremoFinal2", 0);
                    d.ExtremoFinal3 = reader.SafeGetDecimal("ExtremoFinal3", 0);
                    d.ExtremoFinal4 = reader.SafeGetDecimal("ExtremoFinal4", 0);
                    d.LEFT_MINIMO = reader.SafeGetDecimal("LEFT_MINIMO", 0);
                    d.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    d.EspesorNominal = reader.SafeGetDecimal("EspesorNominal", 0);
                    d.EspesorMinimoRealRemanente = reader.SafeGetDecimal("EspesorMinimoRealRemanente", 0);
                    d.ObservacionesDeLaInspeccionVisual = reader.SafeGetString("Defecto", "");
                    d.Defecto2 = reader.SafeGetBoolean("Defecto2", true);
                    d.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
                    d.TipoSoporte = reader.SafeGetString("TipoSoporte", "");
                    d.Elastomero = reader.SafeGetBoolean("Elastomero", false);
                    d.Maleza = reader.SafeGetBoolean("Maleza", false);
                    d.TuberiaAlrededor = reader.SafeGetBoolean("TuberiaAlrededor", false);
                    d.Pintura = reader.SafeGetBoolean("Pintura", false);
                    d.CruceCarretera = reader.SafeGetBoolean("CruceCarretera", false);
                    d.TipoProteccion = reader.SafeGetString("TipoProteccion", "");
                    d.EstadoProteccion = reader.SafeGetString("EstadoProteccion", "");
                    d.EstadoTuberia = reader.SafeGetString("EstadoTuberia", "");
                    d.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 01, 01));
                    d.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);
                    d.CondicionDelTramo = reader.SafeGetString("CondicionDelTramo", "");
                    d.RowState = reader.SafeGetString("RowState", "");
                    d.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 1, 1));
                    registros.List.Add(d);
                }
                registros.Page = page;
                registros.Records = records;
                cnn.Close();
            }
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("uspGetCountRegistroInspeccionVisual", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                cmd.Parameters.Add("@Records", SqlDbType.Int).Value = records;
                cmd.Parameters.Add("@Page", SqlDbType.Int).Value = page;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    registros.TotalPages = reader.SafeGetInt32("TotalPage", 0);
                    registros.TotalRecords = reader.SafeGetInt32("TotalRecords", 0);
                }
                cnn.Close();
            }
            return registros;
        }
        public AccesorioResponse FilterByNameAccesorio(int TuberiaId, string Nombre, int page, int records)
        {
            AccesorioResponse ductos = new AccesorioResponse();
            ductos.List = new List<Accesorio>();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("uspGetListOleoductos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TuberiaId", SqlDbType.Int).Value = TuberiaId;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                cmd.Parameters.Add("@Records", SqlDbType.Int).Value = records;
                cmd.Parameters.Add("@Page", SqlDbType.Int).Value = page;
                cmd.Parameters.Add("@TotalPage", SqlDbType.Int).Direction = ParameterDirection.Output;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Accesorio d = new Accesorio();
                    d.Id = reader.SafeGetInt32("Id", 0);
                    d.CodigoTuberia = reader.SafeGetString("CodigoTuberia", "");
                    d.NombreAccesorio = reader.SafeGetString("NombreAccesorio", "");
                    d.Correlativo = reader.SafeGetString("Correlativo", "");
                    d.CodigoAccesorio = reader.SafeGetString("CodigoAccesorio", "");
                    d.NPS = reader.SafeGetInt32("NPS", 0);
                    d.Schedule = reader.SafeGetInt32("Schedule", 0);
                    d.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    d.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    d.CoordenadasUTMX = reader.SafeGetInt32("CoordenadasUTMX", 0);
                    d.CoordenadasUTMY = reader.SafeGetInt32("CoordenadasUTMY", 0);
                    d.Observaciones = reader.SafeGetString("Observaciones", "");
                    d.CondicionAccesorio = reader.SafeGetString("CondicionAccesorio", "");
                    d.RowState = reader.SafeGetString("RowState", "");
                    d.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    ductos.List.Add(d);
                }
                ductos.Page = page;
                ductos.Records = records;
                cnn.Close();
            }
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("uspGetCountAccesorios", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TuberiaId", SqlDbType.Int).Value = TuberiaId;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                cmd.Parameters.Add("@Records", SqlDbType.Int).Value = records;
                cmd.Parameters.Add("@Page", SqlDbType.Int).Value = page;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ductos.TotalPages = reader.SafeGetInt32("TotalPage", 0);
                    ductos.TotalRecords = reader.SafeGetInt32("TotalRecords", 0);
                }
                cnn.Close();
            }
            return ductos;
        }
        public CambiosTuberiaResponse FilterByMotivoCambiosTuberia(int TuberiaId, string Nombre, int page, int records)
        {
            CambiosTuberiaResponse ductos = new CambiosTuberiaResponse();
            ductos.List = new List<CambiosTuberia>();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("uspGetListCambiosTuberia", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumeroOleoducto", SqlDbType.VarChar).Value = Nombre;
                cmd.Parameters.Add("@TuberiaId", SqlDbType.Int).Value = TuberiaId;
                cmd.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = Nombre;
                cmd.Parameters.Add("@Records", SqlDbType.Int).Value = records;
                cmd.Parameters.Add("@Page", SqlDbType.Int).Value = page;
                cmd.Parameters.Add("@TotalPage", SqlDbType.Int).Direction = ParameterDirection.Output;
                cnn.Open();

                cmd.ExecuteNonQuery();
                ductos.TotalPages = Int32.Parse(cmd.Parameters["@TotalPage"].Value.ToString());

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CambiosTuberia d = new CambiosTuberia();
                    d.Id = reader.SafeGetInt32("Id", 0);
                    d.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                    d.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    d.Motivo = reader.SafeGetString("Motivo", "");
                    d.OrdenServicio = reader.SafeGetString("OrdenServicio", "");
                    d.RowState = reader.SafeGetString("RowState", "");
                    d.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    ductos.List.Add(d);
                }
                ductos.Page = page;
                ductos.Records = records;

                cnn.Close();
            }
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("uspGetCountCambiosTuberia", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TuberiaId", SqlDbType.Int).Value = TuberiaId;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                cmd.Parameters.Add("@Records", SqlDbType.Int).Value = records;

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ductos.TotalPages = reader.SafeGetInt32("TotalPage", 0);
                    ductos.TotalRecords = reader.SafeGetInt32("TotalRecords", 0);
                }
                cnn.Close();
            }
            return ductos;
        }
        public decimal LongitudOleoducto(int Id)
        {
            decimal result = 0;

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("uspGetLongitudOleoducto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.SafeGetDecimal("LongitudTotal", 0);
                }
                cnn.Close();

            }
            return result;
        }
        public Usuario usp_ValidarUsuario(string Usuario = "", string Contrasenia = "", bool ActiveDirectory = false)
        {
            Usuario result = new Usuario();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_ValidarUsuario", cnn);
                if (Usuario == null || Contrasenia == null)
                {
                    throw (new Exception("Error: Usuario o Contraseña no válidos"));
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = Usuario;
                cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 100).Value = Contrasenia;//SHA1.Encode(Contrasenia);
                cmd.Parameters.Add("@ActiveDirectory", SqlDbType.Bit).Value = ActiveDirectory;
                try
                {
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Id = reader.SafeGetInt32("Id", 0);
                        result.Usuario1 = reader.SafeGetString("Usuario", "");
                        result.Contrasenia = reader.SafeGetString("Contrasenia", "");
                        result.Nombre = reader.SafeGetString("Nombre", "");
                        result.Apellido = reader.SafeGetString("Apellido", "");
                        result.Activo = reader.SafeGetBoolean("Activo", false);
                        result.ActiveDirectory = reader.SafeGetBoolean("ActiveDirectory", false);
                        result.RolId = reader.SafeGetInt32("RolId", 0);
                        result.FacilitadorId = reader.SafeGetInt32("FacilitadorId", 0);
                        result.FiscalizadorId = reader.SafeGetInt32("FiscalizadorId", 0);
                        result.RowState = reader.SafeGetString("RowState", "");
                        result.LastUpdate = reader.SafeGetDateTime("LastUpdate", new DateTime(1950, 01, 01));
                    }
                    if (result.Activo == false)
                    {
                        throw (new Exception("Error: Usuario o Contraseña no válidos"));
                    }
                }
                catch (Exception ex)
                {
                    //result = ValoresPrueba(result);
                    result = null;
                    throw (new Exception("Error: " + ex.Message));
                }

            }
            return result;
        }
        public Usuario usp_CreateUsuario(Usuario registro)
        {
            Usuario result = new Usuario();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_CreateUsuario", cnn);
                if (registro.Usuario1 == null || registro.Contrasenia == null)
                {
                    throw (new Exception("Error: Usuario o Contraseña no válidos"));
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = registro.Usuario1;
                cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 100).Value = SHA1.Encode(registro.Contrasenia);
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = registro.Nombre;
                cmd.Parameters.Add("@Apellido", SqlDbType.VarChar, 100).Value = registro.Apellido;
                cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = registro.Activo;
                cmd.Parameters.Add("@ActiveDirectory", SqlDbType.Bit).Value = registro.ActiveDirectory;
                cmd.Parameters.Add("@RolId", SqlDbType.Int).Value = registro.RolId;
                try
                {
                    cnn.Open();
                    int reg = cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    //result = ValoresPrueba(result);
                    result = null;
                    throw (new Exception("Error: " + ex.Message));
                }

            }
            return result;
        }
        public Usuario ValoresPrueba(Usuario result)
        {
            result.Id = 1;
            result.Usuario1 = "jliza";
            result.Contrasenia = "123";
            result.Nombre = "Jose Hernan";
            result.Apellido = "Liza Garavito";
            result.Activo = true;
            result.ActiveDirectory = false;
            result.RolId = 1;
            result.FacilitadorId = 0;
            result.FiscalizadorId = 0;
            result.RowState = "A";
            result.LastUpdate = new DateTime(1950, 01, 01);
            return result;
        }
        public TipoSoporteResponse usp_GetListTipoSoporte()
        {
            TipoSoporteResponse registros = new TipoSoporteResponse();
            registros.List = new List<TipoSoporte>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_GetListTipoSoporte", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoSoporte d = new TipoSoporte();
                        d.Valor = reader.SafeGetString("Valor", "");
                        d.Nombre = reader.SafeGetString("Nombre", "");
                        registros.List.Add(d);
                    }
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                registros.Resultado = false;
                registros.MensajeError = "Capa BLL: " + ex.Message;
            }

            return registros;
        }
        public CambiosTuberiaResponse usp_GetListCambiosTuberia(string NumeroOleoducto, int TuberiaID, int records, int page)
        {
            CambiosTuberiaResponse registros = new CambiosTuberiaResponse();
            registros.List = new List<CambiosTuberia>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_GetListTipoSoporte", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();

                    cmd.ExecuteNonQuery();
                    registros.TotalPages = Int32.Parse(cmd.Parameters["@TotalPage"].Value.ToString());

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CambiosTuberia d = new CambiosTuberia();
                        d.Id = reader.SafeGetInt32("Id", 0);
                        d.NumeroOleoducto = reader.SafeGetString("NumeroOleoducto", "");
                        d.CodigoDelTubo01 = reader.SafeGetString("CodigoDelTubo01", "");
                        d.Motivo = reader.SafeGetString("Motivo", "");
                        d.OrdenServicio = reader.SafeGetString("OrdenServicio", "");
                        d.FechaOrdenServicio = reader.SafeGetDateTime("FechaOrdenservicio", new DateTime(1950, 01, 01));
                        registros.List.Add(d);
                    }
                    registros.Page = page;
                    registros.Records = records;

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                registros.Resultado = false;
                registros.MensajeError = "Capa DAL: " + ex.Message;
            }

            return registros;
        }
        public bool usp_ActualizarRegistroDeInspeccionVisual(RegistroInspeccionVisual reg)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_ActualizarRegistroDeInspeccionVisual", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                result = false;
               
            }
            return result;
        }
        public CambiosTuberiaResponse usp_NewCambiosTuberia(CambiosTuberia registro)
        {
            CambiosTuberiaResponse Result = new CambiosTuberiaResponse();
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_NewCambiosTuberia", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumeroOleoducto", registro.NumeroOleoducto);
                    cmd.Parameters.AddWithValue("@CodigoDelTubo01", registro.CodigoDelTubo01);
                    cmd.Parameters.AddWithValue("@CodigoDelTuboReemplazado", registro.CodigoDelTuboReemplazado);
                    cmd.Parameters.AddWithValue("@TuberiaId", registro.TuberiaId);
                    cmd.Parameters.AddWithValue("@Motivo", registro.Motivo);
                    cmd.Parameters.AddWithValue("@OrdenServicio", registro.OrdenServicio);
                    cmd.Parameters.AddWithValue("@FechaOrdenServicio", registro.FechaOrdenServicio == null ? DateTime.Now : registro.FechaOrdenServicio);
                    cmd.Parameters.AddWithValue("@RowState", registro.RowState);
                    cmd.Parameters.AddWithValue("@LastUpdate", registro.LastUpdate);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    Result.Item = registro;
                    Result.Resultado = true;

                }
            }
            catch (Exception ex)
            {
                Result.Resultado = false;
                Result.MensajeError = "Capa DAL: " + ex.Message;
            }

            return Result;
        }
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
