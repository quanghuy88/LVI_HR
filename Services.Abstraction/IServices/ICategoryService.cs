using Constract.Model;
using Core.Entities;
using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface ICategoryService: IInjection
    {
        //Get
        public Task<List<admin_position>> GetPositionAsync();
        public Task<List<admin_country>> GetCountryAsync();
        public Task<List<admin_department>> GetDepartmentAsync();
        public Task<List<admin_place>> GetPlaceAsync();
        //role
        //public Task<List<branch_model>> GetRoleAsync();

        //Post
        public Task<decimal> PostPositionAsync(admin_position ap);
        public Task<decimal> PostCountryAsync(admin_country ac);
        public Task<decimal> PostDepartmentAsync(admin_department ad);
        public Task<decimal> PostPlaceAsync(admin_place aplace);
    }
}
