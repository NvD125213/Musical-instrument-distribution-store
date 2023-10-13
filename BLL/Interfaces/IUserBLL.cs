using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBLL
    {
        UserModel GetUser(string tendn, string matkhau);
        bool CreateUser(UserModel model);
        bool UpdateUser(UserModel model);
    }
}
