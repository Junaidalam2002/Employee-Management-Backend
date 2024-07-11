using DataEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IDesignation
    {
        Task<List<tblDesignation>> GetAll();
        Task<tblDesignation> GetById(Guid id);
        Task<tblDesignation> Add(tblDesignation tblDesignation);
        Task Update(tblDesignation model);
        Task Inactive(Guid id);
        Task Active(Guid id);
    }
}