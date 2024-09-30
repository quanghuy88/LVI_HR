using Constract.Model;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.IServices;
using Utility;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class DashboardController : Controller
    {
        private readonly IGetReportService _getReportSevice;

        public DashboardController(IGetReportService getReportSevice)
        {
            _getReportSevice = getReportSevice;
        }
        [HttpGet("reportgeneral")]
        public Task<ResponseModel<report_general>> ReportGeneral() => _getReportSevice.GetReportGeneralAsync().ToResponseModelAsync();
        [HttpGet("reportbranch")]
        public Task<ResponseModel<report_branch>> ReportBranch(decimal branch_id) => _getReportSevice.GetReportBranchAsync(branch_id).ToResponseModelAsync();
        [HttpGet("reportclassgroup")]
        public Task<ResponseModel<report_class_group>> ReportClassGroup(decimal class_group_id) => _getReportSevice.GetReportClassGroupAsync(class_group_id).ToResponseModelAsync();
    }
}
