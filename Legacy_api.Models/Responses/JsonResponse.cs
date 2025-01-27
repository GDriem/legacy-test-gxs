using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legacy_api.Models.Responses
{
    public class JsonResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public  int StatusCode { get; set; } = 200;
        public string? Data { get; set; }
    }
}
