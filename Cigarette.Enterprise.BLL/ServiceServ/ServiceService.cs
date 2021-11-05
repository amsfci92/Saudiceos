using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using PagedList;

namespace Cigarette.Enterprise.BLL.ServiceServ
{
    public class ServiceService : IServiceService
    {
        #region Fields
        private IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor
        public ServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Service banner)
        {
            _unitOfWork.Service.Add(banner);

        }

        public bool Delete(int id)
        {
            var result = _unitOfWork.Service.Get(id);
            if (result == null)
                return false;

            var deleted = _unitOfWork.Service.Remove(result);
            return deleted > 0;

        }

        public Result Edit(Service model)
        {
            var result = _unitOfWork.Service.Update(model); 
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

        public List<Service> GetAll()
        {
            return _unitOfWork.Service.GetAll().OrderByDescending(m => m.DateCreated).ToList();

        }

        public long GetAllCount()
        {
            return _unitOfWork.Service.GetAll().Count();
        }
        #endregion

        #region Methods

        public Service Get(long id)
        {
            var service = _unitOfWork.Service.Get(id);
             
            return service;
        }
        public bool DeleteRange(List<long> ids)
        {
            var list = new List<Service>();
            foreach (var item in ids)
            {
                var model = _unitOfWork.Service.Get(item);
                if (model == null)
                {
                    return false;
                }
                list.Add(model);
            }
            var result = _unitOfWork.Service.RemoveRange(list);

            return result > 0;
        }

        public Result<IPagedList<Service>> GetAllPaged(int pageSize = 10, int pageNo = 1)
        {
            var data = _unitOfWork.Service.GetAll()
                .Where(m => m.Active == true)
                .OrderByDescending(m => m.Id)
                .ToPagedList(pageNo, pageSize);
            var result = new Result<IPagedList<Service>>
            {
                Data = data,
                Succeeded = true
            };

            return result;
        }

        public void AddCategory(Category cat)
        {
            _unitOfWork.Category.Add(cat);
        }

        public Result<IPagedList<Category>> GetAllCategoriesPaged(int pageSize = 10, int pageNo = 1)
        {
            var data = _unitOfWork.Category.GetAll() 
               .OrderBy(m => m.Id)
               .ToPagedList(pageNo, pageSize);
            var result = new Result<IPagedList<Category>>
            {
                Data = data,
                Succeeded = true
            };    
            return result;
        }
        public Result<IPagedList<Category>> GetAllCategories(int pageSize = 10, int pageNo = 1)
        {
            var data = _unitOfWork.Category.GetAll() 
               .Where(m => m.Services.Any())
               .OrderBy(m => m.Id).ToPagedList(pageNo, pageSize); 

            var result = new Result<IPagedList<Category>>
            {
                Data = data,
                Succeeded = true
            };
            return result;
        }

        public Result DeleteCategory(long id)
        {
            var category = _unitOfWork.Category.GetAll().FirstOrDefault(m => m.Id == id);
            if (category != null)
            {
                var services = _unitOfWork.Service.GetAll().Where(m => m.CategoryId == id).ToList();
                if (services != null)
                {
                    foreach (var item in services)
                    {
                        item.CategoryId = null;
                        _unitOfWork.Service.Update(item);
                    }
                }
                _unitOfWork.Category.Remove(category);

                return new Result
                {
                    Succeeded = true
                };
            }
            return new Result
            {
                Succeeded = false
            };
        }

        #endregion

    }
}
