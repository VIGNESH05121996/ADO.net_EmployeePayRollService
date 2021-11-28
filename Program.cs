using System;

namespace ADO.netEmployeePayRollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To ADO.net Employee Pay Roll Service");
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.GetAllEmployee();
        }
    }
}
