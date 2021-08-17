using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    class ProductsDataVM : BaseVM
    {
        #region Constructor
        private static ProductsDataVM instanse;

        public static ProductsDataVM GetInstanse()
        {
            if (instanse == null)
                instanse = new ProductsDataVM();
            return instanse;
        }

        private ProductsDataVM()
        {
            GetProduct();
            SaveChanges = new OwnCommand(SetProduct);            
        }
        #endregion //Constructor

        #region Properties

        List<Product> DataGridProducts { get; set; }

        List<int> Ids { get; set; }

        public OwnCommand SaveChanges { get; set; }

        #endregion //Properties

        #region Methods

        public void GetProduct()
        {
            DataGridProducts = ProductsModel.GetProducts();
            if (Ids != null)
                Ids.Clear();
            Ids = DataGridProducts.Select(x => x.Id).ToList();
        }

        public void SetProduct()
        {
            ProductsModel.SetProducts(DataGridProducts, Ids);
            GetProduct();
        }

        #endregion //Methods
    }
}
