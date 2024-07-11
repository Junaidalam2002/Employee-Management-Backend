using DataEntity.Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MultiEmployee : IMultiEmployee
    {
        private readonly dbContext db;

        public MultiEmployee(dbContext myDbContext)
        {
            db = myDbContext;
        }
        public async Task<int> AddAll(List<tblEmployee> tblEmployee)
        {
            foreach(var a in tblEmployee)
            {
                db.tblEmployee.Add(a);
                await db.SaveChangesAsync();
            }
            return 1;
        }
    }
}
