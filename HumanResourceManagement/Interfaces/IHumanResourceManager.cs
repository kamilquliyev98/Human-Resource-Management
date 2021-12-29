using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Interfaces
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        void AddDepartment(string name, int workerLimit, double salaryLimit);
        Department[] GetDepartments();
        void EditDepartament(string name, string newName);
        void AddEmployee(string fullname, string position, double salary, string departmentName);
        void RemoveEmployee(string employeeNo, string departmentName);
        void EditEmployee(string employeeNo, string fullname, string position, double salary);
    }
}
