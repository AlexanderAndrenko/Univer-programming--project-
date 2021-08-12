﻿using System;
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
                    var ids = data.Select(x => x.Id).ToList();                    
                    var nc = db.NumberChildrens.Where(x => ids.Contains(x.Id)).ToList();

                    for (int i = 0; i < data.Count(); i++)
                    {
                        for (int j = 0; j < nc.Count(); j++)
                        {
                            if (nc[j].Id == data[i].Id)
                            {
                                nc[j].Date = data[i].Date;
                                nc[j].QuantityNursery = data[i].QuantityNursery;
                                nc[j].QuantityYard = data[i].QuantityYard;
                            }
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
