using System;

namespace ADO.netEmployeePayRollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To ADO.net Employee Pay Roll Service");
            EmployeeRepository employeeRepository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = "Tester";
            model.BasicPay = 40389.33;
            employeeRepository.UpdateSalary(model);
        }
    }
}
