using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Helper;
using DAL.Interface;
using DataModel;
using System.Data;

namespace DAL
{
    public class CustomerResponsitory : ICustomerRespository
    {
        private IDatabaseHelper _dbHelper;
        public CustomerResponsitory(IDatabaseHelper dbhelper)
        {
            _dbHelper = dbhelper;
        }

        public bool Create(CustomerModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetDataByID(int id)
        {
            
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_khach_by_id", "@id", id);
                if(!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }    
                return dt.ConvertTo<CustomerModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public bool Update(CustomerModel model)
        {
            throw new NotImplementedException();
        }
    }


}
