using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    public class DishItemFactModel
    {
        public static List<DishItemFact> GetDishItemFacts(int DishFactId)
        {
            List<DishItemFact> dishItemFact = new List<DishItemFact>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    dishItemFact = db.DishItemFacts.Where(x => x.DishFactId == DishFactId).ToList();
                    return dishItemFact;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return dishItemFact;
            }
        }

        public static void SetDishItemFacts(ICollection<DishItemFact> dishItemFacts)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.DishItemFacts.AddRange(dishItemFacts);
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
