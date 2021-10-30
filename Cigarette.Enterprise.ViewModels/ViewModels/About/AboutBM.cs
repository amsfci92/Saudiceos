using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cigarette.Enterprise.ViewModels.ViewModels.About
{
    public class AboutBM
    {
        public string Lock { get; set; }
        [Required]
        public string InstagramPageLink { get; set; }
        [Required]
        public string FacebookPageLink { get; set; }
        [Required]
        public string TwiterAccountLink { get; set; }
        public string YoutubeChannelLink { get; set; }
        [Required]
        public string GooglePlusLink { get; set; }
        public string LogoUrl { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        [Required]
        [AllowHtml]
        public string AboutAr { get; set; }
        [Required]
        [AllowHtml]
        public string AboutEn { get; set; }
        [AllowHtml]
        public string TermsAndConditionsAr { get; set; }
        [AllowHtml] 
        public string TermsAndConditionsEn { get; set; }
        [AllowHtml] 
        public string PrivacyPolicyAr { get; set; }
        [AllowHtml]
        public string PrivacyPolicyEn { get; set; }
        [AllowHtml]
        public string SafetyRolesAr { get; set; }
        [AllowHtml]
        public string SafetyRolesEn { get; set; }
        public Nullable<int> CountryId { get; set; }

    }
}
