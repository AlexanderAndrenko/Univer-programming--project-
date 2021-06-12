using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarten.Models
{
    class CredentialsForServer
    {
        public static string Login { get; set; } = "KindergartenAdmin";
        public static string Password { get; set; } = "admin12345";
        public static string DataSource { get; set; } = "ANDRENKO\\ANDRENKO";
        public static string DataBase { get; set; } = "StudyDB";
    }
}
