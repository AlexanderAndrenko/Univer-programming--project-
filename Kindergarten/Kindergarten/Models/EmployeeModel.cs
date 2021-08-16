using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kindergarten.Models
{
    class EmployeeModel
    {
        public static List<Employee> GetEmployee()
        {
            List<Employee> lstEmployee = new List<Employee>();

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    lstEmployee = db.Employees.ToList();
                        //Where(x => x.Date >= startDate).Where(x => x.Date <= endDate).ToList();

                    return lstEmployee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return lstEmployee;
            }
        }

        public static void SetEmployee(List<Employee> data, List<int> ids)
        {
            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    var dates = data.Select(x => x.Id).ToList();
                    var nc = db.Employees.Where(x => dates.Contains(x.Id)).ToList();

                    ids = ids.Except(dates).ToList();
                    var deletedObjects = db.Employees.Where(x => ids.Contains(x.Id)).ToList();

                    for (int i = 0; i < deletedObjects.Count(); i++)
                    {
                        db.Employees.Remove(deletedObjects[i]);
                    }

                    for (int i = 0; i < data.Count(); i++)
                    {
                        bool isNew = true;

                        for (int j = 0; j < nc.Count(); j++)
                        {
                            if (nc[j].Id == data[i].Id)
                            {
                                nc[j].Name = data[i].Name;
                                nc[j].Lastname = data[i].Lastname;
                                nc[j].Patronymic = data[i].Patronymic;
                                nc[j].Phone = data[i].Phone;
                                nc[j].Position = data[i].Position;

                                isNew = false;
                            }
                        }

                        if (isNew)
                        {
                            var newEmployees = new Employee()
                            {
                                Name = data[i].Name,
                                Lastname = data[i].Lastname,
                                Patronymic = data[i].Patronymic,
                                Phone = data[i].Phone,
                                Position = data[i].Position
                            };

                            db.Employees.Add(newEmployees);
                        }
                    }

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
