using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.CustomModels;
using Cigarette.Enterprise.DAL.Repository;
using Cigarette.Enterprise.ViewModels.BindingModels.Bundle;
using Cigarette.Enterprise.ViewModels.BindingModels.UserBundle;
using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
using Cigarette.Enterprise.ViewModels.Pagination;
using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using Cigarette.Enterprise.ViewModels.ViewModels.Bundle;
using Cigarette.Enterprise.ViewModels.ViewModels.UserBundle;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecification;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecificationOptions;
using PagedList;

namespace Cigarette.Enterprise.BLL.BannerServ
{
    public class BannerService : IBannerService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public BannerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Banner banner)
        {
            _unitOfWork.Banners.Add(banner);
        }

        public long GetAllCount()
        {
            return _unitOfWork.Banners.GetAll().Count();
        }

        public List<Banner> GetAll()
        {
            return _unitOfWork.Banners.GetAll().ToList();
        }
         
        public Result Edit(Banner model)
        {
             var result = _unitOfWork.Banners.Update(model);
            return new Result
            {
                Succeeded = result > 0
            };
           
        }

        public bool Delete(int id)
        {
            var model = _unitOfWork.Banners.Get(id);
            if (model == null)
            {
                return false;
            }

            var deleted = _unitOfWork.Banners.Remove(model);
            return deleted > 0;
        }

        public Banner Get(long id)
        {
            return _unitOfWork.Banners.Get(id);
        }
        public bool DeleteRange(List<long> news)
        {
            var list = new List<Banner>();
            foreach (var item in news)
            {
                var model = _unitOfWork.Banners.Get(item);
                if (model == null)
                {
                    return false;
                }
                list.Add(model);
            }
            var result = _unitOfWork.Banners.RemoveRange(list);

            return result > 0;
        }

        public Result<IPagedList<Banner>> GetAllPaged(int pageSize, int pageNo)
        {
            var data = _unitOfWork.Banners.GetAll()
         .Where(m => m.Active == true)
         .OrderBy(m => m.Id)
         .ToPagedList(pageNo, pageSize);
            var result = new Result<IPagedList<Banner>>
            {
                Data = data,
                Succeeded = true
            };

            return result;
        }

        public Result<Banner> GetBannerByType(int type)
        {
            var data = _unitOfWork.Banners.GetAll()
        .Where(m => m.Active == true)
        .OrderBy(m => m.Id).Where(m => m.AdPlace == type).FirstOrDefault();
      
            var result = new Result<Banner> 
            {
                Data = data,
                Succeeded = true
            };

            return result;
        }

        public Result<IPagedList<Banner>> GetAllPagedByType(int pageSize, int pageNo, int type)
        {
            var data = _unitOfWork.Banners.GetAll()
         .Where(m => m.Active == true && m.AdPlace == type)
         .OrderBy(m => m.Id)
         .ToPagedList(pageNo, pageSize);
            var result = new Result<IPagedList<Banner>>
            {
                Data = data,
                Succeeded = true
            };

            return result;
        }
    }
}
