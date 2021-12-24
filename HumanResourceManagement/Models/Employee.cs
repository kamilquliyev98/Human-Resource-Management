using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Employee
    {
        private int Counter = 1000;
        public string No { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; } // min 2 herf
        public double Salary { get; set; } // >= 250

        public Employee(string fullname, string position, string salary)
        {

        }











        //public Department DepartmentName { get; set; }

        //public Employee(string fullname, string position, string salary, Department[] departmentName)
        //{
        //    string[] full = fullname.Split(' ');
        //    while (!(full.Length < 2))
        //    {
        //        Console.WriteLine("Ad ve Soyadi tam daxil edin...");
        //    }

        //    Array.Resize(ref departmentName, departmentName.Length + 1);

        //}
    }
}
