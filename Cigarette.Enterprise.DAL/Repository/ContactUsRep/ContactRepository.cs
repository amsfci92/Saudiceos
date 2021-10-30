using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository.ContactUsRep
{
    public class ContactRepository : Repository<ContactU>, IContactRepository
    {
        public ContactRepository(SaudiceosEntities context)
            : base(context)
        {
        }
    }
}
