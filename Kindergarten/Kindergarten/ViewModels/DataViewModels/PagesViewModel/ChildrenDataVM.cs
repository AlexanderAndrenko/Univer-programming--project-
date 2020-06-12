using Kindergarten.Models;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DataGridChildren = new List<Children>();
            IsRangeDate = false;
            ShowButton = new OwnCommand(GetChildrenData);
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

        public List<Children> _dataGridChildren;
        public List<Children> DataGridChildren 
        { 
            get => _dataGridChildren; 
            set 
            {
                _dataGridChildren = value;
                RaisePropertyChanged();
            } 
        }
        public OwnCommand ShowButton { get; set; }
        #endregion //Properties

        #region Method
        public void GetChildrenData()
        {
            if (EndDate == null)
                EndDate = StartDate;
            DataGridChildren = new List<Children>(ChildrenModel.GetChildrenData(StartDate, EndDate));
        }

        #endregion //Method
    }

}
