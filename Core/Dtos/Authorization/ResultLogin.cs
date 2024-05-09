using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Authorization
{
    public class ResultLogin : users
    {
        public string Token { get; set; }
        //public string UserRole { get; set; }
    }
}
