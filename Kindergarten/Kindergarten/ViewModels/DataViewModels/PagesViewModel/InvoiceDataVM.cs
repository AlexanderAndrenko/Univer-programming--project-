using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using Kindergarten.Views.Data.Pages;
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
            Refresh = new OwnCommand(GetInvoice);
            NewInvoice = new OwnCommand(OpenWindowCreateNewInvoice);
            
        }
        #endregion //Contructor

        #region Properties

        public List<Invoice> DataGridInvoice { get; set; }

        private DateTime startDate;
        public DateTime StartDate 
        { 
            get => startDate;
            set
            {
                startDate = value;
                RaisePropertyChanged();
            } 
        }

        private DateTime endDate;
        public DateTime EndDate 
        { 
            get => endDate; 
            set
            {
                endDate = value;
                RaisePropertyChanged();
            }
        }

        public OwnCommand DoubleClickInvoice { get; set; }
        public OwnCommand NewInvoice { get; set; }
        public OwnCommand Refresh { get; set; }

        #endregion //Properties

        #region Method

        public void GetInvoice()
        {
            DataGridInvoice = InvoiceModel.GetInvoice(StartDate, EndDate);
        }

        public void OpenWindowCreateNewInvoice()
        {
            InvoiceCreateNew nw = new InvoiceCreateNew();
            nw.Show();
        }



        #endregion //Method
    }
}
