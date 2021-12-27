using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Employee
    {
        private static int _counter = 1000;
        public readonly int Counter;
        public string No { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; } // min 2 herf
        public double Salary { get; set; } // >= 250
        public string DepartmentName { get; set; }

        public Employee()
        {
            _counter++;
            Counter = _counter;
        }

        public Employee(string fullname, string position, double salary, string departmentName) : this()
        {
            Fullname = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;

            string Numbering = departmentName.ToUpper().Substring(0, 2);
            No += Numbering + Counter;
        }

        public override string ToString()
        {
            return $"Fullname: {Fullname}\nPosition: {Position}\nSalary: {Salary}\nDepartment: {DepartmentName}\nWorker number: {No}";
        }
    }
}
