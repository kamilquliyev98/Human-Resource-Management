using HumanResourceManagement.Models;
using HumanResourceManagement.Services;
using HumanResourceManagement.Interfaces;
using System;

namespace HumanResourceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager hrManager = new HumanResourceManager();

            do
            {
                Console.WriteLine("------------------Human Resource Management------------------");
                Console.WriteLine("Etmek istediyniz emeliyyatin qarsisindaki nomreni daxil edin:\n");
                Console.WriteLine("\t1 - Departamentlerin siyahisini goster");
                Console.WriteLine("\t2 - Departament yarat");
                Console.WriteLine("\t3 - Departamentde deyisiklik et");
                Console.WriteLine("\t4 - Iscilerin siyahisini goster");
                Console.WriteLine("\t5 - Departamentdeki iscilerin siyahisini goster");
                Console.WriteLine("\t6 - Isci elave et");
                Console.WriteLine("\t7 - Isci uzerinde deyisiklik et");
                Console.WriteLine("\t8 - Departamentdeki iscini sil");
                Console.Write("\n\tDaxil Et: ");

                string enteredNum = Console.ReadLine();
                int checkNum;
                int.TryParse(enteredNum, out checkNum);

                switch (checkNum)
                {
                    case 1:
                        Console.Clear();
                        GetDepartmentsList(ref hrManager);
                        break;
                    case 2:
                        Console.Clear();
                        AddDepartment(ref hrManager);
                        break;
                    case 3:
                        Console.Clear();
                        EditDepartment(ref hrManager);
                        break;
                    case 4:
                        Console.Clear();
                        GetDepartmentsList(ref hrManager);
                        break;
                    case 5:
                        Console.Clear();
                        GetDepartmentsList(ref hrManager); // By Department
                        break;
                    case 6:
                        Console.Clear();
                        AddEmployee(ref hrManager);
                        break;
                    case 7:
                        Console.Clear();
                        EditEmployee(ref hrManager);
                        break;
                    case 8:
                        Console.Clear();
                        RemoveEmployee(ref hrManager);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun daxil edin...");
                        break;
                }
            } while (true);

        }

        private static void AddEmployee(ref HumanResourceManager hrManager)
        {
            Console.WriteLine("Elave etmek istediyiniz iscinin ad ve soyadini daxil edin: ");
        reenterfullname:
            string fullname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Ad ve soyadi duzgun daxil edin...");
                goto reenterfullname;
            }

            Console.WriteLine("\nIscinin vezifesini daxil edin: ");
        reenterpositionname:
            string posName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(posName))
            {
                Console.WriteLine("Vezife adini duzgun qeyd edin...");
                goto reenterpositionname;
            }

            Console.WriteLine("\nElave etmek istediyiniz iscinin ayliq maasini daxil edin: ");
        checkSalary:
            string workersalary = Console.ReadLine();
            double workersalaryNum = 0;
            while (!double.TryParse(workersalary, out workersalaryNum) || workersalaryNum < 250)
            {
                Console.WriteLine("Meblegi duzgun daxil edin...");
                goto checkSalary;
            }

            Console.WriteLine("\nIscini elave etmek istediyiniz departament adini daxil edin: ");
        reenterdname:
            string departmentname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Ad ve soyadi duzgun daxil edin...");
                goto reenterdname;
            }

            hrManager.AddEmployee(fullname, posName, workersalaryNum, departmentname);
        }

        private static void AddDepartment(ref HumanResourceManager hrManager)
        {
            Console.WriteLine("Departament adini daxil edin: ");
            string departmentname = Console.ReadLine();

            Console.WriteLine("Departamentde maximum var ola bilecek isci sayini daxil edin: ");
        checkWorkerLimit:
            string workers = Console.ReadLine();
            int workersNum = 0;
            while (!int.TryParse(workers, out workersNum) || workersNum < 1)
            {
                Console.WriteLine("Isci sayini duzgun daxil edin...");
                goto checkWorkerLimit;
            }

            Console.WriteLine("Departamentde butun iscilere verilecek ayliq cemi meblegi daxil edin: ");
        checkSalaryLimit:
            string salary = Console.ReadLine();
            double salaryNum = 0;
            while (!double.TryParse(salary, out salaryNum) || salaryNum < 250)
            {
                Console.WriteLine("Meblegi duzgun daxil edin...");
                goto checkSalaryLimit;
            }

            hrManager.AddDepartment(departmentname,workersNum,salary);
        }

        static void GetDepartmentsList(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length > 0)
            {
                foreach (Department item in hrManager.Departments)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Departament movcud deyil. Departament daxil edin.");
            }
        }

        static void EditDepartment(ref HumanResourceManager hrManager)
        {

        }

        static void EditEmployee(ref HumanResourceManager hrManager)
        {

        }

        static void RemoveEmployee(ref HumanResourceManager hrManager)
        {

        }

    }
}
