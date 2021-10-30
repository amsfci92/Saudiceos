using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment
{
    /// <summary>
    /// Search Parameters
    /// </summary>
    public class AdvancedSearchParametersBM
    {
        public int SpecificationId { get; set; }
        public List<int> Options { get; set; }
        /// <summary>
        /// if the param has options
        /// </summary>
        public bool HasOptions { get; set; }

        /// <summary>
        /// if the param is a single value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// if the param is a range ex. Price
        /// </summary>
        public bool HasRange { get; set; }

        /// <summary>
        /// If the paramis Range use Min 
        /// </summary>
        public double Min { get; set; }

        /// <summary>
        /// If the paramis Range use  Max
        /// </summary>
        public double Max { get; set; }
    }
}
