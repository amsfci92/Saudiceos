using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Cigarette.Enterprise.ViewModels.VM.Settings
{
    public class SettingsVM
    {
        public SettingsVM()
        {
        }
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string SiteEmail { get; set; }
        public string SiteFax { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        [AllowHtml]
        public string FooterSentence { get; set; }
        public string SiteKeywords { get; set; }
        [AllowHtml]
        public string SiteDescription { get; set; }
        public string SiteHomeDescription { get; set; }
        public string SiteFacebook { get; set; }
        public string SiteTwitter { get; set; }
        public string SiteSnapchat { get; set; }
        public string SiteFlicker { get; set; }
        public string SiteGoogle { get; set; }
        public string SiteLinkedIn { get; set; }
        public string SiteInstagram { get; set; }
        public string SiteViemo { get; set; }
        public string ShareCode { get; set; }
        public string GoogleAnalytics { get; set; }
        public string GoogleMaps { get; set; }
        [AllowHtml]
        public string AboutUs { get; set; }
        [AllowHtml]
        public string TermsOfUse { get; set; }
        [AllowHtml]
        public string Disclaimer { get; set; }
    }
}
