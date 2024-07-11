using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IAccessGroupMaster
    {
        Task<List<tblAccessGroupMaster>> GetAll();
        Task<tblAccessGroupMaster> GetById(Guid id);
        Task<tblAccessGroupMaster> Add(tblAccessGroupMaster tblAccessGroupMaster);
        Task Update(tblAccessGroupMaster model);
        Task Inactive(Guid id);
        Task Active(Guid id);
    }
}