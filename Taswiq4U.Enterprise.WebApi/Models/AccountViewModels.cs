using System;
using System.Collections.Generic;

namespace Taswiq4U.Enterprise.WebApi.Models
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class UserUpdateViewModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryId { get; set; }
    }
    public class UserFullInfoViewModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CountryId { get; set; }
        public string CountryNameEnglish { get; set; }
        public string CountryNameArabic { get; set; }
        public string Image { get; set; }
        public int CityId { get; set; }
        public string CityNameEnglish { get; set; }
        public string CityNameArabic { get; set; }
        public int FreeAdsCount { get; set; }
        public bool MembershipType { get; set; }
        public bool PhoneConfirmed { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Phone { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewApiModel
    {
        public string Phone { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
