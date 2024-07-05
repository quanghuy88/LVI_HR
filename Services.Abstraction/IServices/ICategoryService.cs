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
        public Task<List<dwh_list_insurance_product>> GetProduct();
        public Task<List<dwh_list_branch>> GetBranch();
    }
}
