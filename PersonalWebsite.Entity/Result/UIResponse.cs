using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Entity.Result
{
    public class UIResponse<T>
    {
        public HttpStatusCode? StatusCode { get; set; }
        public string? Message { get; set; }

        public bool? Success { get; set; }

        public T? Data { get; set; }


        public UIResponse(T data, HttpStatusCode statustCode, bool success, string message)
        {
            StatusCode = statustCode;
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
