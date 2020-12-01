using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            Successed = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Successed = false;
            Message = message;
        }
        public bool Successed { get; set; }
        public string Message { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
        public IDictionary<string, string[]> ValidationErrors {get; set;}
        public T Data { get; set; }
    }
}
