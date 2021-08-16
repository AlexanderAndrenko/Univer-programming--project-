using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    class EmployeeDataVM : BaseVM
    {
        #region Constructor

        private static EmployeeDataVM instance;

        public static EmployeeDataVM GetInstanse()
        {
            if (instance == null)
                instance = new EmployeeDataVM();
            return instance;
        }

        private EmployeeDataVM()
        {
            GetEmployee();
            SaveChanges = new OwnCommand(SetEmployee);
        }

        #endregion //Constructor


        #region Properties

        public List<Employee> DataGridEmployees { get; set; }
        public List<int> ids { get; set; }

        public OwnCommand SaveChanges { get; set; }

        #endregion //Properties

        #region Methods

        public void GetEmployee()
        {
            DataGridEmployees = EmployeeModel.GetEmployee();

            if (ids != null)
                ids.Clear();
            ids = DataGridEmployees.Select(x => x.Id).ToList();
        }

        public void SetEmployee()
        {
            EmployeeModel.SetEmployee(DataGridEmployees, ids);
            GetEmployee();
        }

        #endregion //Methods

    }
}
