using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BLL.Interfaces
{
    public interface ICustomerBLL
    {
        CustomerModel GetDataByID(int id);
        bool Create(CustomerModel model);
        bool Update(CustomerModel model);
        void Delete(int id);
        

    }
}
