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
            try
            { 
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.DishFacts.AddRange(dishes);
                    db.SaveChanges();

                    foreach (var item in dishes)
                    {
                        ICollection<DishItemFact> dishItemFacts = item.DishItemFacts;


                        DishItemFactModel.SetDishItemFacts(dishItemFacts);
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
