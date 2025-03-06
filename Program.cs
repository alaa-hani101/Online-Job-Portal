using JobPortal.Repositories;
using JobPortalManagement.Data;

namespace JobPortalManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext()) 
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== Online Job Portal ===");
                    Console.WriteLine("1. Manage Users");
                    Console.WriteLine("2. Manage Jobs");
                    Console.WriteLine("3. Manage Applications");
                    Console.WriteLine("4. Manage Companys");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1": UserMenu(context); break;
                        case "2": JobMenu(context); break;
                        case "3": ApplicationMenu(context); break;
                        case "4":  CompanyMenu(context); break;
                        case "5":
                            return;
                        default: Console.WriteLine("Invalid option. Try again!"); break;
                    }
                }
            }
        }
        static void UserMenu(AppDbContext context)
        {
            var uesrRepo = new UserRepo();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== User Management ===");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. View Users");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": uesrRepo.Add(context); break;
                    case "2":
                        Console.WriteLine("Enter the user ID :");
                        var id = int.Parse(Console.ReadLine());
                        uesrRepo.Update(context,id); 
                        break;
                    case "3":
                        Console.WriteLine("Enter the user ID :");
                        var _id = int.Parse(Console.ReadLine());
                        uesrRepo.Delete(context, _id);
                        break;
                    case "4": uesrRepo.Get(context); 
                        break;
                    case "5": 
                        return;
                    default: Console.WriteLine("Invalid option. Try again!"); break;
                }
                Console.ReadKey();
            }
        }

        static void CompanyMenu(AppDbContext context)
        {
            var companyRepo = new CompanyRepo();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== User Management ===");
                Console.WriteLine("1. Update Company");
                Console.WriteLine("2. Delete Company");
                Console.WriteLine("3. View Companys");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the Company ID :");
                        var id = int.Parse(Console.ReadLine());
                        companyRepo.Update(context, id);
                        break;
                    case "2":
                        Console.WriteLine("Enter the Company ID :");
                        var _id = int.Parse(Console.ReadLine());
                        companyRepo.Delete(context, _id);
                        break;
                    case "3":
                        companyRepo.Get(context);
                        break;
                    case "4":
                        return;
                    default: Console.WriteLine("Invalid option. Try again!"); break;
                }
                Console.ReadKey();
            }

        }

        static void JobMenu(AppDbContext context)
        {
            var jobRepo = new JobRepo();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Job Management ===");
                Console.WriteLine("1. Add Job");
                Console.WriteLine("2. View Jobs");
                Console.WriteLine("3. Update Job");
                Console.WriteLine("4. Delete Job");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": jobRepo.Add(context); break;
                    case "2": jobRepo.Get(context); break;
                    case "3":
                        Console.WriteLine("Enter ID of Job:");
                        var jobId = int.Parse(Console.ReadLine());
                        jobRepo.Update(context,jobId); 
                        break;
                    case "4":
                        Console.WriteLine("Enter ID of Job:");
                        var _jobId = int.Parse(Console.ReadLine());
                        jobRepo.Delete(context,_jobId); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid option. Try again!"); break;
                }
            Console.ReadKey();
            }
        }
        static void ApplicationMenu(AppDbContext context)
        {
            var ApplicationRepo = new ApplicationRepo();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Job Management ===");
                Console.WriteLine("1. Add Application");
                Console.WriteLine("2. View Application");
                Console.WriteLine("3. Update Application");
                Console.WriteLine("4. Delete Application");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ApplicationRepo.Add(context); break;
                    case "2": ApplicationRepo.Get(context); break;
                    case "3":
                        Console.WriteLine("Enter ID of Application:");
                        var AppId = int.Parse(Console.ReadLine());
                        ApplicationRepo.Update(context, AppId);
                        break;
                    case "4":
                        Console.WriteLine("Enter ID of Job:");
                        var _AppId = int.Parse(Console.ReadLine());
                        ApplicationRepo.Delete(context, _AppId); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid option. Try again!"); break;
                }
                Console.ReadKey();
            }
        }

    }
}