using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Cigarette.Enterprise.DAL.CustomModels; 
using System.Linq.Expressions;
using Cigarette.Enterprise.DAL.Pagination; 

namespace Cigarette.Enterprise.DAL.Repository.CEOAddEditRequestRep
{
    public class CEOAddEditRequestRepository : Repository<CEOAddEditRequest>, ICEOAddEditRequestRepository
    {
        #region Fields 
        #endregion

        #region Ctor

        public CEOAddEditRequestRepository(SaudiceosEntities context) : base(context)
        { 
        }
         
        #endregion

  public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        }
         
    }
}
