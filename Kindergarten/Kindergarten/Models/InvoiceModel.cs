using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
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
                    invoices = db.Invoices.Where(x => x.DateOfInvoice >= startDate).Where(x => x.DateOfInvoice <= endDate).Include(x => x.Supplier).ToList();

                    return invoices;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return invoices;
            }
        }

        public static void SetInvoice(Invoice invoice, List<Party> parties)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    foreach (var item in parties)
                    {
                        if (item.ProductId == 0)
                        {
                            parties.Remove(item);
                        }
                    }

                    if (parties.Count() > 0)
                    {
                        db.Entry(invoice).State = invoice.ID == 0 ? EntityState.Added : EntityState.Modified;
                        db.SaveChanges();

                        var dt = db.DocumentTypes.Where(x => x.Name == "Приход от поставщика").FirstOrDefault();

                        var document = new Document()
                        {
                            Date = DateTime.Now,
                            InvoiceId = db.Invoices.Local.First().ID,
                            DocumentTypeId = dt.Id
                        };

                        DocumentModel.SetDocumentFromInvoice(document, parties);
                        MessageBox.Show("Накладная добавлена в систему!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Накладная не содержит товары!", "Пустая накладная", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
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
