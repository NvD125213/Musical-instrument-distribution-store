using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DAL.Interface
{
    public partial interface ICustomerRespository
    {
        CustomerModel GetDataByID(int id);
        bool Create(CustomerModel model);
        bool Update(CustomerModel model);
        bool Delete(int id);

    }
}
