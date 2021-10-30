using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.PaymentGateway
{
    public class TapChargeSource
    {
        public string id { get; set; }

    }

    public class TapChargeSourceTypes
    {
        public static string KNet { get; set; } = "src_kw.knet";
        public static string SrcAll { get; set; } = "src_all";
        public static string SrcCard { get; set; } = "src_card";
    }
} 