using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Model
{
    public partial class tblDepartment
    {
        public tblDepartment()
        {
            tblEmployee = new HashSet<tblEmployee>();
        }

        public Guid id { get; set; }
        public string? departmentName { get; set; }
        public Guid? head { get;}
        public bool? status { get;set;}
        public Guid? createdBy { get; set; }
        public DateTime? createdDateTime { get; set; }
        public string? siteId { get; }

        public virtual ICollection<tblEmployee> tblEmployee { get; }



    }
}
