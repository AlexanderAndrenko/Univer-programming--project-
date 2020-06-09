using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows;
using System.Diagnostics;

namespace Kindergarten.Models
{
    public class SingInModel
    {
        public static bool CheckLogin(string login, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data source = ALEXANDER-PC\SQLEXPRESS; Initial Catalog = StudyDB; Integrated Security = true; Pooling = False;"))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);//Вывод в лог текст исключения
                        throw;
                    }
                    SqlCommand command = connection.CreateCommand();
                    command = new SqlCommand(@"SELECT Password FROM Account WHERE Login = '" + login + "'", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if(password == reader["Password"].ToString())
                    {
                        reader.Close();
                        return true;
                    }

                    reader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);//Вывод в лог текст исключения
                MessageBox.Show("Ошибка подключения к базе данных!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
