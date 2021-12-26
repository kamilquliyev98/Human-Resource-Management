using HumanResourceManagement.Models;
using HumanResourceManagement.Services;
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

                string enter = Console.ReadLine();
                int checkEnter;
                int.TryParse(enter, out checkEnter);

                switch (checkEnter)
                {
                    case 1:
                        Console.Clear();
                        GetDepartmentsList(ref hrManager); // hazir
                        break;
                    case 2:
                        Console.Clear();
                        AddDepartment(ref hrManager); // hazir
                        break;
                    case 3:
                        Console.Clear();
                        EditDepartment(ref hrManager);
                        break;
                    case 4:
                        Console.Clear();
                        GetEmployeeList(ref hrManager); // hazir
                        break;
                    case 5:
                        Console.Clear();
                        GetEmployeeListByDepartmentName(ref hrManager);
                        break;
                    case 6:
                        Console.Clear();
                        AddEmployee(ref hrManager); // hazir
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

        static void AddEmployee(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length <= 0)
            {
                Console.WriteLine("Cari departament bazasi bosdur. Ilk once departament yaratmalisiniz.");
                return;
            }

            Console.WriteLine("Elave etmek istediyiniz iscinin ad ve soyadini daxil edin: ");
        reEnterFullname:
            string fullname = Console.ReadLine();
            string[] full = fullname.Split(' ');
            if (String.IsNullOrWhiteSpace(fullname) || full.Length < 2 || full[0].Length < 3 || full[1].Length < 5)
            {
                Console.WriteLine("Ad ve soyadi duzgun daxil edin...");
                goto reEnterFullname;
            }

            Console.WriteLine("\nIscinin vezifesini daxil edin: ");
        reEnterPositionName:
            string positionName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(positionName))
            {
                Console.WriteLine("Vezife adini duzgun qeyd edin...");
                goto reEnterPositionName;
            }

            Console.WriteLine("\nElave etmek istediyiniz iscinin ayliq maasini daxil edin: ");
        reEnterSalary:
            string salary = Console.ReadLine();
            double checkSalary = 0;
            while (!double.TryParse(salary, out checkSalary) || checkSalary < 250)
            {
                Console.WriteLine("Meblegi duzgun daxil edin...");
                goto reEnterSalary;
            }

            Console.WriteLine("\nIscini elave etmek istediyiniz departament adini daxil edin: ");
        reEnterDepartmentName:
            string departmentName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(departmentName))
            {
                Console.WriteLine("Departament adini duzgun daxil edin...");
                goto reEnterDepartmentName;
            }

            foreach (Department item in hrManager.Departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine("Isci elave olundu...\n");
                }
                else
                {
                    Console.WriteLine("Daxil etdiyiniz departament adi yanlisdir. Duzgun daxil edin: ");
                    goto reEnterDepartmentName;
                }
            }

            hrManager.AddEmployee(fullname, positionName, checkSalary, departmentName);
        }

        static void AddDepartment(ref HumanResourceManager hrManager)
        {
            Console.WriteLine("Departament adini daxil edin: ");
        reEnterDepartmentName:
            string departmentname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(departmentname))
            {
                Console.WriteLine("Departament adini duzgun daxil edin...");
                goto reEnterDepartmentName;
            }

            Console.WriteLine("\nDepartamentde maximum var ola bilecek isci sayini daxil edin: ");
        checkWorkerLimit:
            string workers = Console.ReadLine();
            int workersNum = 0;
            while (!int.TryParse(workers, out workersNum) || workersNum < 1)
            {
                Console.WriteLine("Isci sayini duzgun daxil edin...");
                goto checkWorkerLimit;
            }

            Console.WriteLine("\nDepartamentde butun iscilere verilecek ayliq cemi meblegi daxil edin: ");
        checkSalaryLimit:
            string salary = Console.ReadLine();
            double salaryNum = 0;
            while (!double.TryParse(salary, out salaryNum) || salaryNum < 250)
            {
                Console.WriteLine("Meblegi duzgun daxil edin...");
                goto checkSalaryLimit;
            }

            hrManager.AddDepartment(departmentname, workersNum, salaryNum);
        }

        static void GetEmployeeList(ref HumanResourceManager hrManager)
        {
            if (hrManager.Employees.Length > 0)
            {
                foreach (Employee item in hrManager.Employees)
                {
                    Console.WriteLine($"{item}\n");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Isci movcud deyil. Ilk once isci elave edin.\n");
            }
        }

        static void GetEmployeeListByDepartmentName(ref HumanResourceManager hrManager)
        {

        }

        static void GetDepartmentsList(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length > 0)
            {
                foreach (Department item in hrManager.Departments)
                {
                    Console.WriteLine($"{item}\n");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Departament movcud deyil. Departament daxil edin.\n");
            }
        }

        static void EditDepartment(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length <= 0)
            {
                Console.WriteLine("Hec bir departament movcud deyil...\n");
                return;
            }

            Console.WriteLine("Departamentlerin siyahisi:");
            Console.WriteLine("------------------------------");
            foreach (Department item in hrManager.Departments)
            {
                Console.WriteLine($"{item}------------------------------");
            }

            Console.WriteLine("\nDeyisiklik etmek istediyiniz departamentin adini daxil edin: ");
        reEnterNameNow:
            string nameNow = Console.ReadLine();  // deyismek istediyi ad
            if (String.IsNullOrWhiteSpace(nameNow))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterNameNow;
            }

            foreach (Department item in hrManager.Departments)
            {
                if (item.Name.ToLower() == nameNow.ToLower())
                {
                    Console.WriteLine("Secdiyiniz departament adini hansi ada deyismek isteyirsiniz? Daxil edin: ");
                reEnterNewName:
                    string newName = Console.ReadLine(); // neye deyisecek

                    if (String.IsNullOrWhiteSpace(newName))
                    {
                        Console.WriteLine("Duzgun daxil edin:");
                        goto reEnterNewName;
                    }

                    //if (nameNow.ToLower() == newName.ToLower())
                    //{
                    //    Console.WriteLine("Deyisdirmek istediyiniz ad cari adla eyni ola bilmez...\nDuzgun daxil edin:");
                    //    goto reEnterNewName;
                    //}

                    item.Name = newName;
                    break;
                }
                Console.WriteLine("Daxil etdiyiniz adda departament movcud deyil. Duzgun daxil edin: ");
                goto reEnterNameNow;
            }
        }

        static void EditEmployee(ref HumanResourceManager hrManager)
        {
            if (hrManager.Employees.Length <= 0)
            {
                Console.WriteLine("Hec bir isci movcud deyil...\n");
                return;
            }

            Console.WriteLine("Iscilerin siyahisi:");
            Console.WriteLine("------------------------------");
            foreach (Employee item in hrManager.Employees)
            {
                Console.WriteLine($"{item}\n------------------------------");
            }

            Console.WriteLine("\nDeyisiklik etmek istediyiniz iscinin nomresini daxil edin: ");
        reEnterWorkerNo:
            string workerNo = Console.ReadLine();  // deyismek istediyiniz iscinin nomresi
            if (String.IsNullOrWhiteSpace(workerNo))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterWorkerNo;
            }

            foreach (Employee item in hrManager.Employees)
            {
                if (item.No.ToLower() == workerNo.ToLower())
                {
                    Console.WriteLine("Etmek istediyiniz emeliyyatin qarsisindaki nomreni daxil edin:\n");
                    Console.WriteLine("\t1 - Iscinin aldigi maasda duzelis etmek");
                    Console.WriteLine("\t2 - Iscinin vezifesinde duzelis etmek");

                    reEnterEditWorker:
                    string editWorker = Console.ReadLine();
                    int editWorkerNum = 0;
                    if (!int.TryParse(editWorker, out editWorkerNum))
                    {
                        Console.WriteLine("Duzgun daxil edin...");
                        goto reEnterEditWorker;
                    }

                    switch (editWorkerNum)
                    {
                        case 1:
                            Console.WriteLine("Iscinin yeni maasini daxil edin: ");

                        reEnternewSalary:
                            string newSalary = Console.ReadLine();
                            int newSalaryNum = 0;
                            if (!int.TryParse(newSalary, out newSalaryNum))
                            {
                                Console.WriteLine("Duzgun daxil edin...");
                                goto reEnternewSalary;
                            }

                            item.Salary = newSalaryNum;
                            Console.WriteLine("Maasda duzelis olundu...");
                            break;
                        case 2:
                            Console.WriteLine("Iscinin yeni vezifesini daxil edin: ");

                        reEnternewPosition:
                            string newPosition = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(newPosition))
                            {
                                Console.WriteLine("Duzgun daxil edin...");
                                goto reEnternewPosition;
                            }

                            item.Position = newPosition;
                            Console.WriteLine("Vezifede duzelis olundu...");
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Daxil etdiyiniz nomrede isci movcud deyil.\n");
                    return;
                }
            }
        }

        static void RemoveEmployee(ref HumanResourceManager hrManager)
        {
            Employee[] Employees = null;
            Employee[] newEmployees = new Employee[0];
            int counter = 0;
            foreach (Employee item in Employees)
            {
                Array.Resize(ref newEmployees, newEmployees.Length + 1);
                newEmployees[counter++] = item;
            }
            Employees = newEmployees;
        }
    }
}
