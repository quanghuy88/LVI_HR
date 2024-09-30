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
        public Task<report_general> GetReportGeneralAsync();
        public Task<report_branch> GetReportBranchAsync(decimal? branch_id);
        public Task<report_class_group> GetReportClassGroupAsync(decimal? class_group_id);
    }
}
