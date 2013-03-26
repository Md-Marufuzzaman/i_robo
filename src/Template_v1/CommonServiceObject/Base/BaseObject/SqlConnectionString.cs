using System;
using System.Web;
using System.Configuration;

namespace CommonServiceObject.Base.BaseObject
{
    static class SqlConnectionString
    {
        public static string GetConnectionString()
        {
            string connectionString = string.Empty;

            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/connectionStrings");
            System.Configuration.ConnectionStringSettings sqlConnectionString;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                sqlConnectionString =
                    rootWebConfig.ConnectionStrings.ConnectionStrings["template_v1ConnectionString"];
                if (sqlConnectionString != null)
                    connectionString = sqlConnectionString.ConnectionString;
                else
                    connectionString = null;
            }

            return connectionString;

        }
    }

}
