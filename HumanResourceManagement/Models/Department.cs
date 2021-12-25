using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Department
    {
        public string Name { get; set; } // min 2 herf
        public int WorkerLimit { get; set; } // min 1 nefer
        public double SalaryLimit { get; set; } // >= 250
        public Employee[] Employees { get; set; }
        public double CalcSalaryAverage(Department department)
        {
            double total = 0;
            int count = 0;

            foreach (Employee item in Employees)
            {
                total += item.Salary;
                count++;
            }
            return total / count;
        }

        public Department(Employee[] employees, string name, int workerLimit, double salaryLimit)
        {
            Employees = employees;
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
        }

    }
}
