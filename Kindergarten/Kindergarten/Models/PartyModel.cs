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
                        .Include(x => x.Invoice)
                        .Include(x => x.Product)
                        .Include(x => x.Supplier)
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
    }
}
