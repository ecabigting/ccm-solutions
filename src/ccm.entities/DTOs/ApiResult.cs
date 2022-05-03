using System;

namespace ccm.entities.DTOs
{
    public class ApiResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object Data {get;set;}
        public string ErrorMessage { get; set; }
    }
}