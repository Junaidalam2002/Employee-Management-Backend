using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IEmployee
    {
        Task<List<tblEmployee>> GetAll();
        Task<object> GetById(string empId);
        Task<tblEmployee> Add(tblEmployee tblEmployee);
        Task Update(tblEmployee model);
        Task Inactive(Guid id);
        Task Active(Guid id);
        Task<List<tblEmployee>> LastInactive();
    }
}
