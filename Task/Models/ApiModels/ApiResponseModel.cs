using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models.ApiModels
{
    public class ApiResponseModel<T>
    {
        public T ResponseModel { get; set; }
        public int ResponseCode { get; set; }
    }
}
