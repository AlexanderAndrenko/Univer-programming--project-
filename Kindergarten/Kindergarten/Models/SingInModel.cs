using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows;
using System.Diagnostics;
using Kindergarten.Models.Entities;

namespace Kindergarten.Models
{
    public class SingInModel
    {
        public static bool CheckLoginOld(string login, string password)
        {            
            try
            {
                using (SqlConnection connection = DBSQLServerUtils.GetDBConnection())
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
                    command = new SqlCommand(@"SELECT [Password] FROM [StudyDB].[dbo].[Account] WHERE [Login] = '" + login + "'", connection);
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

        public static bool CheckLogin(string login, string password)
        {            
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    List<User> user = db.Users.Where(p => p.Login == login).ToList(); 

                    if (user == null || user.Count() != 1)
	                {
                        return false;
	                }
                    else if(user[0].Password == password)
                    {
                        return true;
                    }
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);//Вывод в лог текст исключения
                MessageBox.Show("Ошибка создания контекста", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

    }
}
