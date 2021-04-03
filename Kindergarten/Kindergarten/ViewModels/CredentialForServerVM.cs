using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.ViewModels
{
    class CredentialForServerVM
    {
        public string Login { private get; set; }
        public string Password { private get; set; }
        public string DataSource { get; set; }
        public string DataBase { get; set; }
    }
}
