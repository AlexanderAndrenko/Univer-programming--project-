using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.ViewModels
{
    public class Account
    {
        public Account()
        {

        }

        public string Login { get; set; }

        #region ???
        private int accessLevel;//Уровень доступа в программе
        public int AccessLevel
        {
            get => accessLevel;
            set { }
        }

        private string name;//Имя
        public string Name
        {
            get => name;
            set { }
        }

        private string surname;//Фамилия
        public string Surname
        {
            get => surname;
            set { }
        }

        private string patronymic;//Отчество
        public string Patronymic
        {
            get => patronymic;
            set { }
        }
        #endregion //???
    }
}
