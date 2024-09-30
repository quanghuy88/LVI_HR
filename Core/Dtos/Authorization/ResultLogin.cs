using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Authorization
{
    public class ResultLogin : dwh_admin_user
    {
        public string Token { get; set; }
        public string msg { get; set; }
        public decimal? departmentId { get; set; }
        public string departmentName { get; set; }
        public string branch_code { get; set; }
        public string branch_name { get; set; }
        public object[][] Role { get; set; }
    }
}
