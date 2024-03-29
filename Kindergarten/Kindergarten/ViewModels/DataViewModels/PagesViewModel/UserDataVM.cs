﻿using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    class UserDataVM : BaseVM
    {
        #region Constructor
        private static UserDataVM instanse;

        public static UserDataVM GetInstanse()
        {
            if (instanse == null)
                instanse = new UserDataVM();
            return instanse;
        }
        private UserDataVM()
        {
            EmployeeList = EmployeeModel.GetEmployee();
            GetUser();
            SaveChanges = new OwnCommand(SetUser);
        }
        #endregion //Constructor

        #region Properties

        private List<User> dataGridUsers;
        public List<User> DataGridUsers 
        { 
            get => dataGridUsers; 
            set
            {
                dataGridUsers = value;
                RaisePropertyChanged();
            }
        }
        private List<int> Ids { get; set; }

        public OwnCommand SaveChanges { get; set; }

        public List<Employee> EmployeeList { get; set; }

        #endregion //Properties

        #region Methods

        public void SetUser()
        {
            UserModel.SetUser(DataGridUsers, Ids);
            GetUser();
        }

        public void GetUser()
        {
            DataGridUsers = UserModel.GetUser();
            if (Ids != null)
                Ids.Clear();
            Ids = DataGridUsers.Select(x => x.Id).ToList();
        }

        #endregion //Methods

    }
}
