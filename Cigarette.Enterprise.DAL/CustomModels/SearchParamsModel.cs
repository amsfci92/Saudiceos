using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.CustomModels
{
    public class SearchParamsModel
    {
        public int SpecificationId { get; set; } 
        public bool HasOptions { get; set; }
        public string Value { get; set; }

        public bool HasRange { get; set; }

        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public List<int> Options { get; set; }
    }
}
