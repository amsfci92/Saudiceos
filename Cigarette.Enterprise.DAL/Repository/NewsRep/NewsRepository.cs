using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Cigarette.Enterprise.DAL.Repository.NewsRep
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(SaudiceosEntities context)
            : base(context)
        {
        } 
   
        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        }
    }
}
