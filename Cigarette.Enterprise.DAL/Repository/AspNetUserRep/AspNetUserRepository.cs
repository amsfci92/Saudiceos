using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository.AspNetUserRep
{
    public class AspNetUserRepository : Repository<AspNetUser>, IAspNetUserRepository
    {
        public AspNetUserRepository(SaudiceosEntities context)
            : base(context)
        {
        }

        public List<AspNetUser> GetAllAsNoTracking()
        {
            return _context.AspNetUsers.AsNoTracking().ToList();
        }

        public AspNetUser GetAsNoTracking(string id)
        {
            return _context.AspNetUsers.AsNoTracking().Where(m => m.Id == id).FirstOrDefault();
        }
    }
}
