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
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=employee_payroll_service;Integrated Security=True";

        //Created Connection object with the datebase
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        //Retrive All Employee Details
        public void GetAllEmployee()
        {
            try
            {

                EmployeeModel model = new EmployeeModel();
                string query = @"select * from emppayroll_table"; //query for fetching the data Base
                SqlCommand command = new SqlCommand(query, sqlConnection); //command object to execute query on dataBase
                this.sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) //command to check rows present or not in selected dataBase
                {
                    while (reader.Read()) //if present then read row
                    {
                        model.EmployeeID = Convert.ToInt32(reader["id"] == DBNull.Value ? default : reader["id"]);
                        model.EmployeeName = Convert.ToString(reader["name"] == DBNull.Value ? default : reader["name"]);
                        model.Salary = Convert.ToDouble(reader["salary"] == DBNull.Value ? default : reader["salary"]);
                        model.StartDate =Convert.ToDateTime(reader["startDate"] == DBNull.Value ? default : reader["startDate"]);
                        model.Gender = Convert.ToString(reader["Gender"] == DBNull.Value ? default : reader["Gender"]);
                        model.PhoneNumber = Convert.ToInt32(reader["PhoneNumber"] == DBNull.Value ? default : reader["PhoneNumber"]);
                        model.Address = Convert.ToString(reader["Address"] == DBNull.Value ? default : reader["Address"]);
                        model.Department = Convert.ToString(reader["Department"] == DBNull.Value ? default : reader["Department"]);
                        model.BasicPay = Convert.ToDouble(reader["Basic_pay"] == DBNull.Value ? default : reader["Basic_pay"]);
                        model.Deduction = Convert.ToDouble(reader["Deduction"] == DBNull.Value ? default : reader["Deduction"]);
                        model.TaxablePay = Convert.ToDouble(reader["Taxable_Pay"] == DBNull.Value ? default : reader["Taxable_Pay"]);
                        model.IncomeTax = Convert.ToDouble(reader["Income_Tax"] == DBNull.Value ? default : reader["Income_Tax"]);
                        model.Netpay = Convert.ToDouble(reader["Net_Pay"] == DBNull.Value ? default : reader["Net_Pay"]);

                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", model.EmployeeID, model.EmployeeName, model.Salary, model.StartDate, model.Gender, model.PhoneNumber, model.Address, model.Department, model.BasicPay, model.Deduction, model.TaxablePay, model.IncomeTax, model.Netpay);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        //Add salary i.e basepay of Terrisa
        public void AddEmployeeSalary(EmployeeModel model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("dbo.spAddEmployeeDetails", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.EmployeeName);
                    command.Parameters.AddWithValue("@Basic_pay", model.BasicPay);
                    command.Parameters.AddWithValue("@startDate", model.StartDate);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    sqlConnection.Open();
                    var result = command.ExecuteNonQuery();
                    if(result==0)
                    {
                        Console.WriteLine("No Data Added");
                    }
                    else
                    {
                        Console.WriteLine("Employee Data Added");
                    }
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Updata salary
        public void UpdateSalary(EmployeeModel model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("dbo.spUpdateEmployeeDetails", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.EmployeeName);
                    command.Parameters.AddWithValue("@Basic_Pay", model.BasicPay);
                    sqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if(result==0)
                    {
                        Console.WriteLine("Updated Sucessfully");
                    }
                    else
                    {
                        Console.WriteLine("Unsucessful");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
