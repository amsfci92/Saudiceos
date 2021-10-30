using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.SmsGateway
{
    public class SmsGatewayBM
    {
        public int Id { get; set; }
        [Required]
        public string UrlDescription { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
