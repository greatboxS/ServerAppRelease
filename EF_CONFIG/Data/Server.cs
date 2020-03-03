using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Data
{
    public class Server
    {
        public static string DefaultConnectionString { get; set; } = @"Data Source=DESKTOP-7N0K68V\SQLEXPRESS;Initial Catalog=__ECHECKING__;Integrated Security=True;";

        //public static string DefaultConnectionString { get; set; } = @"Data Source=VANNAM;Initial Catalog=__ECHECKING__;Integrated Security=True;";
    }
}
