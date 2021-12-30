using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Employee
    {
        private static int _counter = 1000;
        public string No { get; set; }
        public string Fullname {
            get
            {
                return _fullname;
            }
            set
            {
                string[] array = value.Split(' ');
                if (array.Length < 2)
                {
                    return;
                }
                _fullname = value;
            }
        }
        private string _fullname;
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value.Length < 2)
                {
                    return;
                }
                _position = value;
            }
        }
        private string _position;
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 250)
                {
                    return;
                }
                _salary = value;
            }
        }
        private double _salary;
        public string DepartmentName { get; set; }

        public Employee(string fullname, string position, double salary, string departmentname)
        {
            Fullname = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname;
            _counter++;
            No += departmentname.ToUpper().Substring(0, 2) + _counter;
        }

        public override string ToString()
        {
            return $"Ad soyad: {Fullname}\nVezife: {Position}\nMaas: {Salary} AZN\nDepartament adi: {DepartmentName}\nIscinin nomresi: {No}";
        }
    }
}
