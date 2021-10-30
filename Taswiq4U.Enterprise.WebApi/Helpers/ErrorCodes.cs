using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Taswiq4U.Enterprise.WebApi.Helpers
{
    public class ErrorCodes
    {
      

        public static ErrorCodes Ins
        {
            get
            {
                return new ErrorCodes();
            }
        }
        

        public Error PhoneRequired
        {
            get
            {
                return new Error
                {
                    Code = "API-ER1",
                    Description = "PhoneRequired",
                    Group = ""
                };
            }
        }

        public Error NotCompletedData
        {
            get
            {
                return new Error
                {
                    Code = "API-ER6",
                    Description = "",
                    Group = "NotCompletedData"
                };
            }
        }


        public Error WrongData
        {
            get
            {
                return new Error
                {
                    Code = "API-ER2",
                    Description = "WrongData",
                    Group = ""
                };
            }
        }

      
        public Error FoundUser
        {
            get
            {
                return new Error
                {
                    Code = "API-ER3",
                    Description = "FoundUser",
                    Group = ""
                };
            }
        }
        public Error VerificationCodeNotCorrect
        {
            get
            {
                return new Error
                {
                    Code = "API-ER4",
                    Description = "VerificationCodeNotCorrect",
                    Group = ""
                };
            }
        }
        public Error PhoneNotVerified
        {
            get
            {
                return new Error
                {
                    Code = "API-ER7",
                    Description = "PhoneNotVerified",
                    Group = ""
                };
            }
        }


        #region Advertisment Errors
        public Error c
        {
            get
            {
                return new Error
                {
                    Code = "API-ER8",
                    Description = "",
                    Group = ""
                };
            }
        }

        public Error AdNotFound
        {
            get
            {
                return new Error
                {
                    Code = "API-ER9",
                    Description = "AdNotFound",
                    Group = ""
                };
            }
        }

        public Error InvalidData
        {
            get
            {
                return new Error
                {
                    Code = "API-ER10",
                    Description = "InvalidData",
                    Group = ""
                };
            }
        }

        public Error ChangeCountryFaild
        {
            get
            {
                return new Error
                {
                    Code = "API-ER11",
                    Description = "ChangeCountryFaild",
                    Group = ""
                };
            }
        }

        public Error UserNotFound
        {
            get
            {
                return new Error
                {
                    Code = "API-ER12",
                    Description = "UserNotFound",
                    Group = ""
                };
            }
        }

        public Error FileNotFound
        {
            get
            {
                return new Error
                {
                    Code = "API-ERR-F4",
                    Description = "File Not Found",
                    Group = ""
                };
            }
        }

        public Error PaymentFaild
        {
            get
            {
                return new Error
                {
                    Code = "API-ERR-PF",
                    Description = "Payment Process Faild",
                    Group = ""
                };
            }
        }

        public Error WaitingListFull
        {
            get
            {
                return new Error
                {
                    Code = "API-ERR-FAWF",
                    Description = "Feature Ad Waiting List Full",
                    Group = ""
                };
            }
        }

        public Error AlreadyFeatured
        {
            get
            {
                return new Error
                {
                    Code = "API-ERR-AF",
                    Description = "Already Featured Ad",
                    Group = ""
                };
            }
        }

        public Error AdBalanceFinished
        {
            get
            {
                return new Error
                {
                    Code = "API-ERR-AdF",
                    Description = "Ads Balance Finished",
                    Group = ""
                };
            }
        }

        public object CategoryNotFound
        {
            get
            {
                return new Error
                {
                    Code = "API-ERR-CNF",
                    Description = "CategoryNotFound",
                    Group = ""
                };
            }
        }

        #endregion

    }
    public class Error
    { 
        public string Code { get; set; }
        //[JsonIgnore]
        public string Description { get; set; }
        public string Group { get; set; }

        public Error Message(string message)
        {
            //this.Description.Concat(message);
            return this;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string ToJson() => String.Format("{ 'code' : '{0}', 'description' : '{1}, 'group' : '{2}'}", this.Code, this.Description, this.Group);
    }
}