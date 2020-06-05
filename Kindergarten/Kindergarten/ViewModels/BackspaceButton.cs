using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.ViewModels
{
    public class BackspaceButton
    {
        private static BackspaceButton instance;
        public static BackspaceButton GetInstance()
        {
            if (instance == null)
                instance = new BackspaceButton();
            return instance;                        
        }

        private BackspaceButton()
        {
            backspaceButton = () => { };
            BackspaceButtonClick = new MenuItemDataCommand(Backspace_btn_click);
        }

        public delegate void BackspaceButtonDelegate();
        public event BackspaceButtonDelegate backspaceButton;
        private MenuItemDataCommand BackspaceButtonClick { get; set; }

        private void Backspace_btn_click()
        {
            backspaceButton();
        }
    }
}
