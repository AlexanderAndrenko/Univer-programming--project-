using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    class ProductsModel
    {
        public static List<Product> GetProducts()
        {
            List<Product> lstProducts = new List<Product>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    lstProducts = db.Products.ToList();

                    return lstProducts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return lstProducts;
            }
        }

        public static void SetProducts(List<Product> products, List<int> ids)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    var dates = products.Select(x => x.Id).ToList();
                    var nc = db.Products.Where(x => dates.Contains(x.Id)).ToList();

                    ids = ids.Except(dates).ToList();
                    var deletedObjects = db.Products.Where(x => ids.Contains(x.Id)).ToList();

                    for (int i = 0; i < deletedObjects.Count(); i++)
                    {
                        db.Products.Remove(deletedObjects[i]);
                    }

                    for (int i = 0; i < products.Count(); i++)
                    {
                        bool isNew = true;

                        for (int j = 0; j < nc.Count(); j++)
                        {
                            if (nc[j].Id == products[i].Id)
                            {
                                nc[j].Name = products[i].Name;

                                isNew = false;
                            }
                        }

                        if (isNew)
                        {
                            var newProducts = new Product()
                            {
                                Name = products[i].Name
                            };

                            db.Products.Add(newProducts);
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

