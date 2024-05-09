using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IHttpContextService : IInjection
    {
        bool IsAjaxRequest { get; }
        Task WriteEmptyResponseAsync(int code = 400);
        Task WriteJsonResponseAsync(string message, int code = 400);
        Task WriteJsonResponseAsync(Exception ex, int code = 400);
        Task WriteJsonResponseAsync(Dictionary<string, object> messages, int code = 400);
        Task WriteViewResponseAsync(string viewName, int code = 400);
    }
}
