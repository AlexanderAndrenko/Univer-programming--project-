using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    public class DishFactModel
    {
        public static List<DishFact> GetDishFact(int DishFact)
        {
            List<DishFact> dishes = new List<DishFact>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    dishes = db.DishFacts.Where(x => x.Id == DishFact).ToList();
                    return dishes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return dishes;
            }
        }

        public static void SetDishFact(ICollection<DishFact> dishes)
        {
            using (KindergartenContext db = new KindergartenContext())
            {
                db.DishFacts.AddRange(dishes);

                db.DishFacts.ForEachAsync(x => 
                {
                    ICollection<DishItemFact> dishItemFacts = x.DishItemFacts;


                });

                


                foreach (var item in dishFacts)
                {
                    item.MenuFactId = db.MenuFacts.Local.First().Id;
                }



            }
        }

    }
}
