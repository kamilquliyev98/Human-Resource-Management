using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;

        public HumanResourceManager()
        {
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
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    Employee employee = new Employee(fullname, position, salary, departmentName);
                    Array.Resize(ref item.Employees, item.Employees.Length + 1);
                    item.Employees[item.Employees.Length - 1] = employee;
                    break;
                }
            }
        }

        public void EditDepartament(string name, string newName)
        {
            foreach (Department department in _departments)
            {
                if (department.Name.ToLower() == name.ToLower())
                {
                    department.Name = newName;
                    foreach (Employee employee in department.Employees)
                    {
                        if (employee != null)
                        {
                            employee.DepartmentName = newName;
                            employee.No = employee.DepartmentName.ToUpper().Substring(0, 2) + employee.No.Remove(0, 2);
                        }
                    }
                    break;
                }
            }
        }

        public void EditEmployee(string employeeNo, string fullname, string position, double salary)
        {
            foreach (Department department in _departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    if (employee != null)
                    {
                        if ((employee.No.ToLower() == employeeNo.ToLower()) && (employee.Fullname.ToLower() == fullname.ToLower()))
                        {
                            if (position != null)
                            {
                                employee.Position = position;
                            }

                            if (salary != 0 && salary >= 250)
                            {
                                employee.Salary = salary;
                            }
                            break;
                        }
                    }
                }
            }
        }

        public Department[] GetDepartments()
        {
            if (_departments.Length <= 0)
            {
                return null;
            }
            return _departments;
        }

        public void RemoveEmployee(string employeeNo, string departmentName)
        {
            
        }

    }
}
