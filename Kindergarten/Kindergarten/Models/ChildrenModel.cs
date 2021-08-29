using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Models
{
    public class ChildrenModel
    {
        /// <summary>
        /// Возвращается список дат с количеством детей каждой категории
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<NumberChildren> GetChildrenData(DateTime startDate, DateTime endDate)
        {
            List<NumberChildren> lstChildren = new List<NumberChildren>();

            try
            {
                using (KindergartenContext db =  new KindergartenContext())
                {
                    lstChildren = db.NumberChildrens.Where(x => x.Date >= startDate).Where(x => x.Date <= endDate).ToList();

                    return lstChildren;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return lstChildren;
            }
        }

        public static void SetChildrenData(List<NumberChildren> data, List<DateTime> gd)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    var dates = data.Select(x => x.Date).ToList();                    
                    var nc = db.NumberChildrens.Where(x => dates.Contains(x.Date)).ToList();
                    List<int> ids = new List<int>();

                    for (int i = 0; i < gd.Count(); i++)
                    {
                        for (int j = 0; j < data.Count(); j++)
                        {
                            if (gd[i] == data[j].Date)
                            {
                                ids.Add(i);
                            }
                        }
                    }

                    ids.Distinct();
                    ids.Reverse();

                    for (int i = 0; i < ids.Count(); i++)
                    {
                        gd.RemoveAt(ids[i]);
                    }


                    var deletedObjects = db.NumberChildrens.Where(x => gd.Contains(x.Date)).ToList();

                    for (int i = 0; i < deletedObjects.Count(); i++)
                    {
                        db.NumberChildrens.Remove(deletedObjects[i]);
                    }

                    for (int i = 0; i < data.Count(); i++)
                    {
                        bool isNew = true;

                        for (int j = 0; j < nc.Count(); j++)
                        {
                            if (nc[j].Date == data[i].Date)
                            {
                                nc[j].QuantityNursery = data[i].QuantityNursery;
                                nc[j].QuantityYard = data[i].QuantityYard;

                                isNew = false;
                            }
                        }

                        if (isNew)
                        {
                            var newNumberChildrens = new NumberChildren()
                            {
                                Date = data[i].Date,
                                QuantityNursery = data[i].QuantityNursery,
                                QuantityYard = data[i].QuantityYard                                
                            };

                            db.NumberChildrens.Add(newNumberChildrens);
                        }
                            
                    }

                    db.SaveChanges();
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
}
