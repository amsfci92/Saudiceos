using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using Cigarette.Enterprise.ViewModels.Pagination;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Category;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigarette.Enterprise.ViewModels.ViewModels.Category;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
using System.Web;
using System.IO;

namespace Cigarette.Enterprise.BLL.CompanyAttractRequestServ
{
    public class CompanyAttractRequestService : ICompanyAttractRequestService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public CompanyAttractRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(CompanyAttractRequest banner)
        {
            throw new NotImplementedException();
        }

        public long GetAllCount()
        {
            throw new NotImplementedException();
        }

        public List<CompanyAttractRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Edit(CompanyAttractRequest model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}