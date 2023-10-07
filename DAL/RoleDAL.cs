using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DAL.Interface;
using DAL.Helper;
using DAL.Helper.Interface;

namespace DAL
{
    public class RoleDAL : IRoleDAL
    {
        private IDatabaseHelper _dbHelper;

        public RoleDAL(IDatabaseHelper dbhelper)
        {
            _dbHelper = dbhelper;
        }

        public bool Create(RoleModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(RoleModel model)
        {
            throw new NotImplementedException();
        }

        public List<RoleModel> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public RoleModel GetDataByI(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(RoleModel model)
        {
            throw new NotImplementedException();
        }
    }

    
}
