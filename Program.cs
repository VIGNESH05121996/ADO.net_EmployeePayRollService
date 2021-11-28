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

            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = "Terrisa";
            model.StartDate = DateTime.Now;
            model.Gender = "F";
            model.BasicPay = 3000000;
            employeeRepository.AddEmployeeSalary(model);
        }
    }
}
