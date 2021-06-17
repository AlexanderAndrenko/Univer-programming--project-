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
        public static void SetChildrenData(List<NumberChildren> data)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    List<NumberChildren> nc = new List<NumberChildren>();

                    for (int i = 0; i < data.Count(); i++)
                    {
                        List<NumberChildren> numberChildrens = db.NumberChildrens.Where(x => x.Id == data[i].Id).ToList();

                        if (numberChildrens.Count() != 0)
                        {
                            nc.Add(numberChildrens[0]);
                        }                        
                    }

                    for (int i = 0; i < data.Count(); i++)
                    {
                        int index =  nc.FindIndex(x=>x.Id == data[i].Id);

                        if (index != -1)
                        {
                            nc[index].Date = data[i].Date;
                            nc[index].QuantityNursery = data[i].QuantityNursery;
                            nc[index].QuantityYard = data[i].QuantityYard;
                        }
                        else
                        {
                            NumberChildren a = new NumberChildren();

                            a.Date = data[i].Date;
                            a.QuantityNursery = data[i].QuantityNursery;
                            a.QuantityYard = data[i].QuantityYard;

                            nc.Add(a);
                        }

                        db.SaveChanges();
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
