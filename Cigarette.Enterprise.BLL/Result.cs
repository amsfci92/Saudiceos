using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL
{
    public class Result<T> : Result where T : class
    {
        public T Data { get; set; } 
        public Result()
        { 
        }
    }
    public class Result 
    { 
        public List<ResultError> Errors { get; set; }
        public bool Succeeded { get; set; } 
    }
}
