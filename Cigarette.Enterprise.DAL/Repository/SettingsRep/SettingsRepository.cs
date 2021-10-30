using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository.SettingsRep
{
    public class SettingsRepository : Repository<Setting>, ISettingsRepository
    {
        public SettingsRepository(SaudiceosEntities context)
            : base(context)
        {
        }
         
        public SaudiceosEntities MVCAPIContext
        {
            get { return _context as SaudiceosEntities; }
        } 
    }
}
