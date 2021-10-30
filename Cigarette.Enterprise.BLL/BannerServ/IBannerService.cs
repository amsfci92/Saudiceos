using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.ViewModels.BindingModels.Bundle;
using Cigarette.Enterprise.ViewModels.BindingModels.UserBundle;
using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
using Cigarette.Enterprise.ViewModels.Pagination;
using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using Cigarette.Enterprise.ViewModels.ViewModels.Bundle;
using Cigarette.Enterprise.ViewModels.ViewModels.UserBundle;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.BannerServ
{
    public interface IBannerService
    { 
        void Add(Banner banner); 
        long GetAllCount();  
        List<Banner> GetAll(); 
        Result Edit(Banner model);
        bool Delete(int id);
        Banner Get(long id);
        bool DeleteRange(List<long> news);
        Result<IPagedList<Banner>> GetAllPaged(int pageSize, int pageNo);
        Result<Banner>  GetBannerByType( int type);
        Result<IPagedList<Banner>> GetAllPagedByType(int pageSize, int pageNo, int type);
    }
}
