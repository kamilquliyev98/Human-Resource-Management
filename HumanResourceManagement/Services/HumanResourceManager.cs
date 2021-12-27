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
        } // done

        public void EditDepartment(string name, string newName)
        {
            bool checker = true;
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    item.Name = newName;
                    Console.Clear();
                    Console.WriteLine("Departament adinda deyisiklik edildi.\n");
                    checker = false;
                    break;
                }
            }

            if (checker)
            {
                Console.WriteLine("Daxil etdiyiniz adda departament movcud deyil.");
                return;
            }
        } // done

        public void GetEmployeeListByDepartmentName(string dpname)
        {
            foreach (Employee item in _employees)
            {
                if (item.DepartmentName.ToLower() == dpname.ToLower())
                {
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------");
                }
            }
        }

        public void AddEmployee(string fullname, string position, double salary, string departmentName)
        {
            Employee employee = new Employee(fullname, position, salary, departmentName);
            Array.Resize(ref _employees, _employees.Length + 1);
            _employees[_employees.Length - 1] = employee;
        } // done

        public void EditEmployee(string no, string fullname, double salary, string position)
        {
            Employee employee = null;

            foreach (Employee item in _employees)
            {
                if (item.No == no)
                {
                    employee = item;
                    break;
                }

                employee.Fullname = fullname;
                employee.Salary = salary;
                employee.Position = position;
            }
        } // done

        public void RemoveEmployee(string no, string departmentName)
        {
            throw new NotImplementedException();
        }
    }
}
