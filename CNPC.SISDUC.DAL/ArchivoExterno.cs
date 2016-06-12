using CNPC.SISDUC.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace CNPC.SISDUC.DAL
{
    public class ArchivoExterno : IDisposable
    {
        public List<Oleoducto> LeerRegistrosExcel(string rutaArchivo)
        {
            ExcelPackage ep = new ExcelPackage(new FileInfo(rutaArchivo));
            ExcelWorksheet ws = ep.Workbook.Worksheets["Oleoductos"];

            List<Oleoducto> domains = new List<Oleoducto>();
            for (int rw = 2; rw <= ws.Dimension.End.Row; rw++)
            {
                domains.Add(new Oleoducto
                {
                    Id = rw,
                    Cliente = "CNPC PERU SA",
                    Codigo = ws.Cells[rw, 3].Value.ToString(),
                });
            }
            return domains;
        }
        public bool GuardarRegistros(IList<Oleoducto> lista, string tabla)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CNPC_Ductos"].ConnectionString))
            {
                bool result = false;
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = tabla;
                    try
                    {
                        bulkCopy.WriteToServer(lista.AsDataTable());
                        result = true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        connection.Close();
                        result = false;
                    }
                }

                transaction.Commit();
                return result;
            }
        }
        public bool CopiarRegistros(string rutaArchivo)
        {
            List<Oleoducto> lista = LeerRegistrosExcel(rutaArchivo);
            return GuardarRegistros(lista, "Ductos");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
