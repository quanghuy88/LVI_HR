using Constract.Model;
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
        private readonly ILVIDashboardRepository<dwh_acc_major_group> _mgRepo;
        private readonly ILVIDashboardRepository<dwh_list_branch> _branchRepo;
        public CategoryService(IServiceProvider serviceProvider) 
        {
            _mgRepo = serviceProvider.GetService(_mgRepo);
            _branchRepo = serviceProvider.GetService(_branchRepo);
        }
        public async Task<List<class_group_model>> GetClassGroupAsync() 
        {
            var result = new List<class_group_model>();
            var lstcg = _mgRepo.AsNoTracking().ToList();
            if (lstcg.Count > 0)
            {
                for (var i = 0; i < lstcg.Count; i++)
                {
                    var obj = new class_group_model();
                    obj.id = lstcg[i].id;
                    obj.vname = lstcg[i].name;
                    obj.ename = lstcg[i].ename;
                    result.Add(obj);
                }
            }
            return result;
        }
        public async Task<List<branch_model>> GetBranchAsync()
        {
            var result = new List<branch_model>();
            var lstbranch = _branchRepo.AsNoTracking().Where(x => x.level == 2).ToList();
            if (lstbranch.Count > 0) 
            {
                for (var i = 0; i < lstbranch.Count; i++) 
                {
                    var obj = new branch_model();
                    obj.id = lstbranch[i].id;
                    obj.code = lstbranch[i].code;
                    obj.name = lstbranch[i].name;
                    obj.coderef = lstbranch[i].code_ref;
                    result.Add(obj);
                }
            }
            return result;
        }
    }
}
