using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Models
{
    public class PartyModel
    {
        public static List<Party> GetParty()
        {
            List<Party> parties = new List<Party>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    parties = db.Parties.Where(x => x.IsClosed == false)
                        .Include(x => x.Document)
                        .Include(x => x.Product)
                        .ToList();
                    return parties;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return parties;
            }
        }

        public static void SetParty(List<Party> parties)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.Parties.AddRange(parties);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void SetPartyFromInvoice(List<Party> parties)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.Parties.AddRange(parties);
                    db.SaveChanges();

                    List<DocumentData> dd = new List<DocumentData>();

                    var lp = db.Parties.Local.ToList();
                    lp.ForEach(x =>
                        dd.Add(
                                new DocumentData()
                                {
                                    Quantity = x.Quantity,
                                    DateCreated = DateTime.Now,
                                    DocumentId = x.DocumentId,
                                    ProductId = x.ProductId,
                                    PartyId = x.Id
                                }
                            )
                    );

                    DocumentDataModel.SetDocumentData(dd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
