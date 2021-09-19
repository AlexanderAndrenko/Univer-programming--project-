using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.ViewModels.Commands;
using Kindergarten.Models;
using Microsoft.EntityFrameworkCore;
using Kindergarten.Models.Entities;
using System.Windows;

namespace Kindergarten.ViewModels
{
    class CredentialForServerVM
    {
        private static CredentialForServerVM instance;

        public static CredentialForServerVM GetInstance()
        {
            if (instance == null)
                instance = new CredentialForServerVM();
            return instance;

        }

        private CredentialForServerVM()
        {
            //clickSaveButton += SetCredentials; на знаю зачем я всё это реализовывал
            SaveCredentialCommand = new CredentialCommand(SetCredentials);
        }


        public delegate void SaveCredential();
        public SaveCredential clickSaveButton;
        public string Login { private get; set; }
        public string Password { private get; set; }
        public string DataSource { get; set; }
        public string DataBase { get; set; }
        public CredentialCommand SaveCredentialCommand { get; private set; }

        public void SetCredentials()
        {
            CredentialsForServer.Login = Login;
            CredentialsForServer.Password = Password;
            CredentialsForServer.DataSource = DataSource;
            CredentialsForServer.DataBase = DataBase;

            try
            {
                using (KindergartenContext db = new KindergartenContext())
                {
                    db.Database.Migrate();
                    if (db.Users.ToList().Count() == 0 && db.Employees.ToList().Count() == 0)
                    {
                        db.Employees.Add(new Employee { Name = "Администратор", Lastname = "Администратор" });
                        db.Users.Add(new User { Login = "admin", Password = "admin", LevelAccess = 1, EmployeeId = db.Employees.Local.First().Id });
                        db.SaveChanges();
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
