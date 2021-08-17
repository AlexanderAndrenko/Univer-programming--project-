using Kindergarten.Models.Entities;
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
            List<Supplier> lstSuppleir = new List<Supplier>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    lstSuppleir = db.Suppliers.ToList();

                    return lstSuppleir;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return lstSuppleir;
            }
        }

        public static void SetSupplier()
        {

        }
    }
}
