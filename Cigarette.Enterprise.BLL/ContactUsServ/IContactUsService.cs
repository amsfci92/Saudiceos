using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.ViewModels.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.ContactUsServ
{
    public interface IContactUsService
    {
        void Add(ContactU banner);
        long GetAllCount();
        List<ContactU> GetAll();
        int Edit(ContactU model);
        bool Delete(int id);
        ContactU Get(long id);
        bool DeleteRange(List<long> ids);
    }
}
