using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows;

namespace Kindergarten.Models
{
    public class SingInModel
    {
        public static bool CheckLogin(string login, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data source = localhost; Initial Catalog = StudyDB; Integrated Security = true; Pooling = False;");

                using (SqlCommand sql = conn.CreateCommand())
                {
                    SqlCommand com = new SqlCommand(@"SELECT Password FROM StudyDB.dbo.Account WHERE Login = " + login, conn);
                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();

                    if(password == reader["Password"].ToString())
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к базе данных!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
