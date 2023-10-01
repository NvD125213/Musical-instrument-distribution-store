using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DAL.Interface
{
    public partial interface IRoleDAL
    {
        RoleModel GetDataByI(int id);
        bool Create(RoleModel model);
        bool Update(RoleModel model);
        bool Delete(RoleModel model);

        public List<RoleModel> GetAll(int id);

    }
}
