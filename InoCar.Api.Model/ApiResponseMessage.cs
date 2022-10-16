using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
    public class ApiResponseMessage<T>
    {
        
            public string Message { get; set; }
            public bool IsSuccess { get; set; }
            public T? Result { get; set; }
        
    }
}
