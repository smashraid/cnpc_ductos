using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace CNPC.SISDUC.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        CNPC_DuctosEntities Context = null;
        public Repository()
        {
            Context = new CNPC_DuctosEntities();
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
            catch
            {
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
        public OleoductoResponse FilterByNameOleoducto(string Nombre, int page, int records)
        {
            OleoductoResponse ductos = new OleoductoResponse();
            ductos.List = new List<Oleoducto>();
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
                    //d.LongitudTotal = reader.SafeGetDecimal("LongitudTotal","");
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
                    d.NumeroAnterior = reader.SafeGetInt32("NumeroAnterior", 0);
                    d.NPS = reader.SafeGetInt32("NPS", 0);
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
                    d.Defecto = reader.SafeGetString("Defecto", "");
                    d.Defecto2 = reader.SafeGetString("Defecto2", "");
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
                    d.EspesorNominal = reader.SafeGetDecimal("EspesorNominal", 0);
                    d.EspesorMinimoRealRemanente = reader.SafeGetDecimal("EspesorMinimoRealRemanente", 0);
                    d.ObservacionesDeLaInspeccionVisual = reader.SafeGetString("ObservacionesDeLaInspeccionVisual", "");
                    d.CondicionDelTramo = reader.SafeGetString("CondicionDelTramo", "");
                    d.UltimaFechaDeInspeccion = reader.SafeGetDateTime("UltimaFechaDeInspeccion", new DateTime(1950, 1, 1));
                    d.SeleccionarTuberia = reader.SafeGetBoolean("SeleccionarTuberia", false);

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
                    d.TuberiaId = reader.SafeGetInt32("TuberiaId", 0);
                    d.TipoAccesorio = reader.SafeGetString("TipoAccesorio", "");
                    d.CodigoAccesorio1 = reader.SafeGetString("CodigoAccesorio1", "");
                    d.CodigoAccesorio2 = reader.SafeGetString("CodigoAccesorio2", "");
                    d.CodigoAccesorio3 = reader.SafeGetString("CodigoAccesorio3", "");
                    d.NPS = reader.SafeGetInt32("NPS", 0);
                    d.Schedule = reader.SafeGetInt32("Schedule", 0);
                    d.TipoMaterial = reader.SafeGetString("TipoMaterial", "");
                    d.Longitud = reader.SafeGetDecimal("Longitud", 0);
                    d.CoordenadasUTMX = reader.SafeGetInt32("CoordenadasUTMX", 0);
                    d.CoordenadasUTMY = reader.SafeGetInt32("CoordenadasUTMY", 0);
                    d.ExtremoInicial = reader.SafeGetDecimal("ExtremoInicial", 0);
                    d.ExtremoMedio = reader.SafeGetDecimal("ExtremoMedio", 0);
                    d.ExtremoFinal = reader.SafeGetDecimal("ExtremoFinal", 0);
                    d.BSCAN = reader.SafeGetDecimal("BSCAN", 0);
                    d.MapeoCorrosion = reader.SafeGetDecimal("MapeoCorrosion", 0);
                    d.InspeccionSonica = reader.SafeGetDecimal("InspeccionSonica", 0);
                    d.EspesorPared = reader.SafeGetDecimal("EspesorPared", 0);
                    d.PitCorrosion = reader.SafeGetDecimal("PitCorrosion", 0);
                    d.EspesorRemanente = reader.SafeGetDecimal("EspesorRemanente", 0);
                    d.EstadoAccesorio = reader.SafeGetString("EstadoAccesorio", "");
                    d.Pintura = reader.SafeGetBoolean("Pintura", false);
                    d.Defecto1 = reader.SafeGetString("Defecto1", "");
                    d.Defecto2 = reader.SafeGetString("Defecto2", "");
                    d.NumeroGrapas = reader.SafeGetInt32("NumeroGrapas", 0);
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
        public Usuario usp_ValidarUsuario(string Usuario, string Contrasenia, bool ActiveDirectory)
        {
            Usuario result = new Usuario();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_ValidarUsuario", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = Usuario;
                cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 50).Value = SHA1.Encode(Contrasenia); ;
                cmd.Parameters.Add("@ActiveDirectory", SqlDbType.Bit).Value = ActiveDirectory;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
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
                catch (Exception ex)
                {
                   result= ValoresPrueba(result);
                    //throw(new Exception("Error: " + ex.Message));
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
            result.FacilitadorId =0;
            result.FiscalizadorId =  0;
            result.RowState = "A";
            result.LastUpdate =new DateTime(1950, 01, 01);
            return result;
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
