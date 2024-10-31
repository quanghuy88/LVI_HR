using Core.Entities;
using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IEmployeeService : IInjection
    {
        //GET
        public Task<List<hr_employee>> GetEmployeenAsync(decimal? id);

        //POST
        public Task<List<hr_employee>> PostEmployeenAsync(hr_employee hre);
    }
}
