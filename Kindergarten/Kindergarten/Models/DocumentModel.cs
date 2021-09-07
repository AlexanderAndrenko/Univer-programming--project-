using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    public class DocumentModel
    {
        ///<summary>
        ///Возвращает все документы указанног типа
        ///</summary>
        public static List<Document> GetDocument(DocumentType documentType)
        {
            List<Document> documents = new List<Document>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    documents = db.Documents.Where(x => x.DocumentType == documentType).ToList();
                    return documents;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return documents;
            }
        }

        ///<summary>
        ///Возвращает все документы за указанный интервал
        ///</summary>
        public static List<Document> GetDocument(DateTime startDate, DateTime endDate)
        {
            List<Document> documents = new List<Document>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    documents = db.Documents.Where(x => x.Date >= startDate).Where(x => x.Date <= endDate).Include(x => x.Invoice).Include(x => x.DocumentType).ToList();
                    return documents;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return documents;
            }
        }

        public static void SetDocument(Document document, List<Party> parties)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.Entry(document).State = document.Id == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();

                    parties.ForEach(x =>
                    {
                        x.DocumentId = db.Documents.Local.First().Id;
                    });

                    PartyModel.SetParty(parties);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void SetDocumentFromInvoice(Document document, List<Party> parties)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.Entry(document).State = document.Id == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();

                    parties.ForEach(x =>
                    {
                        x.DocumentId = db.Documents.Local.First().Id;
                    });

                    PartyModel.SetPartyFromInvoice(parties);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void SetDocumentExpenseForNutrition()
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.Entry(document).State = document.Id == 0 ? EntityState.Added : EntityState.Modified;
                    db.SaveChanges();

                    parties.ForEach(x =>
                    {
                        x.DocumentId = db.Documents.Local.First().Id;
                    });

                    PartyModel.SetPartyFromInvoice(parties);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
