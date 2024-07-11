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
    public class Designation : IDesignation
    {

        private readonly dbContext db;

        public Designation(dbContext myDbContext)
        {
            db = myDbContext;
        }

        Task IDesignation.Active(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<tblDesignation> Add(tblDesignation model)
        {
            try
            {
                var designationEntity = new tblDesignation()
                {
                    id = Guid.NewGuid(),
                    designationName = model.designationName,
                    createdBy = model.createdBy,
                    createdDateTime = DateTime.Now,
                    status = model.status,
                };
                await db.tblDesignation.AddAsync(designationEntity);
                await db.SaveChangesAsync();
                return designationEntity;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        public async Task<List<tblDesignation>> GetAll()
        {
            try
            {
                var data = await db.tblDesignation.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        public async Task<tblDesignation> GetById(Guid id)
        {
            try
            {
                var designationEntity = await db.tblDesignation.Where(e => e.id == id).SingleOrDefaultAsync();
                return designationEntity;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        public async Task Inactive(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(tblDesignation model)
        {
            try {
                var obj = db.tblDesignation.Where(n => n.id == model.id).SingleOrDefault();
                if (obj != null)
                {
                    obj.designationName = model.designationName;
                    db.tblDesignation.Update(obj);
                    await db.SaveChangesAsync();
                }
            }
            catch(Exception e) {
                e.Message.ToString();
                throw;
            }
        }
    }
}
