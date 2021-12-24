using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Department
    {
        public string Name { get; set; } // min 2 herf
        public int WorkerLimit { get; set; } // min 1 nefer
        public double SalaryLimit { get; set; } // >= 250
        //public void CalcSalaryAverage() { }


    }
}
