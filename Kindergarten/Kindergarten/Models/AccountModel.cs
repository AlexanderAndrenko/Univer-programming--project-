using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kindergarten.Models
{
    public class AccountModel
    {
        public static string GetName(string login)
        {
            
            try{
                using (SqlConnection connection = new SqlConnection(@"Data source = ALEXANDER-PC\SQLEXPRESS; Initial Catalog = StudyDB; Integrated Security = true; Pooling = False;"))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка открытия соединения!","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return "";
                    }

                    SqlCommand command = connection.CreateCommand();
                    command = new SqlCommand(@"SELECT Name FROM Employee JOIN Account ON Employee.ID_employee = (SELECT ID_employee FROM Account WHERE Login = '" + login + "')", connection );
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    bool i = reader.HasRows;
                    int j = reader.FieldCount;
                    string name = reader["Name"].ToString();
                    reader.Close();
                    return name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }
        public static string GetSurname(string login)
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
                        MessageBox.Show("Ошибка открытия соединения!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return "";
                    }

                    SqlCommand command = connection.CreateCommand();
                    command = new SqlCommand(@"SELECT Surname FROM Employee JOIN Account ON Employee.ID_employee = (SELECT ID_employee FROM Account WHERE Login = '" + login + "')", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    bool i = reader.HasRows;
                    int j = reader.FieldCount;
                    string surname = reader["Surname"].ToString();
                    reader.Close();
                    return surname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }
        public static string GetPatronymic(string login)
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
                        MessageBox.Show("Ошибка открытия соединения!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return "";
                    }

                    SqlCommand command = connection.CreateCommand();
                    command = new SqlCommand(@"SELECT Patronymic FROM Employee JOIN Account ON Employee.ID_employee = (SELECT ID_employee FROM Account WHERE Login = '" + login + "')", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    bool i = reader.HasRows;
                    int j = reader.FieldCount;
                    string patronymic = reader["Patronymic"].ToString();
                    reader.Close();
                    return patronymic;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }
        public static int GetAccessLevel(string login)
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
                        MessageBox.Show("Ошибка открытия соединения!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return -1;
                    }

                    SqlCommand command = connection.CreateCommand();
                    command = new SqlCommand(@"SELECT AccessLevel FROM Account WHERE Login = '" + login + "'", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    bool i = reader.HasRows;
                    int j = reader.FieldCount;
                    int accessLevel = Convert.ToInt32(reader["AccessLevel"].ToString());
                    reader.Close();
                    return accessLevel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }
    }
}
