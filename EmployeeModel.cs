﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.netEmployeePayRollService
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public double PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }

        public double BasicPay { get; set; }
        public double Deduction { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double Netpay { get; set; }
        public DateTime StartDate { get; set; }
    }
}
