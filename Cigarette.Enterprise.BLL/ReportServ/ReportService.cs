using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using PagedList;

namespace Cigarette.Enterprise.BLL.ReportServ
{
    public class ReportService : IReportService
    {
        #region Fields
        private IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor
        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Report banner)
        {
            _unitOfWork.Report.Add(banner);

        }

        public bool Delete(int id)
        {
            var result = _unitOfWork.Report.Get(id);
            if (result == null)
                return false;

            var deleted = _unitOfWork.Report.Remove(result);
            return deleted > 0;

        }

        public Result Edit(Report model)
        {
            var result = _unitOfWork.Report.Update(model); 
            if (result == 0)
            {
                return new Result
                {
                    Succeeded = false,
                    Errors = new List<ResultError>
                    {
                        new ResultError {Message = "Update failed"}
                    }
                };
            }

            return new Result { Succeeded = true };
        }

        public List<Report> GetAll()
        {
            return _unitOfWork.Report.GetAll().OrderByDescending(m => m.Id).ToList();

        }

        public long GetAllCount()
        {
            return _unitOfWork.Report.GetAll().Count();
        }
        #endregion

        #region Methods

        public Report Get(long id)
        {
            var report = _unitOfWork.Report.Get(id);
             
            return report;
        }
        public bool DeleteRange(List<long> ids)
        {
            var list = new List<Report>();
            foreach (var item in ids)
            {
                var model = _unitOfWork.Report.Get(item);
                if (model == null)
                {
                    return false;
                }
                list.Add(model);
            }
            var result = _unitOfWork.Report.RemoveRange(list);

            return result > 0;
        }

        public Result<IPagedList<Report>> GetAllPaged(int pageSize = 10, int pageNo = 1)
        {
            var data = _unitOfWork.Report.GetAll()
                //.Where(m => m.Active == true)
                .OrderByDescending(m => m.Id)
                .ToPagedList(pageNo, pageSize);
            var result = new Result<IPagedList<Report>>
            {
                Data = data,
                Succeeded = true
            };

            return result;
        }

        #endregion

    }
}
