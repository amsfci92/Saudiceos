using Cigarette.Enterprise.DAL;
using PagedList;
using System.Collections.Generic;

namespace Cigarette.Enterprise.BLL.ServiceServ
{
    public interface IServiceService
    {
     
        void Add(Service ser);
        void AddCategory(Category cat);
        long GetAllCount();
        List<Service> GetAll();
        Result<IPagedList<Service>> GetAllPaged(int pageSize = 100, int pageNo = 1);
        Result<IPagedList<Category>> GetAllCategoriesPaged(int pageSize = 100, int pageNo = 1);
        Result Edit(Service model);
        bool Delete(int id);
        Service Get(long id);
        Result<IPagedList<Category>> GetAllCategories(int pageSize = 10, int pageNo = 1);
        bool DeleteRange(List<long> ids);
        Result DeleteCategory(long id);
    }
}
