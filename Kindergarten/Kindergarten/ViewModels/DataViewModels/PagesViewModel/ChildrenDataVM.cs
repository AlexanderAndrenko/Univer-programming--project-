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
            ListDay = DateCollections.Day;
            ListMounth = DateCollections.Mounth;
            ListYear = DateCollections.Year;
            SelectedDay = "*";
            SelectedMounth = "*";
            SelectedYear = "*";
            DataGridChildren = new List<Children>(null);
            ShowButton = new OwnCommand(GetChildrenData);
        }
        #endregion //Constructor

        #region Properties
        public List<string> ListDay { get; private set; }
        public List<string> ListMounth { get; private set; }
        public List<string> ListYear { get; private set; }
        public string SelectedDay { get; set; }
        public string SelectedMounth { get; set; }
        public string SelectedYear { get; set; }        
        public List<Children> DataGridChildren 
        { 
            get => DataGridChildren; 
            set 
            {
                DataGridChildren = value;
                RaisePropertyChanged();
            } 
        }
        public OwnCommand ShowButton { get; set; }
        #endregion //Properties

        #region Method
        public void GetChildrenData()
        {
            DataGridChildren = new List<Children>(ChildrenModel.GetChildrenData(SelectedDay, SelectedMounth, SelectedYear));
        }

        #endregion //Method
    }

}
