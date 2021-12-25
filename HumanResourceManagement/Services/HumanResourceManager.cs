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

        public Department[] GetDepartmentList(Department[] departments)
        {
            throw new NotImplementedException();
        }

        public void AddDepartment(Employee[] employees, string name, int workerLimit, double salaryLimit)
        {
            Department department = new Department(employees, name, workerLimit, salaryLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }

        public void EditDepartment(string name, string newName)
        {
            throw new NotImplementedException();
        }

        public Department[] GetEmployeeListByDepartmentName()
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(string fullname, string position, double salary, string departmentName)
        {
            Employee employee = new Employee(fullname, position, salary, departmentName);
            Array.Resize(ref _employees, _employees.Length + 1);
            _employees[_employees.Length - 1] = employee;
        }

        public void EditEmployee(string no, string fullname, double salary, string position)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(string no, string departmentName)
        {
            throw new NotImplementedException();
        }

        internal void AddDepartment(string departmentname, int workersNum, string salary)
        {
            throw new NotImplementedException();
        }
    }
}
