using Kindergarten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.ViewModels
{
    public class Account
    {
        #region Constructor
        private static Account instance;
        public static Account GetInstance(string login)
        {
            if (instance == null)
                instance = new Account(login);
            return instance;
        }
        private Account(string login)
        {
            Login = login;
            Name = AccountModel.GetName(Login);
            Surname = AccountModel.GetSurname(Login);
            Patronymic = AccountModel.GetPatronymic(Login);
            AccessLevel = AccountModel.GetAccessLevel(Login);
        }
        #endregion //Constructor

        #region Method

        public void DeleteObject()
        {
            instance = null;
        }

        #endregion //Method

        #region Properties
        public string Login { get; set; }        
        public int AccessLevel { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        #endregion //Properties
    }
}
