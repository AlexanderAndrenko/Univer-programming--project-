﻿using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    class SupplierModel
    {
        public static List<Supplier> GetSupplier()
        {
            List<Supplier> lstSupplier = new List<Supplier>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    lstSupplier = db.Suppliers.ToList();

                    return lstSupplier;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return lstSupplier;
            }
        }

        public static void SetSupplier(List<Supplier> supplier, List<int> li)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    var dates = supplier.Select(x => x.Id).ToList();
                    var u = db.Suppliers.Where(x => dates.Contains(x.Id)).ToList();

                    li = li.Except(dates).ToList();
                    var deletedObjects = db.Suppliers.Where(x => li.Contains(x.Id)).ToList();

                    for (int i = 0; i < deletedObjects.Count(); i++)
                    {
                        db.Suppliers.Remove(deletedObjects[i]);
                    }

                    for (int i = 0; i < supplier.Count(); i++)
                    {
                        bool isNew = true;

                        for (int j = 0; j < u.Count(); j++)
                        {
                            if (u[j].Id == supplier[i].Id)
                            {
                                u[j].Name = supplier[i].Name;
                                u[j].Phone = supplier[i].Phone;

                                isNew = false;
                            }
                        }

                        if (isNew)
                        {
                            var newSupplier = new Supplier()
                            {
                                Name = supplier[i].Name,
                                Phone = supplier[i].Phone
                            };

                            db.Suppliers.Add(newSupplier);
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
    }
}

