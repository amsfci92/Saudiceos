using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAdsCategory;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.KnowledgeCenterServ
{
    public interface IKnowledgeCenterService
    {  
        int Add(KnowledgeCenter banner);
        long GetAllCount();
        List<KnowledgeCenter> GetAll();
        bool Edit(KnowledgeCenter model);
        bool Delete(int id);
        bool DeleteRange(List<long> ids);
    }
}
