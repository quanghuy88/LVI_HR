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
        public Task<List<class_group_model>> GetClassGroupAsync();
        public Task<List<branch_model>> GetBranchAsync();
    }
}
