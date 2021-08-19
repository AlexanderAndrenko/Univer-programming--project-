using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    public class InvoiceDataVM : BaseVM
    {
        #region Contructor
        private static InvoiceDataVM instanse;

        public static InvoiceDataVM GetInstanse()
        {
            if (instanse == null)
                instanse = new InvoiceDataVM();
            return instanse;
        }
        private InvoiceDataVM()
        {
            EndDate = DateTime.Today;
            StartDate = DateTime.Today;
            StartDate.AddDays(-7);
            GetInvoice();
        }
        #endregion //Contructor

        #region Properties

        public List<Invoice> DataGridInvoice { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public OwnCommand NewInvoice { get; set; }

        #endregion //Properties

        #region Method

        public void GetInvoice()
        {
            DataGridInvoice = InvoiceModel.GetInvoice(StartDate, EndDate);
        }



        #endregion //Method
    }
}
