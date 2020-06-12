using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kindergarten.Models
{
    public class ChildrenModel
    {
        public static List<Children> GetChildrenData(DateTime startDate, DateTime endDate)
        {
            List<Children> lstChildren = new List<Children>();

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data source = ALEXANDER-PC\SQLEXPRESS; Initial Catalog = StudyDB; Integrated Security = true; Pooling = False;"))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка открытия соединения!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return null;
                    }

                    SqlCommand command = connection.CreateCommand();

                    command = new SqlCommand(@"SELECT * FROM Children WHERE Data >= '" + startDate.Year + SetNormalViewDate(startDate.Month) + SetNormalViewDate(startDate.Day) + "' AND Data <= '" + endDate.Year + SetNormalViewDate(endDate.Month) + SetNormalViewDate(endDate.Day) + "' ", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lstChildren.Add(new Children());
                        lstChildren[lstChildren.Count() - 1].Date = Convert.ToDateTime(reader["Data"].ToString());
                        lstChildren[lstChildren.Count() - 1].Nursery = Convert.ToInt32(reader["Nursery"].ToString());
                        lstChildren[lstChildren.Count() - 1].Yard = Convert.ToInt32(reader["Yard"].ToString());
                    }
                    reader.Close();
                    return lstChildren;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public static void SetChildrenData(Children data)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data source = ALEXANDER-PC\SQLEXPRESS; Initial Catalog = StudyDB; Integrated Security = true; Pooling = False;"))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка открытия соединения!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    SqlCommand command = connection.CreateCommand();

                    //command = new SqlCommand(@"INSERT INTO Children VALUES (" + data.Date + ", " + data.Nursery + ", " + data.Yard +")", connection);
                    command = new SqlCommand(@"INSERT INTO Children VALUES (@Date, @Nursery, @Yard) ", connection);

                    command.Parameters.Add("@Date", System.Data.SqlDbType.Date);
                    command.Parameters.Add("@Nursery", System.Data.SqlDbType.Int);
                    command.Parameters.Add("@Yard", System.Data.SqlDbType.Int);

                    command.Parameters["@Date"].Value = data.Date;
                    command.Parameters["@Nursery"].Value = data.Nursery;
                    command.Parameters["@Yard"].Value = data.Yard;

                    try
                    {
                        int rowAffected = command.ExecuteNonQuery();

                        if (rowAffected == 1)
                        {
                            MessageBox.Show("Данные добавлены.", "", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Что-то пошло не так. Попробуйте снова.", "", MessageBoxButton.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void DeleteChildrenData(DateTime selectedDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data source = ALEXANDER-PC\SQLEXPRESS; Initial Catalog = StudyDB; Integrated Security = true; Pooling = False;"))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка открытия соединения!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    SqlCommand command = connection.CreateCommand();

                    command = new SqlCommand(@"DELETE FROM Children WHERE Data = @SelectedDate", connection);
                    command.Parameters.Add("@SelectedDate", System.Data.SqlDbType.Date);
                    command.Parameters["@SelectedDate"].Value = selectedDate;                   

                    try
                    {
                        int rowAffected = command.ExecuteNonQuery();

                        if (rowAffected == 1)
                        {
                            MessageBox.Show("Данные удалены.", "", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Что-то пошло не так. Попробуйте снова.", "", MessageBoxButton.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static string SetNormalViewDate(int number)
        {
            if (Convert.ToString(number).Length == 1)
            {
                return Convert.ToString("0" + number);
            }

            return Convert.ToString(number);
        }


    }
    public class Children
    {
        public DateTime Date { get; set; }
        public int Nursery { get; set; }
        public int Yard { get; set; }
    }

    
}
