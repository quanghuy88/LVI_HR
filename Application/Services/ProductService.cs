using Core.Entities;
using Injection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base.LVIDashboard;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService: IProductService, IScopedInjection
    {
        private readonly ILVIDashboardRepository<insurance_product> _productRepo;

        public ProductService(IServiceProvider serviceProvider) => _productRepo = serviceProvider.GetService(_productRepo);
        public async Task<List<insurance_product>> GetProduct() 
        {
            return _productRepo.AsNoTracking().ToListAsync();
        }
    }
}
