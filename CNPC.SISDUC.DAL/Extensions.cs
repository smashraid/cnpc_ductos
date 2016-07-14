using System;
using System.Data.SqlClient;

namespace CNPC.SISDUC.DAL
{
    public static class SqlDataReaderExtensions
    {
        public static bool SafeGetBoolean(this SqlDataReader reader,
                                      string columnName, bool defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetBoolean(ordinal);
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
        public static byte SafeGetByte(this SqlDataReader reader,
                                      string columnName, byte defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetByte(ordinal);
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
        public static short SafeGetShort(this SqlDataReader reader,
                                      string columnName, short defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetInt16(ordinal);
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
        public static int SafeGetInt16(this SqlDataReader reader,
                                      string columnName, int defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetInt16(ordinal);
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
        public static int SafeGetInt32(this SqlDataReader reader,
                                       string columnName, int defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetInt32(ordinal);
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
        public static Int64 SafeGetInt64(this SqlDataReader reader,
                                       string columnName, Int64 defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetInt64(ordinal);
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
        public static decimal SafeGetDecimal(this SqlDataReader reader,
                                      string columnName, decimal defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetDecimal(ordinal);
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
        public static string SafeGetString(this SqlDataReader reader,
                                       string columnName, string defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetString(ordinal).ToString();
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
        public static DateTime SafeGetDateTime(this SqlDataReader reader,
                                      string columnName, DateTime defaultValue)
        {
            int ordinal = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(ordinal))
            {
                var valor = reader.GetDateTime(ordinal);
                return valor;
            }
            else
            {
                return defaultValue;
            }
        }
    }
    public static class SHA1
    {
        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }
}
