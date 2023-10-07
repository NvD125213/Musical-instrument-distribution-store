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
using DAL.Helper.Interface;

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
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_update",
                "@Id", model.Id,
                "@Name", model.Name,
                "@Phone", model.Phone,
                "@Andress", model.Andress);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from Customer where Id=" + id + "";
            int rowDeleted = sqlCmd.ExecuteNonQuery();

        }

        public CustomerModel GetDataByID(int id)
        {

            string msgError = "";

            var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_khach_by_id", "@id", id);
            if (!string.IsNullOrEmpty(msgError))
            {
                throw new Exception(msgError);
            }
            return dt.ConvertTo<CustomerModel>().FirstOrDefault();

        }

        public bool Update(CustomerModel model)
        {
            throw new NotImplementedException();
        }
    }


}
