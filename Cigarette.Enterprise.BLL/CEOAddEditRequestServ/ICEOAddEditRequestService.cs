using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
using Cigarette.Enterprise.ViewModels.Pagination;
using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.CEOAddEditRequestServ
{
    public interface ICEOAddEditRequestService
    {
        void Add(CEOAddEditRequest banner);
        long GetAllCount();
        IEnumerable<CEOAddEditRequest> GetAll();
        int Edit(CEOAddEditRequest model);
        bool Delete(int id);
        bool DeleteRange(List<long> ids);
        Result<CEOAddEditRequest> Get(long id);
    }
}
