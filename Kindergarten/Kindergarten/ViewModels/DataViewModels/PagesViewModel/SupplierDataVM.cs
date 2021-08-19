using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
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
            GetSupplier();
            SaveChanges = new OwnCommand(SetSupplier);
        }
        #endregion //Constructor

        #region Properties

        public List<Supplier> DataGridSupplier { get; set; }
        private List<int> Ids { get; set; }
        
        public OwnCommand SaveChanges { get; set; }

        #endregion //Properties

        #region Methods

        public void GetSupplier()
        {
            DataGridSupplier = SupplierModel.GetSupplier();
            if (Ids != null)
                Ids.Clear();
            Ids = DataGridSupplier.Select(x => x.Id).ToList();
        }

        public void SetSupplier()
        {
            SupplierModel.SetSupplier(DataGridSupplier, Ids);
            GetSupplier();
        }

        #endregion //Methods
    }
}
