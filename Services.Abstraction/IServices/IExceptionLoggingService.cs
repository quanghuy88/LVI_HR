using Core.Dtos;
using Core.Entities;
using Core.Models;
using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IExceptionLoggingService : IInjection
    {
        Task<PaginationDto<log>> GetLogsAsync(BaseSearchModel model);
        Task WriteLogAsync(Exception exception);
        Task CleanUpAsync();
    }

}
