using JobPortalManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repositories
{
    public interface IRepository
    {
         void Add(AppDbContext context);
         void Update(AppDbContext context,int filter);
         void Delete(AppDbContext context , int filter);
         void Get(AppDbContext context);

    }
}
