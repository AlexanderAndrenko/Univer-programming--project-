using Kindergarten.Models;
using Kindergarten.Models.Entities;
using Kindergarten.ViewModels.Commands;
using Kindergarten.Views.Data.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Document = Kindergarten.Models.Entities.Document;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    public class DocumentDataVM : BaseVM
    {
        #region Constructor
        private static DocumentDataVM instanse;

        public static DocumentDataVM GetInstanse()
        {
            if (instanse == null)
                instanse = new DocumentDataVM();
            return instanse;
        }
        private DocumentDataVM()
        {
            EndDate = DateTime.Today;
            StartDate = DateTime.Today;
            StartDate = StartDate.AddDays(-7);
            GetDocuments();
            ShowButton = new OwnCommand(GetDocuments);
            CreateExpenseForNutrition = new OwnCommand(CreateExpenseForNutritionWindow);
        }
        #endregion //Constructor

        #region Properties

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
        public OwnCommand ShowButton { get; set; }

        private List<Document> dataGridDocument;
        public List<Document> DataGridDocument 
        { 
            get => dataGridDocument;
            set
            {
                dataGridDocument = value;
                RaisePropertyChanged();
            } 
        }
        public OwnCommand CreateExpenseForNutrition { get; set; }

        #endregion //Properties

        #region Method

        public void GetDocuments()
        {
            DataGridDocument = DocumentModel.GetDocument(StartDate, EndDate);
        }

        public void CreateExpenseForNutritionWindow()
        {
            ExpenseForNutrition expenseForNutrition = new ExpenseForNutrition();
            expenseForNutrition.Show();

        }

        #endregion //Method

    }
}
