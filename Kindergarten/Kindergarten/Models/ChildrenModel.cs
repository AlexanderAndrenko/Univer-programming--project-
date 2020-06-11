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
        public static List<Children> GetChildrenData(string selectedDay = "*", string selectedMounth = "*", string selectedYear = "*")
        {
            List<Children> lstChildren = new List<Children>();
            selectedDay = DateCollections.ConvertDayToSqlFormat(selectedDay);
            selectedMounth = DateCollections.ConvertMounthToSqlFormat(selectedMounth);

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

                    if (selectedDay == "*" && selectedMounth == "*" && selectedYear == "*")
                    {
                        command = new SqlCommand(@"SELECT * FROM Children", connection);
                    }
                    else if (selectedDay == "*" && selectedMounth == "*")
                    {
                        command = new SqlCommand(@"SELECT * FROM Children WHERE Data >= '" + selectedYear + "0101' AND  Data <= '" + selectedYear + "1231'", connection);
                    }
                    else if (selectedDay == "*")
                    {
                        command = new SqlCommand(@"SELECT * FROM Children WHERE Data >= '" + selectedYear + selectedMounth + "01' AND  Data <= '" + selectedYear + selectedMounth + "30'", connection);
                    }
                    
                    
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

                    command = new SqlCommand(@"SELECT * FROM Children WHERE Data >= '" + startDate.Year + SetNormalView(startDate.Month) + SetNormalView(startDate.Day) + "' AND Data <= '" + endDate.Year + SetNormalView(endDate.Month) + SetNormalView(endDate.Day) + "' ", connection);

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

        private static string SetNormalView(int number)
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
