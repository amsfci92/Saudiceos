using Cigarette.Enterprise.DAL; 
using Cigarette.Enterprise.DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Cigarette.Enterprise.BLL.CEOAddEditRequestServ
{
    public class CEOAddEditRequestService : ICEOAddEditRequestService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public CEOAddEditRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CEOAddEditRequest> GetAll()
        {
            var query = _unitOfWork.CEOAddEditRequests.GetAll();
            return query;
        }

        public void Add(CEOAddEditRequest ceo)
        {
            _unitOfWork.CEOAddEditRequests.Add(ceo);
        }

        public int Edit(CEOAddEditRequest ceo)
        {
            var found = _unitOfWork.CEOAddEditRequests.Get(ceo.Id);
            if (found != null)
                return _unitOfWork.CEOAddEditRequests.Update(ceo);
            else
                return 0;
        }

        public bool Delete(int id)
        {
            var result = _unitOfWork.CEOAddEditRequests.Get(id);
            if (result == null)
            {
                return false;
            }

            var deleted = _unitOfWork.CEOAddEditRequests.Remove(result);
            return deleted > 0;

        }

        public long GetAllCount()
        {
            var query = _unitOfWork.CEOAddEditRequests.GetAll();
            return query.Count();
        }

        public Result<CEOAddEditRequest> Get(long id)
        {
            var r = _unitOfWork.CEOAddEditRequests.Get(id);

            var result = new Result<CEOAddEditRequest> {
                Data = r,
                Succeeded = r != null
            };
            return result;
        }
      
        public bool DeleteRange(List<long> ids)
        {
            var list = new List<CEOAddEditRequest>();
            foreach (var item in ids)
            {
                var model = _unitOfWork.CEOAddEditRequests.Get(item);
                if (model == null)
                {
                    return false;
                }
                list.Add(model);
            }
            var result = _unitOfWork.CEOAddEditRequests.RemoveRange(list);

            return result > 0;
        }
         
    }
}
