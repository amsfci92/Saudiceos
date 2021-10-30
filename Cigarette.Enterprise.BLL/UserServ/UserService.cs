using AutoMapper;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.DAL.Repository;
using Cigarette.Enterprise.ViewModels.ViewModels.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.BLL.UserServ
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Edit(AspNetUser bM)
        {
            return _unitOfWork.Users.Update(bM);
        }

        public void Add(AspNetUser bM)
        {
            _unitOfWork.Users.Add(bM);
        }

        public AspNetUser Get(string User)
        {
            return _unitOfWork.Users.Get(User);
        }

        public Result<List<AspNetUser>> GetAll()
        {
            var result = new Result<List<AspNetUser>>
            {
                Data = _unitOfWork.Users.GetAllAsNoTracking(),
                Succeeded = true
            };
            return result;
        }
        public bool DeleteRange(List<string> ids)
        {
            var list = new List<AspNetUser>();
            foreach (var item in ids)
            {
                var model = _unitOfWork.Users.Get(item);
                if (model == null)
                {
                    return false;
                }
                list.Add(model);
            }
            var result = _unitOfWork.Users.RemoveRange(list);

            return result > 0;
        }

        public Result Update(AspNetUser model)
        {
            var result = new Result();
            var updated = _unitOfWork.Users.Update(model);

            if (updated == 0)
            {
                result.Succeeded = false;
                result.Errors.Add(new ResultError { Message = "No Updated" });
                return result;
            }

            result.Succeeded = true;
            return result;
        }

        public bool Exists(string id, string email)
        {
            return _unitOfWork.Users.GetAll().Any(m => m.Id != id && m.Email == email);
        }

        public AspNetUser GetAsNoTracking(string id)
        {
            return _unitOfWork.Users.GetAsNoTracking(id);
        }
    }
}