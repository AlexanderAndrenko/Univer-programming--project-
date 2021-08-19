using Kindergarten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Kindergarten.Models;

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
        }

        #endregion //Constructor

        #region Properties

        public List<Party> DataGridParty { get; set; }

        #endregion //Properties

        #region Method

        public void GetParty()
        {
            DataGridParty = PartyModel.GetParty();
        }

        #endregion //Method
    }
}
