using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    public class MenuFactModel
    {
        public static List<MenuFact> GetMenuFacts(int MenuFactId)
        {
            List<MenuFact> menus = new List<MenuFact>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    menus = db.MenuFacts.Where(x => x.Id == MenuFactId).ToList();
                    return menus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return menus;
            }
        }

        public static void SetMenuFact(MenuFact menu)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.MenuFacts.Add(menu);
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
