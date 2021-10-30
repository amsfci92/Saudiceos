using Cigarette.Enterprise.DAL;
using PagedList;
using System.Collections.Generic;

namespace Cigarette.Enterprise.BLL.ReportServ
{
    public interface IReportService
    {
     
        void Add(Report banner);
        long GetAllCount();
        List<Report> GetAll();
        Result<IPagedList<Report>> GetAllPaged(int pageSize = 10, int pageNo = 1);
        Result Edit(Report model);
        bool Delete(int id);
        Report Get(long id);
        bool DeleteRange(List<long> ids);
    }
}
