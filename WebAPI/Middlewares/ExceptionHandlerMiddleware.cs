using Core.Exceptions;
using Microsoft.Data.SqlClient;
using Services.Abstraction.IServices;

namespace WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public ExceptionHandlerMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _config = serviceProvider.GetRequiredService<IConfiguration>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var httpContextService = httpContext.RequestServices.GetRequiredService<IHttpContextService>();
                if (ex is BadActionException)
                {
                    await httpContextService.WriteJsonResponseAsync(ex);
                    return;
                }
                if (ex is InsufficientPermissionException)
                {
                    await httpContextService.WriteJsonResponseAsync(ex, 403);
                    return;
                }
                var exception = ex.InnerException ?? ex;
                if (exception is SqlException sqlEx)
                {
                    var codes = _config.GetSection("DisplayExceptionByCode:Sql").Get<List<int>>();
                    if (codes?.Contains(sqlEx.Number) == true)
                    {
                        await httpContextService.WriteJsonResponseAsync(exception);
                        return;
                    }
                }
                await httpContextService.WriteJsonResponseAsync(exception, 503);
                if (_config.GetSection("Logging:ExceptionLogging:Disable").Get<bool?>() == true) return;
                var exceptionLogService = httpContext.RequestServices.GetRequiredService<IExceptionLoggingService>();
                await exceptionLogService.WriteLogAsync(ex);
            }
        }
    }
}
