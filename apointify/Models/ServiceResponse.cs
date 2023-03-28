using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace apointify.Models
{

    public class ServiceResponse<T>
    {
        public T data { get; set; }
        public string? status_code { get; set; }
        public string? message { get; set; }
    }
}

