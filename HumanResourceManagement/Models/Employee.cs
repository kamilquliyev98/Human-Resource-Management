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
        public string DepartmentName { get; set; }

        public Employee(string fullname, string position, double salary, string departmentName)
        {
            Counter++;
            Fullname = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentName;

            string Naming = departmentName.ToUpper().Substring(0, 2);

            No += Naming + Counter;
        }

        public override string ToString()
        {
            return $"Fullname: {Fullname}\nPosition: {Position}\nSalary: {Salary}\nDepartment: {DepartmentName}\nWorker number: {No}";
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
