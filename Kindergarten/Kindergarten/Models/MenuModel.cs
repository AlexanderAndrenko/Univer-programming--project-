using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    public class MenuModel
    {
        /// <summary>
        /// Возвращает все шаблоны меню
        /// </summary>
        /// <returns></returns>
        public static List<Menu> GetMenus()
        {
            List<Menu> menus = new List<Menu>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    menus = db.Menus.ToList();
                    return menus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return menus;
            }
        }

        /// <summary>
        /// Возвращает определенное меню со связными сущностями
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        public static List<Menu> GetMenus(int MenuId)
        {
            List<Menu> menus = new List<Menu>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    menus = db.Menus.Where(x => x.Id == MenuId).Include(x => x.Dishes).ThenInclude(y => y.DishItems).ToList();
                    return menus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return menus;
            }
        }

        public static void SetMenus(List<Menu> menus, List<int> li)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    var menuDict = menus.ToDictionary(x => x.Id);
                    li.ForEach(x =>
                    {
                        if (!menuDict.ContainsKey(x))
                        {
                            db.Entry(db.Users.Where(y => y.Id == x).FirstOrDefault()).State = EntityState.Deleted;
                        }
                    });

                    menus.ForEach(x =>
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
