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
    public class AccessGroupMaster : IAccessGroupMaster
    {
        private readonly dbContext db;

        public AccessGroupMaster(dbContext dbContext)
        {
            db = dbContext;
        }
        Task IAccessGroupMaster.Active(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<tblAccessGroupMaster> Add(tblAccessGroupMaster tblAccessGroupMaster)
        {
            try
            {
                var obj = new tblAccessGroupMaster()
                {
                    id = Guid.NewGuid(),
                    groupName = tblAccessGroupMaster.groupName,
                    description = tblAccessGroupMaster.description,
                    createdBy = tblAccessGroupMaster.createdBy,
                    createdDateTime = DateTime.Now,
                    status = tblAccessGroupMaster.status,
                };
                await db.tblAccessGroupMaster.AddAsync(obj);
                await db.SaveChangesAsync();
                return obj;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        public async Task<List<tblAccessGroupMaster>> GetAll()
        {
            try
            {
                var data = await db.tblAccessGroupMaster.ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        public async Task<tblAccessGroupMaster> GetById(Guid id)
        {
            try {
                var obj = db.tblAccessGroupMaster.Where(e => e.id == id).SingleAsync();
                return await obj;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        Task IAccessGroupMaster.Inactive(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(tblAccessGroupMaster model)
        {
            try {
                var obj = db.tblAccessGroupMaster.Where(n => n.id == model.id).SingleOrDefault();
                if (obj != null)
                {
                    obj.groupName = model.groupName;
                    db.tblAccessGroupMaster.Update(obj);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }
    }
}
