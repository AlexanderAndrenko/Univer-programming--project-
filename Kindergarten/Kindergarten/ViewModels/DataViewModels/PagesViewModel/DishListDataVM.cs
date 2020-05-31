using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kindergarten.ViewModels.DataViewModels
{
    public class DishListDataVM : BaseVM
    {
        public DishListDataVM()
        {
            Text = "Страница блюд.";
        }

        private string text;
        public string Text
        {
            get => text;
            set
            {
                text = value;
                RaisePropertyChanged();
            }
        }
    }
}
