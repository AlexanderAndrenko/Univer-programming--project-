using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Kindergarten.Models
{
    public class PartyModel
    {
        /// <summary>
        /// Возвращает все партии, которые не закрыты
        /// </summary>
        /// <returns></returns>
        public static List<Party> GetParty()
        {
            List<Party> parties = new List<Party>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    parties = db.Parties.Where(x => x.IsClosed == false)
                        .Include(x => x.Document).ThenInclude(x => x.Invoice).ThenInclude(y => y.Supplier)
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

        public class PartyComparer : IComparer<Party>
        {
            public int Compare([AllowNull] Party x, [AllowNull] Party y)
            {
                if (x.DateCreated > y.DateCreated)
                {
                    return 1;
                }
                else if (x.DateCreated < y.DateCreated)
                {
                    return -1;
                }

                return 0;
            }
        }
    }
}
