using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Department
    {
        public string Name { get; set; } // min 2 herf
        public int? WorkerLimit { get; set; } // min 1 nefer
        public double SalaryLimit { get; set; } // >= 250
        private Employee[] Employees;
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

        public Department(string name, int workerLimit, double salaryLimit)
        {
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
        }

        public override string ToString()
        {
            return $"Departanent adi: {Name}\nIsci sayi limiti: {WorkerLimit}\nIsci maasi limiti: {SalaryLimit}\n";
        }
    }
}
