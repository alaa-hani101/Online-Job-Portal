using JobPortalManagement.Data;
using JobPortalManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories
{
    public class CompanyRepo : IRepository
    {
        public void Add(AppDbContext context)
        {
            Console.WriteLine("Enter the name of Company :");
            var name = Console.ReadLine();

            Console.WriteLine("Enter the Industry  :");
            var industry = Console.ReadLine();

            Console.WriteLine("Enter the Location  :");
            var location = Console.ReadLine();

            var company = new Company { Name = name, Industry = industry, Location = location};
            context.Companys.Add(company);
            context.SaveChanges();
            Console.WriteLine("Company added successfully!");

        }

        public void Update(AppDbContext context, int comapnyId)
        {
            var existingCompany = context.Companys.Find(comapnyId);
            if (existingCompany != null)
            {
                Console.WriteLine("==Update Options==");
                Console.WriteLine("1. Update Name");
                Console.WriteLine("2. Update Industry");
                Console.WriteLine("3. Update Location");
                Console.WriteLine("Choose Option :  ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the new name :");
                        var name = Console.ReadLine();
                        existingCompany.Name = name;
                        break;
                    case "2":
                        Console.WriteLine("Enter the new email :");
                        var industry = Console.ReadLine();
                        existingCompany.Industry = industry;
                        break;
                    case "3":
                        Console.WriteLine("Enter the new password :");
                        var location = Console.ReadLine();
                        existingCompany.Location = location;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                context.SaveChanges();
            }

        }

        public void Delete(AppDbContext context,int comapnyId)
        {
           
            var comp = context.Companys.Find(comapnyId);
            if (comp != null)
            {
                context.Companys.Remove(comp);
                context.SaveChanges();
            }
        }

        public void Get(AppDbContext context)
        {
            var list = context.Companys.ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
