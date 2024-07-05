using Core.Entities;
using Injection;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base.LVIDashboard;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.Services
{
    public class CategoryService : ICategoryService, IScopedInjection
    {
        private readonly ILVIDashboardRepository<dwh_list_insurance_product> _productRepo;
        private readonly ILVIDashboardRepository<dwh_list_branch> _branchRepo;
        public CategoryService(IServiceProvider serviceProvider) 
        { 
            _productRepo = serviceProvider.GetService(_productRepo);
            _branchRepo = serviceProvider.GetService(_branchRepo);
        }
        public async Task<List<dwh_list_insurance_product>> GetProduct() 
        {
            return _productRepo.AsNoTracking().ToList();
        }
        public async Task<List<dwh_list_branch>> GetBranch()
        {
            return _branchRepo.AsNoTracking().ToList();
        }
    }
}
