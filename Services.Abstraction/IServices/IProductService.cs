using Core.Entities;
using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IProductService: IInjection
    {
        public Task<List<insurance_product>> GetProduct();
    }
}
