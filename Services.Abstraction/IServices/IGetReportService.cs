using Constract.Model;
using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IGetReportService : IInjection
    {
        public Task<report_general> GetReportGeneral();
        public Task<report_branch> GetReportBranch(int branch_id);
        public Task<report_class_group> GetReportClassGroup(decimal? class_group_id);
    }
}
