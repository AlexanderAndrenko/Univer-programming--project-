using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Models
{
    class DBSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = datasource;
            builder.UserID = username;
            builder.Password = password;
            builder.IntegratedSecurity = false;
            builder.InitialCatalog = database;

            SqlConnection conn = new SqlConnection(builder.ConnectionString);

            return conn;
        }

        public static SqlConnection GetDBConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = CredentialsForServer.DataSource;
            builder.UserID = CredentialsForServer.Login;
            builder.Password = CredentialsForServer.Password;
            builder.IntegratedSecurity = false;
            builder.InitialCatalog = CredentialsForServer.DataBase;

            SqlConnection conn = new SqlConnection(builder.ConnectionString);

            return conn;
        }

    }
}
