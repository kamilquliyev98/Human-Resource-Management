using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Interfaces
{
    interface IHumanResourceManager
    {
        Employee[] Employees { get; }
        Department[] Departments { get; }

        void AddDepartment(string name, int workerLimit, double salaryLimit);
        void AddEmployee(string fullname, string position, double salary, string departmentName);
        void EditDepartment(string name, string newName);
        void EditEmployee(string no, /*string fullname,*/ double salary, string position);
        void GetEmployeeListByDepartmentName(string dpname);
    }
}
