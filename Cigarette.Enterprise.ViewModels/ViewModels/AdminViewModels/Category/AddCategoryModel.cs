using Cigarette.Enterprise.ViewModels.Validation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category
{
    [Validator(typeof(CategoryValidator))]
    public class AddCategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountryId { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public bool IsMainCategory { get; set; }
        public bool IsCommercialCategory { get; set; }
        public bool HasHorizontalMenu { get; set; }
        public Nullable<int> ParentCategoryId { get; set; }
        public bool SearchForAll { get; set; }
        public int? CountToDelete { get; set; }
        public int? DaysToDelete { get; set; }
        
        public bool IsActive { get; set; }
        public byte categoryLevel { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsUpdated { get; set; }
        public Nullable<bool> IsDisplayed { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<System.DateTime> DeleteTime { get; set; }
        public string CategoryLogo { get; set; }
        public Nullable<int> imageId { get; set; }
        public Nullable<int> OldimageId { get; set; }
        public HttpPostedFileWrapper logo { get; set; }
        public string LogoChanged { get; set; }
        public int DisplayOrder { get; set; }
    }
}
