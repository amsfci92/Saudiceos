using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using Cigarette.Enterprise.ViewModels.BindingModels.AdminBindingModels.City;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.City; 
using Cigarette.Enterprise.ViewModels.ViewModels.City;

namespace Cigarette.Enterprise.BLL.IndividualOpportunityDiscoveryServ
{
    public class IndividualOpportunityDiscoveryService : IIndividualOpportunityDiscoveryService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public IndividualOpportunityDiscoveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<IndividualOpportunityDiscovery> GetIndividualOpportunityDiscoveries()
        {
            throw new NotImplementedException();
        }

        public int Edit(IndividualOpportunityDiscovery city)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(IndividualOpportunityDiscovery banner)
        {
            throw new NotImplementedException();
        }

        public long GetAllCount()
        {
            throw new NotImplementedException();
        }

        public List<IndividualOpportunityDiscovery> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}
