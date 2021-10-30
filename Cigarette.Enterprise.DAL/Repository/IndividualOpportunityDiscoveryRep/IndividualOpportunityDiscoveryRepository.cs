using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cigarette.Enterprise.DAL.Repository.IndividualOpportunityDiscoveryRep
{
    public class IndividualOpportunityDiscoveryRepository : Repository<IndividualOpportunityDiscovery>,
        IIndividualOpportunityDiscoveryRepository
    {
        public IndividualOpportunityDiscoveryRepository(SaudiceosEntities context)
            : base(context)
        {
        }
        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        }

        
    }
}
