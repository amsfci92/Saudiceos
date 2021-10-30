using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using Cigarette.Enterprise.ViewModels.ViewModels.ContactUs;

namespace Cigarette.Enterprise.BLL.ContactUsServ
{
    public class ContactUsService : IContactUsService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public ContactUsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ContactU model)
        {
            _unitOfWork.ContactUs.Add(model);
        } 
        public long GetAllCount()
        {
            return _unitOfWork.ContactUs.GetAll().Count();
        }

        public List<ContactU> GetAll()
        {
            return _unitOfWork.ContactUs.GetAll().ToList();
        }

        public int Edit(ContactU model)
        {
            return _unitOfWork.ContactUs.Update(model);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ContactU Get(long id)
        {
            return _unitOfWork.ContactUs.Get(id);
        }
        public bool DeleteRange(List<long> ids)
        {
            var list = new List<ContactU>();
            foreach (var item in ids)
            {
                var model = _unitOfWork.ContactUs.Get(item);
                if (model == null)
                {
                    return false;
                }
                list.Add(model);
            }
            var result = _unitOfWork.ContactUs.RemoveRange(list);

            return result > 0;
        }
    }
}
