using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO.netEmployeePayRollService
{
    public class EmployeeRepository
    {
        public static string connectionString = @"Server=(localdb)\MSSQLLocalDB,Initial Catalog=ADO.net_employee_payroll";

        //Created Connection object with the datebase
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    }
}
