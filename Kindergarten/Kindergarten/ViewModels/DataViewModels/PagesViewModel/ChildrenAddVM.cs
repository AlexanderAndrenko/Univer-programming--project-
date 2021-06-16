using Kindergarten.Models;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    public class ChildrenAddVM
    {
        private static ChildrenAddVM instance;

        public static ChildrenAddVM GetInstance()
        {
            if (instance == null)
                instance = new ChildrenAddVM();
            return instance;
        }
        private ChildrenAddVM()
        {
            SetDataChildren = new OwnCommand(SetData);
        }

        public OwnCommand SetDataChildren { get; set; }

        public DateTime Date { get; set; }
        public int QuantityYard { get; set; }
        public int QuantityNursery { get; set; }
        public void SetData()
        {
            ChildrenModel.SetChildrenData(Date, QuantityYard, QuantityNursery);
        }
    }
}
