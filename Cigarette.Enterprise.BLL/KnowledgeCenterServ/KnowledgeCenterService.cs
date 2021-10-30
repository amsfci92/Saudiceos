using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.CustomModels;
using Cigarette.Enterprise.DAL.Repository; 
using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment; 
using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using Cigarette.Enterprise.ViewModels.ViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAdsCategory;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecification;
using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.AdvertismentSpecificationOptions;
using PagedList;

namespace Cigarette.Enterprise.BLL.KnowledgeCenterServ
{
    public class KnowledgeCenterService : IKnowledgeCenterService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public KnowledgeCenterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(KnowledgeCenter knowledgeCenter)
        {
            throw new NotImplementedException();
        }

        public int Edit(KnowledgeCenter knowledgeCenter)
        {
            throw new NotImplementedException();
        }

        public long GetAllCount()
        {
            throw new NotImplementedException();
        }

        public List<KnowledgeCenter> GetAll()
        {
            throw new NotImplementedException();
        }

        bool IKnowledgeCenterService.Edit(KnowledgeCenter model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
    }
}
