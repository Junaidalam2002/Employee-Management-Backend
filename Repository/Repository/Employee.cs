using DataEntity.Model;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Employee : IEmployee
    {
        private readonly dbContext db;

        public Employee(dbContext myDbContext)
        {
            db = myDbContext;
        }
        public Task Active(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<tblEmployee> Add(tblEmployee tblEmployee)
        {
            try {
                var obj = new tblEmployee()
                {
                    id = Guid.NewGuid(),
                    empId = tblEmployee.empId,
                    name = tblEmployee.name,
                    contact = tblEmployee.contact,
                    email = tblEmployee.email,
                    address = tblEmployee.address,
                    departmentId = tblEmployee.departmentId,
                    designationId = tblEmployee.designationId,
                    groupId = tblEmployee.groupId,
                    userId = tblEmployee.userId,
                    password = tblEmployee.password,
                    createdDateTime = DateTime.Now,
                    status = tblEmployee.status,
                    createdBy = tblEmployee.createdBy
                };
                await db.tblEmployee.AddAsync(obj);
                await db.SaveChangesAsync();
                return obj;
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task<List<tblEmployee>> GetAll()
        {
            try
            {
                var data = await db.tblEmployee.ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task<object> GetById(string empId)
        {
            try
            {
                var obj = await (from em in db.tblEmployee
                           join dp in db.tblDepartments on em.departmentId equals dp.id
                           join dg in db.tblDesignation on em.designationId equals dg.id
                           join gp in db.tblAccessGroupMaster on em.groupId equals gp.id
                                 where em.empId == empId
                                 select new
                           {
                               em.id,
                               em.empId,
                               em.name,
                               em.address,
                               em.password,
                               em.createdDateTime,
                               dp.departmentName,
                               dg.designationName,
                               gp.groupName,
                               em.contact,
                               em.email,
                               em.createdBy

                           }).ToListAsync();
                return obj;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task Inactive(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(tblEmployee model)
        {
            try {
                var obj = db.tblEmployee.Where(n => n.empId == model.empId).FirstOrDefault();
                if (obj != null)
                {
                    obj.name = model.name;
                    db.tblEmployee.Update(obj);
                    await db.SaveChangesAsync();
                }
            }catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task<List<tblEmployee>> LastInactive()
        {
            var obj = db.tblEmployee.Where(e => e.status == false).OrderByDescending(e => e.createdDateTime).Take(2).ToListAsync();
            return await obj;
        }
    }
}
