using Cigarette.Enterprise.DAL; 
using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
using Cigarette.Enterprise.ViewModels.Pagination;
using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.NewsServ
{
    public interface INewsService
    {
        long Add(News news);
        long Edit(News news);
        bool Delete(long id);
        long GetAllCount();
        IEnumerable<News> GetAll();
        void IncreaseCount(long id);
        News Get(long id);
        bool DeleteRange(List<long> news);
        Result<IPagedList<News>> GetAllPaged(int pageSize, int pageNo);
        IEnumerable<News> GetRelated(long id);
    }
}
