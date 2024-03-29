﻿using Kindergarten.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Kindergarten.Models
{
    class UserModel
    {
        public static List<User> GetUser()
        {
            List<User> lstUser = new List<User>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    lstUser = db.Users.Include(x => x.Employee).ToList();
                    //Where(x => x.Date >= startDate).Where(x => x.Date <= endDate).ToList();

                    return lstUser;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return lstUser;
            }
        } 

        /// <summary>
        /// Метод добавления пользователей в БД
        /// </summary>
        public static void SetUser(List<User> users, List<int> li)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    var usersDict = users.ToDictionary(x => x.Id);
                    li.ForEach(x =>
                    {
                        if (!usersDict.ContainsKey(x))
                        {
                            db.Entry(db.Users.Where(y => y.Id == x).FirstOrDefault()).State = EntityState.Deleted;
                        }
                    });

                    users.ForEach(x =>
                    {
                        db.Entry(x).State = x.Id == 0 ? EntityState.Added : EntityState.Modified;
                    });


                    #region OldCodeForHistory
                    /*var dates = users.Select(x => x.Id).ToList();
                    var u = db.Users.Where(x => dates.Contains(x.Id)).Include(x => x.Employee).ToList();

                    li = li.Except(dates).ToList();
                    var deletedObjects = db.Users.Where(x => li.Contains(x.Id)).ToList();

                    for (int i = 0; i < deletedObjects.Count(); i++)
                    {
                        db.Users.Remove(deletedObjects[i]);
                    }

                    for (int i = 0; i < users.Count(); i++)
                    {
                        bool isNew = true;

                        for (int j = 0; j < u.Count(); j++)
                        {
                            if (u[j].Id == users[i].Id)
                            {
                                u[j].Login = users[i].Login;
                                u[j].Password = users[i].Password;
                                u[j].LevelAccess = users[i].LevelAccess;
                                u[j].EmployeeId = users[i].EmployeeId;

                                isNew = false;
                            }
                        }

                        if (isNew)
                        {
                            var newUser = new User()
                            {
                                Login = users[i].Login,
                                Password = users[i].Password,
                                LevelAccess = users[i].LevelAccess,
                                EmployeeId = users[i].EmployeeId
                            };

                            db.Users.Add(newUser);
                        }
                    }*/
                    #endregion //OldCodeForHistory

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
