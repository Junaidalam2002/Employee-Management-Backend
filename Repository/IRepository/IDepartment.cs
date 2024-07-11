using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IDepartment
    {
        Task<List<tblDepartment>>GetAll();
        Task<tblDepartment> GetById(Guid id);
        Task<tblDepartment> Add(tblDepartment tblDepartment);
        Task Update(tblDepartment model);
        Task Inactive(Guid id);
        Task Active(Guid id);
    }
}
