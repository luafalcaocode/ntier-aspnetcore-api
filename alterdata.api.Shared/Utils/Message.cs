using alterdata.api.Shared.Enums;
using System;
using System.Collections.Generic;

namespace alterdata.api.Shared.Utils
{
    public class Message<T>
    {
        public T Data { get; set; }
        public bool Success { get ; set; }
        public int StatusCode { get; set; }

        public IList<string> Errors = new List<string>();
        public Exception Exception { get; set; }

        public Message()
        {
            StatusCode = (int) StatusCodeEnum.Ok;
        }

        public void Ok(T data)
        {
            Data = data;
            Success = true;
            StatusCode = (int) StatusCodeEnum.Ok;
        }

        public void Error(Exception error)
        {
            Success = false;
            Exception = error;
            StatusCode = (int)StatusCodeEnum.InternalServerError;
        }

        public void NotFound()
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.NotFound;
        }

        public void NoContent()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.NoContent;
        }

        public void Unauthorized()
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.Unauthorized;
        }
    }

    public class Message 
    {
        public bool Success { get; set; }
        public IList<string> Errors = new List<string>();
        public int StatusCode { get; set; }
        public Exception Exception { get; set; }

        public void Ok()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.Ok;
        }

        public void Error(Exception error)
        {
            Success = false;
            Exception = error;
            StatusCode = (int)StatusCodeEnum.InternalServerError;
        }

        public void NotFound()
        {
            Success = false;
            StatusCode = (int)StatusCodeEnum.NotFound;
        }

        public void NoContent()
        {
            Success = true;
            StatusCode = (int)StatusCodeEnum.NoContent;
        }
    }
}