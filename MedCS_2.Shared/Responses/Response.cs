using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Shared.Responses
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; } = new();
        public T? Data { get; set; }

        public static Response<T> Success(T data, string? message = null, int statusCode = 200)
            => new() { Succeeded = true, Message = message ?? "Success", Data = data, StatusCode = statusCode };

        public static Response<T> Fail(string message, int statusCode = 400, List<string>? errors = null)
            => new() { Succeeded = false, Message = message, StatusCode = statusCode, Errors = errors ?? new() };
        public static Response<T> Fail(IEnumerable<string> errors, string? message = null, int statusCode = 400) =>
        new() { Succeeded = false, Message = message ?? "Validation Failed", StatusCode = statusCode, Errors = errors.ToList() };
    }
}
