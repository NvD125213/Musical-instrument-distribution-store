using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DAL.Interface
{
    public interface IUserRespository
    {

        bool CreateUser(UserModel model);
        UserModel GetUser(string tendn, string matkhau);

        bool UpdateUser(UserModel model);




    }
}
