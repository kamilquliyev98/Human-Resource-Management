using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Department
    {
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 2)
                {
                    return;
                }
                _name = value;
            }
        }
        private string _name;
        public int WorkerLimit
        {
            get
            {
                return _workerLimit;
            }
            set
            {
                if (value < 1)
                {
                    return;
                }
                _workerLimit = value;
            }
        }
        private int _workerLimit;
        public double SalaryLimit {
            get
            {
                return _salaryLimit;
            }
            set
            {
                if (value < 250)
                {
                    return;
                }
                _salaryLimit = value;
            }
        }
        private double _salaryLimit;
        public Employee[] Employees;
        public double CalcSalaryAverage()
        {
            double total = 0;
            int counter = 0;

            foreach (Employee item in Employees)
            {
                if (item != null)
                {
                    total += item.Salary;
                    counter++;
                }
            }
            return total / counter;
        }

        public Department(string name, int workerLimit, double salaryLimit)
        {
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;

            Employees = new Employee[0];
        }

        public override string ToString()
        {
            return $"Departament adi: {Name}\nIsci sayi limiti: Max {WorkerLimit} nefer\nIscilerin maas limiti: Max {SalaryLimit} AZN / ay";
        }
    }
}
