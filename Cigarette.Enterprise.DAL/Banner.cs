//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cigarette.Enterprise.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Banner
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string FileUrl { get; set; }
        public string Description { get; set; }
        public string Advertiser { get; set; }
        public string Keywords { get; set; }
        public Nullable<int> AdPlace { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
