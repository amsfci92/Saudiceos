using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository.ReportRep
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(SaudiceosEntities context)
            : base(context)
        {
        }
         
        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        } 
    }
}
