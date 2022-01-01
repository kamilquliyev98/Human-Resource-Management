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
                        GetDepartments(ref hrManager);
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
                        GetEmployees(ref hrManager);
                        break;
                    case 5:
                        Console.Clear();
                        GetEmployeesByDepartmentName(ref hrManager);
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
                        Console.WriteLine("Nomreni duzgun daxil edin...\n");
                        break;
                }
            } while (true);
        }

        static void AddDepartment(ref HumanResourceManager hrManager)
        {
            Console.WriteLine("Yaratmaq istediyiniz departamentin adini daxil edin:");
        reEnterDepartmentName:
            Console.Write("=> ");
            string departmentname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(departmentname) || departmentname.Length < 2)
            {
                Console.WriteLine("Departament adini duzgun daxil edin...");
                goto reEnterDepartmentName;
            }

            foreach (Department item in hrManager.Departments)
            {
                if (item.Name.ToLower() == departmentname.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine("Daxil etdiyiniz adda departament artiq movcuddur.\n");
                    return;
                }
            }

            Console.WriteLine("\nDepartamentde maximum var ola bilecek isci sayini daxil edin:");
        reEnterWorkerLimit:
            Console.Write("=> ");
            string workers = Console.ReadLine();
            int workersNum;
            while (!int.TryParse(workers, out workersNum) || workersNum < 1)
            {
                Console.WriteLine("Isci sayini duzgun daxil edin...");
                goto reEnterWorkerLimit;
            }

            Console.WriteLine("\nDepartamentde butun iscilere verilecek ayliq cemi meblegi daxil edin:");
        reEnterSalaryLimit:
            Console.Write("=> ");
            string salary = Console.ReadLine();
            double salaryNum;
            while (!double.TryParse(salary, out salaryNum) || salaryNum < 250)
            {
                Console.WriteLine("Meblegi duzgun daxil edin...");
                goto reEnterSalaryLimit;
            }

            hrManager.AddDepartment(departmentname, workersNum, salaryNum);
        }

        static void AddEmployee(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length <= 0)
            {
                Console.WriteLine("Cari departament bazasi bosdur. Ilk once departament yaratmalisiniz.\n");
                return;
            }

            Console.WriteLine("Iscini hansi departamente elave etmek isteyirsiniz:");
        reEnterDepartmentName:
            Console.Write("=> ");
            string departmentName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(departmentName))
            {
                Console.WriteLine("Departament adini duzgun daxil edin...");
                goto reEnterDepartmentName;
            }

            bool check = false;
            string fullname = string.Empty;
            string positionName = string.Empty;
            double checkSalary = 0;
            foreach (Department item in hrManager.Departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    check = true;
                    departmentName = item.Name;

                    if (item.WorkerLimit <= item.WorkerCounter())
                    {
                        Console.WriteLine($"\"{item.Name}\" departamenti isci sayi limitini doldurub...\n");
                        return;
                    }

                    if (item.SalaryLimit - item.SalaryCounter() == 0 || item.SalaryLimit - item.SalaryCounter() < 250)
                    {
                        Console.WriteLine($"\"{item.Name}\" departamenti ya maas limitini doldurub deye, ya da hazirda yaratdiginiz isciye vere bileceyiniz max maas 250 AZN-den az oldugu ucun isci yarada bilmirsiniz...\n");
                        return;
                    }

                    Console.WriteLine("\nElave etmek istediyiniz iscinin tam adini (ad ve soyad) daxil edin:");
                reEnterFullname:
                    Console.Write("=> ");
                    fullname = Console.ReadLine();
                    string[] full = fullname.Split(' ');
                    if (String.IsNullOrWhiteSpace(fullname) || full.Length < 2)
                    {
                        Console.WriteLine("Ad ve soyadi duzgun daxil edin...");
                        goto reEnterFullname;
                    }

                    Console.WriteLine("\nIscinin vezifesini daxil edin:");
                reEnterPositionName:
                    Console.Write("=> ");
                    positionName = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(positionName) || positionName.Length < 2)
                    {
                        Console.WriteLine("Vezife adini duzgun qeyd edin...");
                        goto reEnterPositionName;
                    }


                    Console.WriteLine("\nElave etmek istediyiniz iscinin ayliq maasini daxil edin:");
                reEnterSalary:
                    Console.Write("=> ");
                    string salary = Console.ReadLine();
                    if (!double.TryParse(salary, out checkSalary) || checkSalary < 250)
                    {
                        Console.WriteLine("Meblegi duzgun daxil edin...");
                        goto reEnterSalary;
                    }

                    foreach (Department department in hrManager.Departments)
                    {
                        if (department.Name.ToLower() == departmentName.ToLower())
                        {
                            while (department.SalaryLimit < department.SalaryCounter() + checkSalary)
                            {
                                Console.WriteLine($"\n\"{department.Name}\" departamenti ucun nezerde tutulan maas limitini kecmemelisiniz...");
                                Console.WriteLine($"Limit: Max {department.SalaryLimit} AZN");
                                Console.WriteLine($"Departament uzre iscilere verilen cari cemi maas: {department.SalaryCounter()} AZN");
                                Console.WriteLine($"Hal-hazirda departament uzre yaratdiginiz isciye max {department.SalaryLimit - department.SalaryCounter()} AZN maas vere bilersiniz.\n");
                                Console.Write("Meblegi duzgun daxil edin: ");
                                goto reEnterSalary;
                            }
                        }
                        break;
                    }
                    break;
                }
            }

            if (check)
            {
                Console.Clear();
                Console.WriteLine("Isci elave olundu...\n");
            }

            if (check == false)
            {
                Console.Clear();
                Console.WriteLine($"\"{departmentName}\" adli departament movcud deyil...\n");
            }

            hrManager.AddEmployee(fullname, positionName, checkSalary, departmentName);
        }

        static void GetDepartments(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length <= 0)
            {
                Console.Clear();
                Console.WriteLine("Departament movcud deyil. Departament daxil edin.\n");
                return;
            }

            Console.WriteLine("Departamentlerin siyahisi:\n");
            Console.WriteLine("------------------------------------------");
            foreach (Department item in hrManager.Departments)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------------");
            }

            hrManager.GetDepartments();
        }

        static void EditDepartment(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length <= 0)
            {
                Console.WriteLine("Hec bir departament movcud deyil...\n");
                return;
            }

            Console.WriteLine("Departamentlerin siyahisi:\n");
            Console.WriteLine("----------------------------------------");
            foreach (Department item in hrManager.Departments)
            {
                Console.WriteLine(item);
                Console.WriteLine("----------------------------------------");
            }

            Console.WriteLine("\nDeyisiklik etmek istediyiniz departamentin adini daxil edin: ");
        reEnterNameNow:
            Console.Write("=> ");
            string nameNow = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(nameNow))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterNameNow;
            }

            bool checker = true;
            string newName = string.Empty;
            foreach (Department item in hrManager.Departments)
            {
                if (item.Name.ToLower() == nameNow.ToLower())
                {
                    checker = false;
                    Console.WriteLine("\nSecdiyiniz departament adini hansi ada deyismek isteyirsiniz? Daxil edin:");
                reEnterNewName:
                    Console.Write("=> ");
                    newName = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(newName) || newName.Length < 2)
                    {
                        Console.WriteLine("Duzgun daxil edin:");
                        goto reEnterNewName;
                    }

                    if (nameNow.ToLower() == newName.ToLower())
                    {
                        Console.WriteLine("\nYeni ad evvelki adla eyni ola bilmez...");
                        Console.WriteLine("Duzgun daxil edin:");
                        goto reEnterNewName;
                    }

                    foreach (Department item2 in hrManager.Departments)
                    {
                        if (item2.Name.ToLower() == newName.ToLower())
                        {
                            Console.Clear();
                            Console.WriteLine($"\"{newName}\" adli departament artiq movcuddur. Iki eyni adda departament ola bilmez...\n");
                            return;
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Departament adi deyisdirildi.\n");
                    break;
                }
            }

            if (checker)
            {
                Console.WriteLine("Daxil etdiyiniz adda departament movcud deyil. Duzgun daxil edin: ");
                goto reEnterNameNow;
            }

            hrManager.EditDepartament(nameNow, newName);
        }

        static void GetEmployees(ref HumanResourceManager hrManager)
        {
            int countWorker = 0;
            foreach (Department department in hrManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    if (employee != null)
                    {
                        countWorker++;
                    }
                }
            }

            if (countWorker == 0)
            {
                Console.WriteLine("Hec bir isci movcud deyil...\n");
                return;
            }

            foreach (Department department in hrManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    if (employee != null)
                    {
                        Console.WriteLine(employee);
                        Console.WriteLine("------------------------------------------");
                    }
                }
            }
        }

        static void GetEmployeesByDepartmentName(ref HumanResourceManager hrManager)
        {
            if (hrManager.Departments.Length <= 0)
            {
                Console.WriteLine("Hec bir departament movcud deyil...\n");
                return;
            }

            Console.WriteLine("Departamentlerin siyahisi:\n");
            Console.WriteLine("------------------------------------------");
            foreach (Department item in hrManager.Departments)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine("\nHansi departamentdeki iscilere baxmaq isteyirsiniz?");
            Console.WriteLine("Departament adini daxil edin:");
        reEnterDpName:
            Console.Write("=> ");
            string dpname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(dpname) || dpname.Length < 2)
            {
                Console.WriteLine("Duzgun daxil edin: ");
                goto reEnterDpName;
            }

            bool check = true;
            foreach (Department department in hrManager.Departments)
            {
                if (department.Name.ToLower() == dpname.ToLower())
                {
                    Console.Clear();
                    int cntworker = 0;
                    foreach (Employee employee in department.Employees)
                    {
                        if (employee != null)
                        {
                            cntworker++;
                        }
                    }
                    if (cntworker == 0)
                    {
                        Console.WriteLine("Secilmis departamentde isci movcud deyil...\n");
                        return;
                    }

                    foreach (Employee employee in department.Employees)
                    {
                        if (employee != null)
                        {
                            Console.WriteLine(employee);
                            Console.WriteLine("------------------------------------------");
                        }
                    }
                    check = false;
                    break;
                }
            }

            if (check)
            {
                Console.Clear();
                Console.WriteLine("Daxil etdiyiniz adda departament movcud deyil...\n");
                return;
            }
        }

        static void EditEmployee(ref HumanResourceManager hrManager)
        {
            int countWorker = 0;
            foreach (Department department in hrManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    if (employee != null)
                    {
                        countWorker++;
                    }
                }
            }

            if (countWorker == 0)
            {
                Console.WriteLine("Hec bir isci movcud deyil. Emeliyyati icra etmek ucun hec olmasa 1 nefer isci olmalidir.\n");
                return;
            }

            Console.WriteLine("Butun iscilerin siyahisi:\n");
            Console.WriteLine("------------------------------------------");
            foreach (Department department in hrManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    if (employee != null)
                    {
                        Console.WriteLine(employee);
                        Console.WriteLine("------------------------------------------");
                    }
                }
            }

            Console.WriteLine("\nDeyisiklik etmek istediyiniz iscinin nomresini daxil edin:");
        reEnterWorkerNo:
            Console.Write("=> ");
            string workerNo = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(workerNo))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterWorkerNo;
            }

            Console.WriteLine("\nDeyisiklik etmek istediyiniz iscinin tam adini daxil edin:");
        reEnterFullname:
            Console.Write("=> ");
            string fullname = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(fullname))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterFullname;
            }


            string newSalary = null;
            double newSalaryNum = 0;
            string newPosition = null;
            bool checker = true;
            foreach (Department department in hrManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    if (employee != null)
                    {
                        if ((employee.No.ToLower() == workerNo.ToLower()) && (employee.Fullname.ToLower() == fullname.ToLower()))
                        {
                            Console.Clear();
                            Console.WriteLine(employee);

                            Console.WriteLine("\nIsci uzerinde etmek istediyiniz emeliyyatin qarsisindaki nomreni daxil edin:\n");
                            Console.WriteLine("\t1 - Iscinin aldigi maasda duzelis etmek");
                            Console.WriteLine("\t2 - Iscinin vezifesinde duzelis etmek");
                            Console.WriteLine("\t3 - Hem iscinin aldigi maasda, hem de vezifesinde duzelis etmek");

                        reEnterEditWorker:
                            Console.Write("=> ");
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
                                    Console.WriteLine("\nIscinin yeni maasini daxil edin:");
                                reEnterNewSalary:
                                    Console.Write("=> ");
                                    newSalary = Console.ReadLine();
                                    if (!double.TryParse(newSalary, out newSalaryNum) || newSalaryNum < 250)
                                    {
                                        Console.WriteLine("Duzgun daxil edin...");
                                        goto reEnterNewSalary;
                                    }

                                    while (department.SalaryLimit < department.SalaryCounter() - employee.Salary + newSalaryNum)
                                    {
                                        Console.WriteLine($"\n\"{department.Name}\" departamenti ucun nezerde tutulan maas limitini kecmemelisiniz...");
                                        Console.WriteLine($"Limit: Max {department.SalaryLimit} AZN");
                                        Console.WriteLine($"Duzelis etdiyiniz isciye max {department.SalaryLimit - (department.SalaryCounter() - employee.Salary)} AZN maas vere bilersiniz...");
                                        Console.Write("Meblegi duzgun daxil edin: ");
                                        goto reEnterNewSalary;
                                    }

                                    Console.WriteLine("Maasda duzelis olundu...\n");
                                    break;
                                case 2:
                                    Console.WriteLine("\nIscinin yeni vezifesini daxil edin:");
                                reEnternewPosition:
                                    Console.Write("=> ");
                                    newPosition = Console.ReadLine();
                                    if (String.IsNullOrWhiteSpace(newPosition) || newPosition.Length < 2)
                                    {
                                        Console.WriteLine("Duzgun daxil edin...");
                                        goto reEnternewPosition;
                                    }

                                    Console.WriteLine("Vezifede duzelis olundu...\n");
                                    break;
                                case 3:
                                    Console.WriteLine("\nIscinin yeni maasini daxil edin:");
                                reEnterNewSalary1:
                                    Console.Write("=> ");
                                    newSalary = Console.ReadLine();
                                    if (!double.TryParse(newSalary, out newSalaryNum) || newSalaryNum < 250)
                                    {
                                        Console.WriteLine("Duzgun daxil edin...");
                                        goto reEnterNewSalary1;
                                    }

                                    while (department.SalaryLimit < department.SalaryCounter() - employee.Salary + newSalaryNum)
                                    {
                                        Console.WriteLine($"\n\"{department.Name}\" departamenti ucun nezerde tutulan maas limitini kecmemelisiniz...");
                                        Console.WriteLine($"Limit: Max {department.SalaryLimit} AZN");
                                        Console.WriteLine($"Duzelis etdiyiniz isciye max {department.SalaryLimit - (department.SalaryCounter() - employee.Salary)} AZN maas vere bilersiniz...");
                                        Console.Write("Meblegi duzgun daxil edin: ");
                                        goto reEnterNewSalary1;
                                    }

                                    Console.WriteLine("\nIscinin yeni vezifesini daxil edin:");
                                reEnternewPosition2:
                                    Console.Write("=> ");
                                    newPosition = Console.ReadLine();
                                    if (String.IsNullOrWhiteSpace(newPosition) || newPosition.Length < 2)
                                    {
                                        Console.WriteLine("Duzgun daxil edin...");
                                        goto reEnternewPosition2;
                                    }

                                    Console.WriteLine("Secdiyiniz iscinin hem vezifesinde, hem de aldigi maasda duzelis etdiniz...\n");
                                    break;
                                default:
                                    Console.WriteLine("Nomreni duzgun daxil edin:");
                                    goto reEnterEditWorker;
                            }
                            checker = false;
                            break;
                        }
                    }
                }
            }

            if (checker)
            {
                Console.Clear();
                Console.WriteLine("Daxil etdiyiniz isci nomresi ve ya iscinin ad soyadi yanlisdir. Deyisiklik ede bilmeyiniz ucun her ikisini duzgun daxil etmelisiniz...\n");
                return;
            }

            hrManager.EditEmployee(workerNo, fullname, newPosition, newSalaryNum);
        }

        static void RemoveEmployee(ref HumanResourceManager hrManager)
        {
            int counter = 0;
            foreach (Department department in hrManager.Departments)
            {
                if (department.Employees.Length > 0)
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("Hec bir isci movcud deyil. Emeliyyati icra etmek ucun hec olmasa 1 departament ve 1 nefer isci olmalidir.\n");
                return;
            }

            Console.WriteLine("Departamentlerin siyahisi:\n");
            Console.WriteLine("------------------------------------------");
            foreach (Department item in hrManager.Departments)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine("\nHansi departamenten isci silmek isteyirsiniz?");
            Console.Write("Departament adini daxil edin: ");
            reEnterSelectDepartment:
            string selectDepartment = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(selectDepartment) || selectDepartment.Length < 2)
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterSelectDepartment;
            }

            string DelWorker = string.Empty;
            bool find = true;
            foreach (Department department in hrManager.Departments)
            {
                if (department.Name.ToLower() == selectDepartment.ToLower())
                {
                    find = false;
                    int cntworker = 0;
                    foreach (Employee employee in department.Employees)
                    {
                        if (employee != null)
                        {
                            cntworker++;
                        }
                    }
                    if (cntworker == 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"\"{department.Name}\" departamentinde isci yoxdur...\n");
                        return;
                    }

                    Console.Clear();
                    Console.WriteLine($"\"{department.Name}\" departamentindeki iscilerin siyahisi:\n");
                    Console.WriteLine("------------------------------------------");
                    foreach (Employee employee in department.Employees)
                    {
                        if (employee != null)
                        {
                            Console.WriteLine(employee);
                            Console.WriteLine("------------------------------------------");
                        }
                    }

                    Console.WriteLine("\nSilmek istediyiniz iscinin nomresini daxil edin:");
                reEnterDelWorker:
                    DelWorker = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(DelWorker) || DelWorker.Length < 6)
                    {
                        Console.WriteLine("Duzgun daxil edin:");
                        goto reEnterDelWorker;
                    }

                    bool deleted = false;
                    for (int i = 0; i < department.Employees.Length; i++)
                    {
                        if (department.Employees[i] != null)
                        {
                            if (department.Employees[i].No.ToLower() == DelWorker.ToLower())
                            {
                                deleted = true;
                                break;
                            }
                        }
                    }

                    if (deleted)
                    {
                        Console.Clear();
                        Console.WriteLine("Isci silindi...\n");
                    }

                    if (deleted == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Daxil etdiyiniz nomrede isci movcud deyil...\n");
                        return;
                    }

                    break;
                }
            }

            if (find)
            {
                Console.Clear();
                Console.WriteLine("Daxil etdiyiniz adda departament yoxdur...\n");
                return;
            }

            hrManager.RemoveEmployee(DelWorker, selectDepartment);

        }

    }
}
