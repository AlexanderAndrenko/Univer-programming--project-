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
        public static List<Children> GetChildrenData(string selectedDay, string selectedMounth, string selectedYear)
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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка открытия соединения!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return null;
                    }

                    SqlCommand command = connection.CreateCommand();

                    if (selectedDay == "*" && selectedMounth == "*" && selectedYear == "*")
                    {
                        command = new SqlCommand(@"SELECT * FROM Children", connection);
                    }
                    
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        lstChildren.Add(new Children());
                        lstChildren[lstChildren.Count() - 1].Date = reader["Data"].ToString();
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
    }
    public class Children
    {
        public string Date { get; set; }
        public int Nursery { get; set; }
        public int Yard { get; set; }
    }
}
