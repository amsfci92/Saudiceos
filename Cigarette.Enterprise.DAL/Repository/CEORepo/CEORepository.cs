using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Cigarette.Enterprise.DAL.CustomModels; 
using System.Linq.Expressions; 
using Cigarette.Enterprise.DAL.Pagination; 

namespace Cigarette.Enterprise.DAL.Repository.CEORep
{
    public class CEORepository : Repository<CEO>, ICEORepository
    {
        #region Fields 
        #endregion

        #region Ctor

        public CEORepository(SaudiceosEntities context) : base(context)
        { 
        } 
        #endregion


        #region Method

        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        } 
         
        #endregion
    }
}
