using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Model
{
    public partial class tblEmployee
    {
        public Guid id { get; set; }
        public string? empId { get; set; }
        public string? name { get; set; }
        public string? contact { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public Guid? departmentId { get; set; }
        public Guid? designationId { get; set; }
        public Guid? groupId { get; set; }
        public string? userId { get; set; }
        public string? password { get; set; }
        public bool status { get; set; }
        public bool? isFirstTimeLogin { get; }
        public DateTime? passExpDate { get; }
        public bool? isPasswordExp { get; }
        public bool? isLock { get;  }
        public bool? isLogged { get; }
        public Guid? isLoggedId { get;}
        public Guid? createdBy { get; set; }
        public DateTime? createdDateTime { get; set; }
        public string? siteId { get;}

        public virtual tblDepartment? Department {get;}
        public virtual tblDesignation? Designation {get;}
        public virtual tblAccessGroupMaster? AccessGroupMaster {get;}



    }
}
