using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment
{
    public class AddAdvertisementBM
    {
        #region Ctor
        public AddAdvertisementBM()
        {
            this.Advertisment_Specification = new List<AdvertismentSpecificationBM>();
            this.Photos = new List<AdvertismentPhotoBM>();
        }
        #endregion


        /// <summary>
        /// Ad ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ad Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Ad Title
        /// </summary>
        public string ArTitle { get; set; }

        /// <summary>
        /// Ad Title
        /// </summary>
        public string EnTitle { get; set; }


        /// <summary>
        /// Description
        /// </summary>  
        public string OrgDescription { get; set; }

        /// <summary>
        /// ArabicDescription
        /// </summary>
        [Required]
        [MinLength(30)]
        public string ArabicDescription { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [MinLength(30)]
        public string EnglishDescription { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// IsNogitable
        /// </summary>
        public bool IsNogitable { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        [Required]
        public int CategoryId { get; set; }


        /// <summary>
        /// CountryId
        /// </summary>
        [Required]
        public int CountryId { get; set; }

        /// <summary>
        /// CityId
        /// </summary>
        [Required]
        public int CityId { get; set; }

        /// <summary>
        /// StateId
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// LocationLen
        /// </summary>
        public decimal LocationLongtude { get; set; }

        /// <summary>
        /// LocationLat
        /// </summary>
        public decimal LocationLatitude { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// IsNew
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Contact Me
        /// </summary>
        public ContactMeWith ContactMe { get; set; }

        /// <summary>
        /// IsFree
        /// </summary>
        public bool? IsFree { get; set; }
        /// <summary>
        /// Navigation 
        /// </summary>
        #region Navigation Properties
        public List<AdvertismentPhotoBM> Photos { get; set; }
        public List<AdvertismentSpecificationBM> Advertisment_Specification { get; set; }

        #endregion

    }


    public class AddAdvertisementWebBM
    {
        #region Ctor
        public AddAdvertisementWebBM()
        {
            this.CustomFields = new List<AdvertismentSpecificationBM>();
            this.Images = new List<AdvertismentPhotoBM>();
        }
        #endregion


        /// <summary>
        /// Ad ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ad Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ArabicDescription
        /// </summary>
        [Required] 
        public string Description { get; set; }

         
        /// <summary>
        /// Price
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Phone
        /// </summary> 
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// IsNogitable
        /// </summary>
        public bool IsNogitable { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        [Required]
        public int CategoryId { get; set; }


        /// <summary>
        /// CountryId
        /// </summary> 
        public int CountryId { get; set; }

        /// <summary>
        /// CityId
        /// </summary>
        [Required]
        public int CityId { get; set; }

        /// <summary>
        /// StateId
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// LocationLen
        /// </summary>
        public decimal LocationLongtude { get; set; }

        /// <summary>
        /// LocationLat
        /// </summary>
        public decimal LocationLatitude { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// IsNew
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Contact Me
        /// </summary>
        public ContactMeWith ContactMe { get; set; }

        /// <summary>
        /// IsFree
        /// </summary>
        public bool? IsFree { get; set; }
        /// <summary>
        /// Navigation 
        /// </summary>
        #region Navigation Properties
        public List<AdvertismentPhotoBM> Images { get; set; }
        public List<AdvertismentSpecificationBM> CustomFields { get; set; }

        #endregion

    }


}
