using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Specification;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Specification;
using Cigarette.Enterprise.ViewModels.ViewModels.Category_SpecificationAttribute;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel;
using Newtonsoft.Json.Linq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Cigarette.Enterprise.BLL.CEOServ
{
    public interface ICEOService
    {
        IEnumerable<CEO> GetAllCeos();
        int GetAllCeosCount();
        void Add(CEO ceo);
        int Edit(CEO ceo);
        bool Delete(int id);
        CEO Get(long id);
        bool DeleteRange(List<long> ids);
        void IncreaseCount(long id);
        Result<IPagedList<CEO>> GetAllPaged(int pageSize, int pageNo, string searchText);
    }
}
