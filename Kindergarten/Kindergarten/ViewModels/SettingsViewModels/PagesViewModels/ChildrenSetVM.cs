using Kindergarten.Models;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kindergarten.ViewModels.SettingsViewModels.PagesViewModels
{
    public class ChildrenSetVM : BaseVM
    {
        #region Constructor
        private static ChildrenSetVM instance;

        public static ChildrenSetVM GetInstance()
        {
            if (instance == null)
                instance = new ChildrenSetVM();
            return instance;
        }

        private ChildrenSetVM()
        {
            SetChildrenDataButton = new OwnCommand(SetChildrenData);
            DeleteChildrenDataButton = new OwnCommand(DeleteChildrenData);
            SetDate = System.DateTime.Now;
            Nursery = 0;
            Yard = 0;
        }
        #endregion //Constructor

        #region Fields        
        #endregion //Fields

        #region Properties
        public OwnCommand SetChildrenDataButton { get; set; }
        public OwnCommand DeleteChildrenDataButton { get; set; }
        public DateTime SetDate { get; set; }

        private int _nursery;
        public int Nursery
        {
            get => _nursery;
            set
            {
                _nursery = value;
                RaisePropertyChanged();
            }
        }

        private int _yard;
        public int Yard
        { 
            get => _yard;
            set 
            {
                _yard = value;
                RaisePropertyChanged();
            }
        }

        #endregion //Properties

        #region Methods
        public void SetChildrenData()
        {            
            //Children newData = new Children();
            //newData.Date = SetDate;
            //newData.Nursery = Nursery;
            //newData.Yard = Yard;
            //ChildrenModel.SetChildrenData(newData);
        }

        public void DeleteChildrenData()
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить данные " + SetDate.ToString() + " ?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                ChildrenModel.DeleteChildrenData(SetDate);
        }
        #endregion //Methods

    }
}
