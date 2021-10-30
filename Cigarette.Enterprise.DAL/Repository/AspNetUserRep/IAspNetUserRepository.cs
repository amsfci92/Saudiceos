using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository.AspNetUserRep
{
    public interface IAspNetUserRepository : IRepository<AspNetUser>
    {
        List<AspNetUser> GetAllAsNoTracking();
        AspNetUser GetAsNoTracking(string id);
    }
}
