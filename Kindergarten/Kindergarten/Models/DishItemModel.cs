using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    public class DishItemModel
    {
        public static List<DishItem> GetDishItems(int dishId)
        {
            List<DishItem> dishItems = new List<DishItem>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    dishItems = db.DishItems.Where(x => x.DishId == dishId).ToList();
                    return dishItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return dishItems;
            }
        }

        public static void SetDishItems(List<DishItem> dishItems, List<int> li)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    //var dishItemsDict = dishItems.ToDictionary(x => x.Id);

                    var dishItemsDict = dishItems.Select(x => x.Id).ToList();
                    li.ForEach(x =>
                    {
                    if (!dishItemsDict.Contains(x))        //!dishItemsDict.ContainsKey(x)
                        {
                            db.Entry(db.Users.Where(y => y.Id == x).FirstOrDefault()).State = EntityState.Deleted;
                        }
                    });

                    dishItems.ForEach(x =>
                    {
                        db.Entry(x).State = x.Id == 0 ? EntityState.Added : EntityState.Modified;
                    });

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
