using Cigarette.Enterprise.DAL; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.IndividualOpportunityDiscoveryServ
{
    public interface IIndividualOpportunityDiscoveryService
    { 

        void Add(IndividualOpportunityDiscovery banner);
        long GetAllCount();
        List<IndividualOpportunityDiscovery> GetAll();
        int Edit(IndividualOpportunityDiscovery model);
        bool Delete(int id);
    }
}
