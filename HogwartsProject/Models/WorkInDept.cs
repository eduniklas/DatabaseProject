using System;
using HogwartsProject.Data;
using System.Collections.Generic;

namespace HogwartsProject.Models
{
    public partial class WorkInDept
    {
        public int WorkInDeptId { get; set; }
        public int? FkDepartmentId { get; set; }
        public int? FkEmployeeId { get; set; }
        public int? FkRoleId { get; set; }
    }
}
