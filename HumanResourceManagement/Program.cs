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
                Console.WriteLine("\t2 - Yeni departament yarat");
                Console.WriteLine("\t3 - Departamentde deyisiklik et");
                Console.WriteLine("\t4 - Butun iscilerin siyahisini goster");
                Console.WriteLine("\t5 - Secilmis departamentdeki iscilerin siyahisini goster");
                Console.WriteLine("\t6 - Yeni isci elave et");
                Console.WriteLine("\t7 - Isci uzerinde deyisiklik et");
                Console.WriteLine("\t8 - Secilmis departamentdeki iscini sil");
                Console.Write("\n\tDaxil Et: ");

                string select = Console.ReadLine();
                int selectNum;
                int.TryParse(select, out selectNum);

                switch (selectNum)
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
                        GetEmployeeList(ref hrManager);
                        break;
                    case 5:
                        Console.Clear();
                        GetEmployeeListByDepartmentName(ref hrManager);
                        break;
                    case 6:
                        Console.Clear();
                        AddEmployee(ref hrManager);
                        break;
                    case 7:
                        Console.Clear();
                        EditEmployee(ref hrManager);
                        break;
                    //case 8:
                    //    Console.Clear();
                    //    RemoveEmployee(ref hrManager);
                    //    break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nomreni duzgun daxil edin...\n");
                        break;
                }
            } while (true);
        }

        static void AddDepartment(ref HumanResourceManager hrManager)
        {
            Console.WriteLine("Yaratmaq istediyiniz departamentin adini daxil edin: ");
        reEnterDepartmentName:
            string departmentname = Console.ReadLine();
            string dname = departmentname.ToString();
            if (String.IsNullOrWhiteSpace(dname) || dname.Length < 2)
            {
                Console.WriteLine("Departament adini duzgun daxil edin...");
                goto reEnterDepartmentName;
            }

            foreach (Department item in hrManager.Departments)
            {
                if (item.Name.ToLower() == dname.ToLower())
                {
                    Console.WriteLine("Daxil etdiyiniz adda departament artiq movcuddur...\n");
                    return;
                }
            }

            Console.WriteLine("\nDepartamentde maximum var ola bilecek isci sayini daxil edin: ");
        checkWorkerLimit:
            string workers = Console.ReadLine();
            int workersNum;
            while (!int.TryParse(workers, out workersNum) || workersNum < 1)
            {
                Console.WriteLine("Isci sayini duzgun daxil edin...");
                goto checkWorkerLimit;
            }

            Console.WriteLine("\nDepartamentde butun iscilere verilecek ayliq cemi meblegi daxil edin: ");
        checkSalaryLimit:
            string salary = Console.ReadLine();
            double salaryNum;
            while (!double.TryParse(salary, out salaryNum) || salaryNum < 250)
            {
                Console.WriteLine("Meblegi duzgun daxil edin...");
                goto checkSalaryLimit;
            }

            hrManager.AddDepartment(dname, workersNum, salaryNum);
        }
        static void AddEmployee(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length <= 0)
            {
                Console.WriteLine("Cari departament bazasi bosdur. Ilk once departament yaratmalisiniz.\n");
                return;
            }

            Console.WriteLine("Elave etmek istediyiniz iscinin ad ve soyadini daxil edin: ");
        reEnterFullname:
            string fullname = Console.ReadLine();
            string[] full = fullname.Split(' ');
            if (String.IsNullOrWhiteSpace(fullname) || full.Length < 2)
            {
                Console.WriteLine("Ad ve soyadi duzgun daxil edin...");
                goto reEnterFullname;
            }

            Console.WriteLine("\nIscinin vezifesini daxil edin: ");
        reEnterPositionName:
            string positionName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(positionName) || positionName.Length < 2)
            {
                Console.WriteLine("Vezife adini duzgun qeyd edin...");
                goto reEnterPositionName;
            }

            Console.WriteLine("\nElave etmek istediyiniz iscinin ayliq maasini daxil edin: ");
        reEnterSalary:
            string salary = Console.ReadLine();
            double checkSalary;
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

            bool check = true;
            foreach (Department item in hrManager.Departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine("Isci elave olundu...\n");
                    departmentName = item.Name;
                    check = false;
                    break;
                }
            }
            if (check)
            {
                Console.WriteLine("Daxil etdiyiniz departament adi yanlisdir. Duzgun daxil edin: ");
                goto reEnterDepartmentName;
            }

            hrManager.AddEmployee(fullname, positionName, checkSalary, departmentName);
        }
        static void GetDepartmentsList(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length > 0)
            {
                Console.WriteLine($"Departamentlerin siyahisi:\n");
                Console.WriteLine("------------------------------");
                foreach (Department item in hrManager.Departments)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Departament movcud deyil. Departament daxil edin.\n");
            }
        }
        static void GetEmployeeList(ref HumanResourceManager hrManager)
        {
            if (hrManager.Employees.Length > 0)
            {
                Console.WriteLine($"Butun iscilerin siyahisi:\n");
                Console.WriteLine("------------------------------");
                foreach (Employee item in hrManager.Employees)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Isci movcud deyil. Ilk once isci elave edin.\n");
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
            string nameNow = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(nameNow))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterNameNow;
            }

            bool checker = true;
            foreach (Department item in hrManager.Departments)
            {
                if (item.Name.ToLower() == nameNow.ToLower())
                {
                    checker = false;
                    Console.WriteLine("Secdiyiniz departament adini hansi ada deyismek isteyirsiniz? Daxil edin: ");
                reEnterNewName:
                    string newName = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(newName) || newName.Length < 2)
                    {
                        Console.WriteLine("Duzgun daxil edin:");
                        goto reEnterNewName;
                    }

                    Console.Clear();
                    Console.WriteLine("Departament adi deyisdirildi.\n");
                    item.Name = newName;
                    break;
                }
            }

            if (checker)
            {
                Console.WriteLine("Daxil etdiyiniz adda departament movcud deyil. Duzgun daxil edin: ");
                goto reEnterNameNow;
            }
        }
        static void EditEmployee(ref HumanResourceManager hrManager)
        {
            if (hrManager.Employees.Length <= 0)
            {
                Console.WriteLine("Hec bir isci movcud deyil. Emeliyyati icra etmek ucun hec olmasa 1 nefer isci olmalidir.\n");
                return;
            }

            Console.WriteLine($"Butun iscilerin siyahisi:\n");
            Console.WriteLine("------------------------------");
            foreach (Employee item in hrManager.Employees)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------");
            }

            Console.WriteLine("\nDeyisiklik etmek istediyiniz iscinin nomresini daxil edin:");
        reEnterWorkerNo:
            string workerNo = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(workerNo))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterWorkerNo;
            }

            string newSalary = string.Empty;
            double newSalaryNum;
            string newPosition = string.Empty;
            bool checker = true;
            foreach (Employee item in hrManager.Employees)
            {
                if (item.No.ToLower() == workerNo.ToLower())
                {
                    checker = false;
                    Console.Clear();
                    Console.WriteLine("Etmek istediyiniz emeliyyatin qarsisindaki nomreni daxil edin:\n");
                    Console.WriteLine("\t1 - Iscinin aldigi maasda duzelis etmek");
                    Console.WriteLine("\t2 - Iscinin vezifesinde duzelis etmek");

                reEnterEditWorker:
                    string select = Console.ReadLine();
                    int selectNum;
                    if (!int.TryParse(select, out selectNum))
                    {
                        Console.WriteLine("Duzgun daxil edin...");
                        goto reEnterEditWorker;
                    }

                    switch (selectNum)
                    {
                        case 1:
                            Console.WriteLine("\nIscinin yeni maasini daxil edin: ");
                        reEnternewSalary:
                            newSalary = Console.ReadLine();
                            if (!double.TryParse(newSalary, out newSalaryNum))
                            {
                                Console.WriteLine("Duzgun daxil edin...");
                                goto reEnternewSalary;
                            }

                            item.Salary = newSalaryNum;
                            Console.WriteLine("Maasda duzelis olundu...\n");
                            break;
                        case 2:
                            Console.WriteLine("\nIscinin yeni vezifesini daxil edin: ");

                        reEnternewPosition:
                            newPosition = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(newPosition) || newPosition.Length < 2)
                            {
                                Console.WriteLine("Duzgun daxil edin...");
                                goto reEnternewPosition;
                            }

                            item.Position = newPosition;
                            Console.WriteLine("Vezifede duzelis olundu...\n");
                            break;
                    }
                    break;
                }
            }
            if (checker)
            {
                Console.Clear();
                Console.WriteLine("Daxil etdiyiniz nomrede isci tapilmadi...\n");
                return;
            }
        }
        static void GetEmployeeListByDepartmentName(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length <= 0)
            {
                Console.WriteLine("Hec bir departament movcud deyil...\n");
                return;
            }

            if (hrManager.Employees.Length <= 0)
            {
                Console.WriteLine("Hec bir isci movcud deyil...\n");
                return;
            }

            Console.WriteLine("Hansi departamentdeki iscilere baxmaq isteyirsiniz?");
            Console.Write("Departament adini daxil edin: ");
        reEnterDpName:
            string dpname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(dpname))
            {
                Console.WriteLine("Duzgun daxil edin: ");
                goto reEnterDpName;
            }

            hrManager.GetEmployeeListByDepartmentName(dpname);
        }
    }
}
