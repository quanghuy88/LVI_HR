using Constract.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.IServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly IGetReportService _getReportSevice;

        public DashboardController(IGetReportService getReportSevice)
        {
            _getReportSevice = getReportSevice;
        }
        [HttpGet]
        [Route("reportgeneral")]
        public async Task<IActionResult> ReportGeneral() => Ok(_getReportSevice.GetReportGeneral());
        [HttpGet]
        [Route("reportbranch")]
        public async Task<IActionResult> ReportBranch(int branchid) => Ok(_getReportSevice.GetReportBranch(branchid));
        [HttpGet("reportclassgroup")]
        public async Task<IActionResult> ReportClassGroup(decimal class_group_id) => Ok(_getReportSevice.GetReportClassGroup(class_group_id));
    }
}
