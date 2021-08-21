using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    public class InvoiceCreateNewVM : BaseVM
    {
        #region Constructor
        private static InvoiceCreateNewVM instanse;

        public static InvoiceCreateNewVM GetInstanse()
        {
            if (instanse == null)
                instanse = new InvoiceCreateNewVM();
            return instanse;
        }

        private InvoiceCreateNewVM()
        {
            DataGridProducts = new List<Party>();
            DateOfInvoice = DateTime.Today;
            ListProducts = ProductsModel.GetProducts();
            ListSuppliers = SupplierModel.GetSupplier();
            CreateNewInvoice = new OwnCommand(SaveInvoice);
        }
        #endregion //Constructor

        #region Properties

        private List<Party> dataGridProducts;
        public List<Party> DataGridProducts
        {
            get => dataGridProducts;
            set
            {
                dataGridProducts = value;
                RaisePropertyChanged();
            }
        }

        public List<Product> ListProducts { get; set; }
        public OwnCommand CreateNewInvoice { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public string NumberOfInvoice { get; set; }
        public Supplier Supplier {get;set;}

        public List<Supplier> ListSuppliers { get; set; }
        #endregion //Properties

        #region Methods

        public void SaveInvoice()
        {
            Invoice invoice = new Invoice();

            invoice.ID = 0;
            invoice.DateCreated = DateTime.Now;
            invoice.DateOfInvoice = DateOfInvoice;
            invoice.Supplier = Supplier;
            invoice.SupplierNumber = NumberOfInvoice;

            DataGridProducts.ForEach(x =>
            {
                x.Id = 0;
                x.DateCreated = DateTime.Now;
                x.IsClosed = false;
                x.IsDeleted = false;
                x.DateClosed = null;
            });


            InvoiceModel.SetInvoice(invoice, DataGridProducts);
        }

        #endregion// Methods

    }
}
