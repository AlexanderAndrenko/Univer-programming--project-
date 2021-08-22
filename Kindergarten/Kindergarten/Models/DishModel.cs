using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    public class DishModel
    {
        public static List<Dish> GetDishes(int menuId)
        {
            List<Dish> dishes = new List<Dish>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    dishes = db.Dishes.Where(x => x.MenuId == menuId).ToList();

                    return dishes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return dishes;
            }
        }

        public static void SetDishes(List<Dish> dishes, List<int> li)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    var dishDict = dishes.ToDictionary(x => x.Id);
                    li.ForEach(x =>
                    {
                        if (!dishDict.ContainsKey(x))
                        {
                            db.Entry(db.Users.Where(y => y.Id == x).FirstOrDefault()).State = EntityState.Deleted;
                        }
                    });

                    dishes.ForEach(x =>
                    {
                        db.Entry(x).State = x.Id == 0 ? EntityState.Added : EntityState.Modified;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
