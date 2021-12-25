﻿using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Interfaces
{
    interface IHumanResourceManager
    {
        Employee[] Employees { get; }
        Department[] Departments { get; }

        Department[] GetDepartmentList(Department[] departments);
        void AddDepartment(Employee[] employees, string name, int workerLimit, double salaryLimit);
        void EditDepartment(string name, string newName);
        //Employee[] GetEmployeeList();
        Department[] GetEmployeeListByDepartmentName();
        void AddEmployee(string fullname, string position, double salary, string departmentName);
        void EditEmployee(string no, string fullname, double salary, string position);
        void RemoveEmployee(string no, string departmentName);
    }
}
