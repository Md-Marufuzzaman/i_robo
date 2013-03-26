using System;
using System.Data.SqlClient;
using System.Text;


namespace DataModelObject.DataBaseHelper
{
    static class SqlDataTypeManager
    {
        static public int DB_NULL_INT = -2147483648;
        static public int DB_NULL_FLOAT = -2147483648;
        static public String DB_NULL_STR = "?";
        static public String DB_NULL_CHAR = "?";
        static public DateTime DB_NULL_DATE = new DateTime(1970, 01, 01);


        public static bool? GetBool(Object val)
        {
            return (val == DBNull.Value) ? (bool?)null : (bool)val;
        }

        public static int? GetInt(Object val)
        {
            return (val == DBNull.Value || (int)val == DB_NULL_INT) ? (int?)null : (int)val;
        }

        public static float? GetFloat(Object val)
        {
            return (val == DBNull.Value || (float)val == DB_NULL_FLOAT) ? (float?)null : (float)val;
        }

        public static double? GetDouble(Object val)
        {
            return (val == DBNull.Value || (double)val == DB_NULL_FLOAT) ? (double?)null : (double)val;
        }

        public static String GetString(Object val)
        {
            return (val == DBNull.Value || (String)val == DB_NULL_STR) ? null : (String)val;
        }

        public static DateTime? GetDateTime(Object val)
        {
            return (val == DBNull.Value || (DateTime)val == DB_NULL_DATE) ? (DateTime?)null : (DateTime)val;
        }


        public static Boolean? GetBoolean(Object val)
        {
            return (val == DBNull.Value) ? (Boolean?)null : (Boolean)val;
        }


        public static String TranslateException(SqlException ex)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (SqlError error in ex.Errors)
            {
                stringBuilder.Append(error.Number).Append(" => ").Append(error.Message).Append("\n");
            }

            return stringBuilder.ToString();
        }

    }
}
