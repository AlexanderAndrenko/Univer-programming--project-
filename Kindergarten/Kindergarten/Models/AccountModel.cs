using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Models
{
    public class AccountModel
    {
        public static string GetName(string login)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    List<User> user = db.Users.Include(p=>p.Employee).Where(p => p.Login == login).ToList();

                    if (user.FirstOrDefault() != null && user.Count() == 1)
                    {
                        return user[0].Employee.Name;
                    }

                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }



        public static string GetSurname(string login)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    List<User> user = db.Users.Include(p => p.Employee).Where(p => p.Login == login).ToList();

                    if (user.FirstOrDefault() != null && user.Count() == 1)
                    {
                        return user[0].Employee.Lastname;
                    }

                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }
        public static string GetPatronymic(string login)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    List<User> user = db.Users.Include(p => p.Employee).Where(p => p.Login == login).ToList();

                    if (user.FirstOrDefault() != null && user.Count() == 1)
                    {
                        return user[0].Employee.Patronymic;
                    }

                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }
        public static int GetAccessLevel(string login)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    List<User> user = db.Users.Include(p => p.Employee).Where(p => p.Login == login).ToList();

                    if (user.FirstOrDefault() != null && user.Count() == 1)
                    {
                        return user[0].LevelAccess;
                    }
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
        }
    }
}
