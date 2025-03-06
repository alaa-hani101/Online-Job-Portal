using JobPortalManagement.Data;
using JobPortalManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories
{
    public class JobRepo : IRepository
    {
        public void Add(AppDbContext context)
        {
          
            Console.WriteLine("Enter the Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Enter the Description: ");
            var description = Console.ReadLine();

            Console.WriteLine("Enter the Salary: ");
            var salary = double.Parse( Console.ReadLine());


            Console.WriteLine("Enter the Company's ID: ");
            var ID = int.Parse(Console.ReadLine());

            var job = new Job {Title=title,Description=description,Salary=salary,CompanyID = ID };
            context.Add(job);
            context.SaveChanges();
            Console.WriteLine("Job Added Successfully!");

        }

        public void Delete(AppDbContext context, int jobId)
        {
            var existingJob = context.Jobs.Find(jobId);
            if(existingJob != null)
            {
                context.Remove(existingJob);
                context.SaveChanges();
                Console.WriteLine("Job Deleted Successfully!");

            }
        }

        public void Get(AppDbContext context)
        {
            var list = context.Jobs.ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void Update(AppDbContext context, int jobId)
        {
            var existingJob = context.Jobs.Find(jobId);
            if (existingJob != null)
            {
                Console.WriteLine("==Update Options==");
                Console.WriteLine("1. Update Title");
                Console.WriteLine("2. Update Description");
                Console.WriteLine("3. Update Salary");
                Console.WriteLine("4. Update Assigned Company");
                Console.WriteLine("Choose Option :  ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the new Title :");
                        var title = Console.ReadLine();
                        existingJob.Title = title;
                        break;
                    case "2":
                        Console.WriteLine("Enter the new email :");
                        var desc = Console.ReadLine();
                        existingJob.Description = desc;
                        break;
                    case "3":
                        Console.WriteLine("Enter the new password :");
                        var sal = double.Parse(Console.ReadLine());
                        existingJob.Salary = sal;
                        break;
                    case "4":
                        Console.WriteLine("Enter the new Company :");
                        var id = int.Parse(Console.ReadLine());
                        existingJob.CompanyID = id;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                context.SaveChanges();
            }
        }
    }
}
