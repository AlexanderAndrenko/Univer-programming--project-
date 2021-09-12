using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Kindergarten.Models;
using Kindergarten.ViewModels.Commands;

namespace Kindergarten.ViewModels.DataViewModels.PagesViewModel
{
    class PartyDataVM : BaseVM
    {
        #region Constructor
        private static PartyDataVM instanse;

        public static PartyDataVM GetInstanse()
        {
            if (instanse == null)
                instanse = new PartyDataVM();
            return instanse;
        }

        private PartyDataVM()
        {
            GetParty();
            RefrehData = new OwnCommand(GetParty);
        }

        #endregion //Constructor

        #region Properties

        private List<Party> dataGridParty;
        public List<Party> DataGridParty 
        { 
            get => dataGridParty;
            set
            {
                dataGridParty = value;
                RaisePropertyChanged();
            } 
        }
        public OwnCommand RefrehData { get; set; }

        #endregion //Properties

        #region Method

        public void GetParty()
        {
            DataGridParty = PartyModel.GetParty();
        }

        #endregion //Method
    }
}
