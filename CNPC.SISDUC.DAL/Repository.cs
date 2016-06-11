using CNPC.SISDUC.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch
            {
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
        public DuctoResponse FilterByName(string Nombre, int page, int records)
        {
            DuctoResponse ductos = new DuctoResponse();
            ductos.List = new List<Ducto>();
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
                    Ducto d = new Ducto();
                    d.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    d.Cliente = reader.GetString(reader.GetOrdinal("Cliente"));
                    d.Codigo = reader.GetString(reader.GetOrdinal("Codigo"));
                    d.NoLamina = reader.GetString(reader.GetOrdinal("NoLamina"));
                    d.Trayectoria = reader.GetString(reader.GetOrdinal("Trayectoria"));
                    d.Ubicacion = reader.GetString(reader.GetOrdinal("Ubicacion"));
                    d.FechaInspeccion = reader.GetDateTime(reader.GetOrdinal("FechaInspeccion"));
                    d.NumeroTubos = reader.GetInt32(reader.GetOrdinal("NumeroTubos"));
                    d.Longitud01 = reader.GetDecimal(reader.GetOrdinal("Longitud01"));
                    d.Longitud02 = reader.GetDecimal(reader.GetOrdinal("Longitud02"));
                    d.Longitud03 = reader.GetDecimal(reader.GetOrdinal("Longitud03"));
                    d.Longitud04 = reader.GetDecimal(reader.GetOrdinal("Longitud04"));
                    d.Longitud05 = reader.GetDecimal(reader.GetOrdinal("Longitud05"));
                    d.LongitudTotal = reader.GetDecimal(reader.GetOrdinal("LongitudTotal"));
                    d.PresionDiseño = reader.GetDecimal(reader.GetOrdinal("PresionDiseño"));
                    d.PresionMaximaAdmisibleOperacion = reader.GetDecimal(reader.GetOrdinal("PresionMaximaAdmisibleOperacion"));
                    d.PresionMaximaOperacion = reader.GetDecimal(reader.GetOrdinal("PresionMaximaOperacion"));
                    d.PresionNormalOperacion = reader.GetDecimal(reader.GetOrdinal("PresionNormalOperacion"));
                    d.Presion = reader.GetDecimal(reader.GetOrdinal("Presion"));
                    d.TemperaturaMaximaOperacion = reader.GetDecimal(reader.GetOrdinal("TemperaturaMaximaOperacion"));
                    d.Temperatura = reader.GetDecimal(reader.GetOrdinal("Temperatura"));
                    d.NPS01 = reader.GetInt32(reader.GetOrdinal("NPS01"));
                    d.NPS02 = reader.GetInt32(reader.GetOrdinal("NPS02"));
                    d.NPS03 = reader.GetInt32(reader.GetOrdinal("NPS03"));
                    d.NPS04 = reader.GetInt32(reader.GetOrdinal("NPS04"));
                    d.NPS05 = reader.GetInt32(reader.GetOrdinal("NPS05"));
                    d.BLPD = reader.GetInt32(reader.GetOrdinal("BLPD"));
                    d.Schedule1 = reader.GetInt32(reader.GetOrdinal("Schedule1"));
                    d.Schedule2 = reader.GetInt32(reader.GetOrdinal("Schedule2"));
                    d.Schedule3 = reader.GetInt32(reader.GetOrdinal("Schedule3"));
                    d.Material1 = reader.GetString(reader.GetOrdinal("Material1"));
                    d.Material2 = reader.GetString(reader.GetOrdinal("Material2"));
                    d.Material3 = reader.GetString(reader.GetOrdinal("Material3"));
                    d.BSW = reader.GetString(reader.GetOrdinal("BSW"));
                    d.Esfuerzo_S = reader.GetInt32(reader.GetOrdinal("Esfuerzo_S"));
                    d.FactorJunta_E = reader.GetInt32(reader.GetOrdinal("FactorJunta_E"));
                    d.FactorSensibilidadError = reader.GetDecimal(reader.GetOrdinal("FactorSensibilidadError"));
                    d.RowState = reader.GetString(reader.GetOrdinal("RowState"));
                    d.LastUpdate = reader.GetDateTime(reader.GetOrdinal("LastUpdate"));
                    ductos.List.Add(d);
                }
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
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
