using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.ViewModels.DataViewModels
{
    class ChildrenDataVM : BaseVM
    {
        public ChildrenDataVM()
        {
            Text = "Страница детей.";
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
