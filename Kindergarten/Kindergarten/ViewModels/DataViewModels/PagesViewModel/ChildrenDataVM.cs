using Kindergarten.Models;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.Models.Entities;
using Kindergarten.Views;
using Kindergarten.ViewModels.DataViewModels.PagesViewModel;
using Kindergarten.Views.Data.Pages;

namespace Kindergarten.ViewModels.DataViewModels
{
    class ChildrenDataVM : BaseVM
    {
        #region Constructor
        private static ChildrenDataVM instance;

        public static ChildrenDataVM GetInstanse()
        {
            if (instance == null)
                instance = new ChildrenDataVM();
            return instance;
        }

        private ChildrenDataVM()
        {
            DataGridChildren = new List<NumberChildren>();
            IsRangeDate = false;
            ShowButton = new OwnCommand(GetChildrenData);
            SaveChanges = new OwnCommand(SetChangesNumberChildren);
            StartDate = System.DateTime.Now;
        }
        #endregion //Constructor

        #region Properties

        private bool _isRangeDate;
        public bool IsRangeDate 
        { 
            get => _isRangeDate;
            set 
            {
                _isRangeDate = value;
                RaisePropertyChanged();
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<NumberChildren> _dataGridChildren;
        public List<NumberChildren> DataGridChildren 
        { 
            get => _dataGridChildren; 
            set 
            {
                _dataGridChildren = value;
                RaisePropertyChanged();
            } 
        }
        public OwnCommand ShowButton { get; set; }

        public OwnCommand SaveChanges { get; set; }
        #endregion //Properties

        #region Method
        public void GetChildrenData()
        {
            if (EndDate.Date == new DateTime(0001,01,01))
                EndDate = StartDate;
            var children = new List<NumberChildren>(ChildrenModel.GetChildrenData(StartDate, EndDate));
            if (children != null)
            {
                DataGridChildren = children;
            }
        }

        public void SetChangesNumberChildren()
        {
            ChildrenModel.SetChildrenData(DataGridChildren);
            //ChildrenAdd ca = new ChildrenAdd();
            //ca.Show();
        }

        #endregion //Method
    }

}
