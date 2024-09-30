using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ResponseModelHelper
    {
        public static async Task<ResponseModel<T>> ToResponseModelAsync<T>(this Task<T> task)
        {
            var result = await task;
            return ResponseModel.Ok(result);
        }

        public static async Task<ResponseModel> ToResponseModelAsync(this Task task)
        {
            await task;
            return ResponseModel.Ok();
        }

        public static ResponseModel<T> ToResponseModel<T>(this T data) => ResponseModel.Ok(data);
    }
}
