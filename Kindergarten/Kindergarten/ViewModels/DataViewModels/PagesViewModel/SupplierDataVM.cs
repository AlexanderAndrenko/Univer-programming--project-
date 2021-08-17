using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    class SupplierDataVM : BaseVM
    {

        #region Constructor
        private static SupplierDataVM instanse;

        public static SupplierDataVM GetInstanse()
        {
            if (instanse == null)
                instanse = new SupplierDataVM();
            return instanse;
            
        }

        private SupplierDataVM()
        {

        }
        #endregion //Constructor

        #region Properties

        List<Supplier> DataGridSupplier { get; set; }
        List<int> Ids { get; set; }
        
        public OwnCommand SaveChanges { get; set; }

        #endregion //Properties

        #region Methods

        public void GetSupplier()
        {
            DataGridSupplier = SupplierModel.GetSupplier();
        }

        public void SetSupplier()
        {
            SupplierModel.SetSupplier();
            GetSupplier();
        }

        #endregion //Methods
    }
}
