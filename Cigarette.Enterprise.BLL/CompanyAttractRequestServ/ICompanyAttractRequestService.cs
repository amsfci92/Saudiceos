using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using Cigarette.Enterprise.ViewModels.Pagination;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
using Cigarette.Enterprise.ViewModels.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cigarette.Enterprise.BLL.CompanyAttractRequestServ
{
    public interface ICompanyAttractRequestService
    {
        void Add(CompanyAttractRequest banner);
        long GetAllCount();
        List<CompanyAttractRequest> GetAll();
        int Edit(CompanyAttractRequest model);
        bool Delete(int id);
    }
}
