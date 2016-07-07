using CNPC.SISDUC.Model;
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
                    d.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    d.Cliente = reader.GetString(reader.GetOrdinal("Cliente"));
                    d.Codigo = reader.GetString(reader.GetOrdinal("Codigo"));
                    d.Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
                    d.Ubicacion = reader.GetString(reader.GetOrdinal("Ubicacion"));
                    d.NoLamina = reader.GetString(reader.GetOrdinal("NoLamina"));
                    d.FechaInspeccion = reader.GetDateTime(reader.GetOrdinal("FechaInspeccion"));
                    d.Presion = reader.GetDecimal(reader.GetOrdinal("Presion"));
                    d.Temperatura = reader.GetDecimal(reader.GetOrdinal("Temperatura"));
                    d.BLPD = reader.GetInt32(reader.GetOrdinal("BLPD"));
                    d.Schedule1 = reader.GetInt32(reader.GetOrdinal("Schedule1"));
                    d.Schedule2 = reader.GetInt32(reader.GetOrdinal("Schedule2"));
                    d.Schedule3 = reader.GetInt32(reader.GetOrdinal("Schedule3"));
                    d.Material1 = reader.GetString(reader.GetOrdinal("Material1"));
                    d.Material2 = reader.GetString(reader.GetOrdinal("Material2"));
                    d.Material3 = reader.GetString(reader.GetOrdinal("Material3"));
                    //d.LongitudTotal = reader.GetDecimal(reader.GetOrdinal("LongitudTotal"));
                    d.BSW = reader.GetString(reader.GetOrdinal("BSW"));
                    d.RowState = reader.GetString(reader.GetOrdinal("RowState"));
                    d.LastUpdate = reader.GetDateTime(reader.GetOrdinal("LastUpdate"));
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
                    ductos.TotalPages = reader.GetInt32(reader.GetOrdinal("TotalPage"));
                    ductos.TotalRecords = reader.GetInt32(reader.GetOrdinal("TotalRecords"));
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
                    d.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    d.OleoductoID = reader.GetInt32(reader.GetOrdinal("OleoductoID"));
                    d.CodigoDelTubo = reader.GetString(reader.GetOrdinal("CodigoDelTubo"));
                    d.NumeroAnterior = reader.GetInt32(reader.GetOrdinal("NumeroAnterior"));
                    d.NPS = reader.GetInt32(reader.GetOrdinal("NPS"));
                    d.Schedule = reader.GetInt32(reader.GetOrdinal("Schedule"));
                    d.TipoMaterial = reader.GetString(reader.GetOrdinal("TipoMaterial"));
                    d.Longitud = reader.GetDecimal(reader.GetOrdinal("Longitud"));
                    d.EspesorNominal = reader.GetDecimal(reader.GetOrdinal("EspesorNominal"));
                    d.EspesorMinimoRealRemanente = reader.GetDecimal(reader.GetOrdinal("EspesorMinimoRealRemanente"));
                    d.CruceCarretera = reader.GetBoolean(reader.GetOrdinal("CruceCarretera"));
                    d.ObservacionesDeLaInspeccionVisual = reader.GetString(reader.GetOrdinal("ObservacionesDeLaInspeccionVisual"));
                    d.CondicionDelTramo = reader.GetString(reader.GetOrdinal("CondicionDelTramo"));
                    d.UltimaFechaDeInspeccion = reader.GetDateTime(reader.GetOrdinal("UltimaFechaDeInspeccion"));
                    d.SeleccionarTuberia = reader.GetBoolean(reader.GetOrdinal("SeleccionarTuberia"));
                    d.RowState = reader.GetString(reader.GetOrdinal("RowState"));
                    d.LastUpdate = reader.GetDateTime(reader.GetOrdinal("LastUpdate"));
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
                    registros.TotalPages = reader.GetInt32(reader.GetOrdinal("TotalPage"));
                    registros.TotalRecords = reader.GetInt32(reader.GetOrdinal("TotalRecords"));
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
                    d.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    d.TuberiaId = reader.GetInt32(reader.GetOrdinal("TuberiaId"));
                    d.TipoAccesorio = reader.GetString(reader.GetOrdinal("TipoAccesorio"));
                    d.CodigoAccesorio1 = reader.GetString(reader.GetOrdinal("CodigoAccesorio1"));
                    d.CodigoAccesorio2 = reader.GetString(reader.GetOrdinal("CodigoAccesorio2"));
                    d.CodigoAccesorio3 = reader.GetString(reader.GetOrdinal("CodigoAccesorio3"));
                    d.NPS = reader.GetInt32(reader.GetOrdinal("NPS"));
                    d.Schedule = reader.GetInt32(reader.GetOrdinal("Schedule"));
                    d.TipoMaterial = reader.GetString(reader.GetOrdinal("TipoMaterial"));
                    d.Longitud = reader.GetDecimal(reader.GetOrdinal("Longitud"));
                    d.CoordenadasUTMX = reader.GetInt32(reader.GetOrdinal("CoordenadasUTMX"));
                    d.CoordenadasUTMY = reader.GetInt32(reader.GetOrdinal("CoordenadasUTMY"));
                    d.ExtremoInicial = reader.GetDecimal(reader.GetOrdinal("ExtremoInicial"));
                    d.ExtremoMedio = reader.GetDecimal(reader.GetOrdinal("ExtremoMedio"));
                    d.ExtremoFinal = reader.GetDecimal(reader.GetOrdinal("ExtremoFinal"));
                    d.BSCAN = reader.GetDecimal(reader.GetOrdinal("BSCAN"));
                    d.MapeoCorrosion = reader.GetDecimal(reader.GetOrdinal("MapeoCorrosion"));
                    d.InspeccionSonica = reader.GetDecimal(reader.GetOrdinal("InspeccionSonica"));
                    d.EspesorPared = reader.GetDecimal(reader.GetOrdinal("EspesorPared"));
                    d.PitCorrosion = reader.GetDecimal(reader.GetOrdinal("PitCorrosion"));
                    d.EspesorRemanente = reader.GetDecimal(reader.GetOrdinal("EspesorRemanente"));
                    d.EstadoAccesorio = reader.GetString(reader.GetOrdinal("EstadoAccesorio"));
                    d.Pintura = reader.GetBoolean(reader.GetOrdinal("Pintura"));
                    d.Defecto1 = reader.GetString(reader.GetOrdinal("Defecto1"));
                    d.Defecto2 = reader.GetString(reader.GetOrdinal("Defecto2"));
                    d.NumeroGrapas = reader.GetInt32(reader.GetOrdinal("NumeroGrapas"));
                    d.RowState = reader.GetString(reader.GetOrdinal("RowState"));
                    d.LastUpdate = reader.GetDateTime(reader.GetOrdinal("LastUpdate"));
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
                    ductos.TotalPages = reader.GetInt32(reader.GetOrdinal("TotalPage"));
                    ductos.TotalRecords = reader.GetInt32(reader.GetOrdinal("TotalRecords"));
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
                    result = reader.GetDecimal(reader.GetOrdinal("LongitudTotal"));
                }
                cnn.Close();
            
            }
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
