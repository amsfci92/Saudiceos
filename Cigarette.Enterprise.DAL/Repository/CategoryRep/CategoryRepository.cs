using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Cigarette.Enterprise.DAL.Repository.CategoryRep
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(SaudiceosEntities context)
            : base(context)
        {
        } 
   
        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        }
    }
}
