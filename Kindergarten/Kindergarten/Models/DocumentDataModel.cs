using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    public class DocumentDataModel
    {
        public static List<DocumentData> GetDocumentData(Document document)
        {
            List<DocumentData> documentData = new List<DocumentData>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    documentData = db.DocumentData.Where(x => x.DocumentId == document.Id).ToList();
                    return documentData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return documentData;
            }
        }

        public static void SetDocumentData(List<DocumentData> documentData)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    foreach (var item in documentData)
                    {
                        if (item.ProductId == 0 || item.Quantity == 0)
                        {
                            documentData.Remove(item);
                        }
                    }

                    db.DocumentData.AddRange(documentData);
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
