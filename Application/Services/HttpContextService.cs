
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.IO;
using Utility;
using Core.Models;
using Core.Dtos;


namespace Application.Services
{
    public class HttpContextService
    {
        private readonly HttpContext _httpContext;

        public HttpContextService(IServiceProvider serviceProvider)
        {
            _httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        }

        public async Task WriteEmptyResponseAsync(int code = 400)
        {
            _httpContext.Response.StatusCode = code;
            _httpContext.Response.Headers.Clear();
            await _httpContext.Response.Body.DisposeAsync();
        }

        public Task WriteJsonResponseAsync(string message, int code = 400)
        {
            var data = string.IsNullOrEmpty(message) ? null : new Dictionary<string, object>() { { "message", message } };
            return WriteJsonResponseAsync(data, code);
        }

        public Task WriteJsonResponseAsync(ResponseHeaderDto responseHeader, int code = 400)
        {
            _httpContext.Response.StatusCode = code;
            var responseBody = ResponseModel.Ok(responseHeader);
            return SerializeHttpResponseAsync(responseBody);
        }

        public Task WriteJsonResponseAsync(Exception ex, int code = 400) => WriteJsonResponseAsync(ex.Message, code);

        public async Task WriteJsonResponseAsync(Dictionary<string, object> messages, int code = 400)
        {
            _httpContext.Response.StatusCode = code;
            if (messages?.Any() != true) return;
            await SerializeHttpResponseAsync(messages);
        }

        private Task SerializeHttpResponseAsync<T>(T data)
        {
            var serializeOption = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            _httpContext.Response.ContentType = "application/json; charset=utf-8";
            return JsonSerializer.SerializeAsync(_httpContext.Response.Body, data, serializeOption);
        }

    }
}
