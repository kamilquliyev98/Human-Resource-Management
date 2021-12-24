using HumanResourceManagement.Models;
using HumanResourceManagement.Services;
using System;

namespace HumanResourceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager HRManager = new HumanResourceManager();

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
                        Console.WriteLine(1);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(2);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine(3);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine(4);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine(5);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine(6);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine(7);
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine(8);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun daxil edin...");
                        break;
                }
            } while (true);

        }

        //static void GetDepartmentList(ref HumanResourceManager HRManager)
        //{
        //    if (HRManager.Departments.Length <= 0)
        //    {
        //        Console.WriteLine("Siyahi bosdur. Once departament daxil edin.");
        //        return;
        //    }

        //    foreach (Department item in HRManager.Departments)
        //    {
        //        Console.WriteLine(item);
        //        Console.WriteLine("-----------------------------");
        //    }
        //}

        //static void GetEmployeeList()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
