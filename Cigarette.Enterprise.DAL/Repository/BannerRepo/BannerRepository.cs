using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository.BannerRepo
{
    public class BannerRepository : Repository<Banner>, IBannerRepository
    {
        public BannerRepository(SaudiceosEntities context)
               : base(context)
        {
        }

        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        }
    }
}
