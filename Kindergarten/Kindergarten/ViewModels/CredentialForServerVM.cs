using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarten.ViewModels.Commands;
using Kindergarten.Models;

namespace Kindergarten.ViewModels
{
    class CredentialForServerVM
    {
        private static CredentialForServerVM instance;

        public static CredentialForServerVM GetInstance()
        {
            if (instance == null)
                instance = new CredentialForServerVM();
            return instance;

        }

        private CredentialForServerVM()
        {
            //clickSaveButton += SetCredentials; на знаю зачем я всё это реализовывал
            SaveCredentialCommand = new CredentialCommand(SetCredentials);
        }


        public delegate void SaveCredential();
        public SaveCredential clickSaveButton;
        public string Login { private get; set; }
        public string Password { private get; set; }
        public string DataSource { get; set; }
        public string DataBase { get; set; }
        public CredentialCommand SaveCredentialCommand { get; private set; }

        public void SetCredentials()
        {
            CredentialsForServer.Login = Login;
            CredentialsForServer.Password = Password;
            CredentialsForServer.DataSource = DataSource;
            CredentialsForServer.DataBase = DataBase;
        }
    }
}
