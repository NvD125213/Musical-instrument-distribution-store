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
using System.Data;
namespace DAL
{
    public class DanhMucRespository : IDanhMucResponsitory
    {

        private IDatabaseHelper _dbHelper;
        public DanhMucRespository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DanhMucModel GetData(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DM_Get", "@DanhMucID",id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DanhMucModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
