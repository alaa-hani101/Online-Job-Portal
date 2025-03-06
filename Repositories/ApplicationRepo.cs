using JobPortalManagement.Data;
using JobPortalManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories
{
    public class ApplicationRepo : IRepository
    {
        public void Add(AppDbContext context)
        {
            Console.WriteLine("Enter the Job ID: ");
            var JobId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the User ID: ");
            var UserId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Status: ");
            var status = Console.ReadLine();

            var app = new Applicationn { UserID = UserId , jobID=JobId,Status=status};
            context.Add(app);
            context.SaveChanges();

            Console.WriteLine("Application Added Successfully!");

        }

        public void Delete(AppDbContext context, int filter)
        {
            var existingApp = context.Apllications.Find(filter);

            if(existingApp != null)
            {
                context.Remove(existingApp);
                context.SaveChanges();
                Console.WriteLine("Application Deleted Successfully!");
            }
        }

        public void Get(AppDbContext context)
        {
            var list = context.Apllications.ToList();

            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

        }

        public void Update(AppDbContext context, int filter)
        {
            var existingApp = context.Apllications.Find(filter);

            Console.WriteLine("==  Update Status  =>  (\"Pending\", \"Accepted\", \"Rejected\")");

            Console.WriteLine("Enter the new Status :");

            var status = Console.ReadLine();

            existingApp.Status = status;

            context.SaveChanges();

            Console.WriteLine("Status Updated Successfully!");



        }
    }
}
