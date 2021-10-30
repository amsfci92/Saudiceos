using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository.KnowledgeCenterRep
{
    public class KnowledgeCenterRepository : Repository<KnowledgeCenter>, IKnowledgeCenterRepository
    {
        public KnowledgeCenterRepository(SaudiceosEntities context)
            : base(context)
        {
        }
        

        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        } 
    }
}
