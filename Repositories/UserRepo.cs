using Azure;
using JobPortalManagement.Data;
using JobPortalManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JobPortal.Repositories
{
    public class UserRepo : IRepository
    {

        public void Add(AppDbContext context)
        {
            Console.WriteLine("Enter the Role : (choose between 'JobSeeker' / 'Employer'  )");
            var role = Console.ReadLine();

            role = AssignRole(role,context);
        }

        private static string? AssignRole(string? role,AppDbContext context)
        {
            if (role == "j" || role == "J")
            { 
                role = "JobSeeker";

                Console.WriteLine("Enter the name of user :");
                var name = Console.ReadLine();

                Console.WriteLine("Enter the Email  :");
                var email = Console.ReadLine();

                Console.WriteLine("Enter the Password  :");
                var password = Console.ReadLine();

                var user = new Userr { Name = name, Email = email, Password = password, Role = role };
                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine($"{role} added successfully!");


            }
            else if (role == "E" || role == "e")
            {

                var companyRepo = new CompanyRepo();
                companyRepo.Add(context);
            }
            else
                role = null;
            return role;
        }

        public void Delete(AppDbContext context, int userId)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public void Update(AppDbContext context,int userId)
        {
            var existingUser = context.Users.Find(userId);
            if (existingUser != null)
            {
                Console.WriteLine("==Update Options==");
                Console.WriteLine("1. Update Name");
                Console.WriteLine("2. Update Email");
                Console.WriteLine("3. Update Password");
                Console.WriteLine("Choose Option :  ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the new name :");
                        var name = Console.ReadLine();
                        existingUser.Name = name;
                        break;
                    case "2":
                        Console.WriteLine("Enter the new email :");
                        var email = Console.ReadLine();
                        existingUser.Email = email;
                        break;
                    case "3":
                        Console.WriteLine("Enter the new password :");
                        var password = Console.ReadLine();
                        existingUser.Password = password;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                context.SaveChanges();
            }
        }

        public void Get(AppDbContext context)
        {
            var list = context.Users.ToList();

            foreach(var item in list ){
                Console.WriteLine(item);
            }
        }
    }
}
