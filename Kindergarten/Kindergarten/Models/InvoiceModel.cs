using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    class InvoiceModel
    {
        public static List<Invoice> GetInvoice(DateTime startDate, DateTime endDate)
        {
            List<Invoice> invoices = new List<Invoice>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    invoices = db.Invoices.Where(x => x.DateOfInvoice >= startDate).Where(x => x.DateOfInvoice <= endDate).ToList();

                    return invoices;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return invoices;
            }
        }

        public static void SetInvoice(Invoice invoice)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.Invoices.Add(invoice);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void DeletedInvoice(int id)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    var i = db.Invoices.Where(x => x.ID == id).ToList();
                    i.RemoveAt(0);
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
