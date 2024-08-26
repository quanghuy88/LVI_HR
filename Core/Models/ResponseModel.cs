using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ResponseModel<T>
    {
        public ResponseHeaderDto header { get; set; }
        public T body { get; set; }
    }

    public class ResponseModel : ResponseModel<object>
    {
        public static ResponseModel<T> Ok<T>(T data) => new ResponseModel<T>()
        {
            header = new ResponseHeaderDto() { code = 200 },
            body = data
        };

        public static ResponseModel Ok() => new ResponseModel() { header = new ResponseHeaderDto() { code = 200 } };

        public static ResponseModel<T> Ok<T>(T data, ResponseHeaderDto header) => new ResponseModel<T>()
        {
            header = header,
            body = data
        };

        public static ResponseModel Ok(ResponseHeaderDto header) => new ResponseModel() { header = header };

        public static async Task<ResponseModel> Ok(Task task)
        {
            await task;
            return Ok();
        }

        public static async Task<ResponseModel<T>> Ok<T>(Task<T> task) => Ok(await task);

        public static async Task<ResponseModel<T>> Ok<T>(Task<T> task, ResponseHeaderDto header) => Ok(await task, header);
    }

}
