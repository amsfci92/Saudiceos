using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository.ServiceRep
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(SaudiceosEntities context)
            : base(context)
        {
        }
         
        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        } 
    }
}
