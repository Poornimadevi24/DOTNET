using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem
{
    class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            string conStr = "server=(localdb)\\MSSQLLocalDB;database=TrainReservationDB;integrated security=true";
            return new SqlConnection(conStr);
            
        }
    }
}
