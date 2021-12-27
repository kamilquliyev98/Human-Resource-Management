using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Employee[] Employees => _employees;
        private Employee[] _employees;

        public Department[] Departments => _departments;
        private Department[] _departments;

        public HumanResourceManager()
        {
            _employees = new Employee[0];
            _departments = new Department[0];
        }

        public void AddDepartment(string name, int workerLimit, double salaryLimit)
        {
            Department department = new Department(name, workerLimit, salaryLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }
        public void AddEmployee(string fullname, string position, double salary, string departmentName)
        {
            Employee employee = new Employee(fullname, position, salary, departmentName);
            Array.Resize(ref _employees, _employees.Length + 1);
            _employees[_employees.Length - 1] = employee;
        }
        public void EditDepartment(string name, string newName)
        {
            Department department = null;

            bool edit = true;
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    department.Name = newName;
                    Console.Clear();
                    Console.WriteLine("Departament adinda deyisiklik edildi.\n");
                    edit = false;
                    break;
                }
            }

            if (edit)
            {
                Console.WriteLine("Daxil etdiyiniz adda departament movcud deyil.\n");
                return;
            }
        }
        public void EditEmployee(string no, /*string fullname,*/ double salary, string position)
        {
            Employee employee = null;

            employee.Salary = salary;
            employee.Position = position;

            Console.WriteLine("Duzelis edildi...\n");
        }
        public void GetEmployeeListByDepartmentName(string dpname)
        {
            bool check = true;
            foreach (Employee item in _employees)
            {
                if (item.DepartmentName.ToLower() == dpname.ToLower())
                {
                    check = false;
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------");
                }
            }
            if (check)
            {
                Console.Clear();
                Console.WriteLine("Daxil etdiyiniz departament adi movcud deyil.\n");
            }
        }
    }
}
