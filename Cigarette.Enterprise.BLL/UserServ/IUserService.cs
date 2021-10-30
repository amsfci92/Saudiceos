using Cigarette.Enterprise.DAL;
using System.Collections.Generic;

namespace Cigarette.Enterprise.BLL.UserServ
{
    public interface IUserService
    {
        int Edit(AspNetUser bM);
        void Add(AspNetUser bM);
        AspNetUser Get(string User);
        bool Exists(string id, string email1);
        Result<List<AspNetUser>> GetAll(); 
        bool DeleteRange(List<string> ids);
        Result Update(AspNetUser model);
        AspNetUser GetAsNoTracking(string id);
    }
}
