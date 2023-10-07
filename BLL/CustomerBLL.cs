using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DataModel;
using DAL.Interface;

namespace BLL
{
    public class CustomerBLL : ICustomerBLL
    {
        private ICustomerRespository _res;
        public CustomerBLL(ICustomerRespository res)
        {
            _res = res;
        }
        public bool Create(CustomerModel model)
        {
            return _res.Create(model);
        }

        public void Delete(int id)
        {
            _res.Delete(id);
        }

        public CustomerModel GetDataByID(int id)
        {
            return _res.GetDataByID(id);
        }

        public bool Update(CustomerModel model)
        {
            return (_res.Update(model));
        }
    }
}
