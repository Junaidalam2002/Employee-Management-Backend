using DataEntity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Department : IDepartment
    {
        private readonly dbContext db;

        public Department(dbContext myDbContext)
        {
            db = myDbContext;
        }

        public async Task<List<tblDepartment>>GetAll()
        {
            try
            {
                var data = await db.tblDepartments.ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        public async Task Update(tblDepartment model)
        {
            var obj = db.tblDepartments.Where(n => n.id == model.id).SingleOrDefault();
            if (obj != null)
            {
                obj.departmentName = model.departmentName;
                db.tblDepartments.Update(obj);
                await db.SaveChangesAsync();
            }
        }

        public async Task<tblDepartment> GetById(Guid id)
        {
            try {
                var departmentEntity = db.tblDepartments.Where(e => e.id == id).SingleAsync();
                return await departmentEntity;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        public async Task<tblDepartment> Add(tblDepartment model)
        {
            try
            {
                var departmentEntity = new tblDepartment()
                {
                    id = Guid.NewGuid(),
                    departmentName = model.departmentName,
                    createdBy = model.createdBy,
                    createdDateTime = DateTime.Now,
                    status = model.status,
                };
                await db.tblDepartments.AddAsync(departmentEntity);
                await db.SaveChangesAsync();
                return departmentEntity;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        public Task Inactive(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IDepartment.Active(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
