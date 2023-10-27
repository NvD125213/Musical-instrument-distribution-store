using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DAL.Interface;
using DAL.Helper.Interface;
using DAL.Helper;
using System.Data.SqlClient;

namespace DAL
{
    public class UserRespository : IUserRespository
    {
      
        private IDatabaseHelper _dbHelper;

      
        public UserRespository(IDatabaseHelper dbhelper)
        {
            _dbHelper = dbhelper;
        }

       

        public bool CreateUser(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_user",
                "@Ten", model.Ten,
                "@SDT", model.SDT,
                "@Email",model.Email,
                "@MatKhau",model.MatKhau);
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

     

        public UserModel GetUser(string tendn, string matkhau)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_user_login",
                     "@Ten", tendn,
                     "@MatKhau", matkhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public bool UpdateUser(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedure(out msgError, "sp_update_user",
                    "@UserID",model.UserID,
                    "@Ten",model.Ten,
                    "@Email",model.Email,
                    "@SDT",model.SDT);
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
    }
}
