using Constract.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.IServices;

namespace WebAPI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IGetReportService _getReportSevice;

        public DashboardController(IGetReportService getReportSevice)
        {
            _getReportSevice = getReportSevice;
        }
        [HttpGet]
        public async Task<IActionResult> ReportGeneral() => Ok(_getReportSevice.GetReportGeneral());
        [HttpGet]
        public async Task<IActionResult> ReportBranch(int branchid) => Ok(_getReportSevice.GetReportBranch(branchid));
        [HttpGet]
        public async Task<IActionResult> ReportClassGroup(string class_group_code) => Ok(_getReportSevice.GetReportClassGroup(class_group_code));
    }
}
