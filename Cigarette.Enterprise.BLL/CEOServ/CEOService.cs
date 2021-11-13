using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.Specification;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Specification;
using Cigarette.Enterprise.ViewModels.ViewModels.Category_SpecificationAttribute;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel;
using PagedList;

namespace Cigarette.Enterprise.BLL.CEOServ
{
    public class CEOService : ICEOService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public CEOService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CEO> GetAllCeos()
        {
            var query = _unitOfWork.CEOs.GetAll().OrderByDescending(m => m.Id);
            return query.ToList();
        }

        public void Add(CEO ceo)
        {
            _unitOfWork.CEOs.Add(ceo);
        }

        public int Edit(CEO ceo)
        {
            var found = _unitOfWork.CEOs.Get(ceo.Id);
            if (found != null)
                return _unitOfWork.CEOs.Update(ceo);
            else
                return 0;
        }

        public bool Delete(int id)
        {
            var result = _unitOfWork.CEOs.Get(id);
            if (result == null)
            {
                return false;
            }

            var deleted = _unitOfWork.CEOs.Remove(result);
            return deleted > 0;

        }

        public int GetAllCeosCount()
        {
            var query = _unitOfWork.CEOs.GetAll();
            return query.Count();
        }

        public CEO Get(long id)
        {
            return _unitOfWork.CEOs.Get(id);
        }
        public bool DeleteRange(List<long> ids)
        {
            var list = new List<CEO>();
            foreach (var item in ids)
            {
                var model = _unitOfWork.CEOs.Get(item);
                if (model == null)
                {
                    return false;
                }
                list.Add(model);
            }
            var result = _unitOfWork.CEOs.RemoveRange(list);

            return result > 0;
        }

        public Result<IPagedList<CEO>> GetAllPaged(int pageSize, int pageNo, string searchText)
        {
            var query = _unitOfWork.CEOs.GetAll()
              .Where(m => m.Active == true);

            if(!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(m => 
                    m.Name != null && m.Name.ToLower().Contains(searchText) ||
                    m.Email != null && m.Email.ToLower().Contains(searchText) ||
                    m.Company != null && m.Company.ToLower().Contains(searchText) ||
                    m.Position != null && m.Position.ToLower().Contains(searchText) 
                    );
            }
              var finalResult = query.OrderByDescending(m => m.Id)
              .ToPagedList(pageNo, pageSize);
            var result = new Result<IPagedList<CEO>>
            {
                Data = finalResult,
                Succeeded = true
            };

            return result;
        }

        public void IncreaseCount(long id)
        {
            _unitOfWork.SaudiceosEntities.IncreaseViews((int)id, 1, 0);
        }
    }  
}
