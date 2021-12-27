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
            Department department = null;

            foreach (Department item in _departments)
            {
                if (item.Name == name)
                {
                    department = item;
                    break;
                }
            }

            department.Name = newName;
        } // done

        public Employee[] GetEmployeeListByDepartmentName(string name)
        {
            throw new NotImplementedException();
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

        Department[] IHumanResourceManager.GetEmployeeListByDepartmentName()
        {
            throw new NotImplementedException();
        }
    }
}
