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
    public class DiaChiResponsitory : IDIaChiResponsitory
    {
        private IDatabaseHelper _dbHelper;
        public DiaChiResponsitory(IDatabaseHelper dbhelper)
        {
            _dbHelper = dbhelper;
        }
        public bool Create(DiaChiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_DiaChiInsert",
                "@ThanhPho", model.ThanhPho,
                "@Huyen", model.Huyen,
                "@Xa", model.Xa,
                "@GhiChu", model.GhiChu,
                "@UserID", model.UserID);
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

        public bool Delete(DiaChiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_DiaChiDelete",
                "@DiaChiID", model.DiaChiID);
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

        public DiaChiModel DiaChiByID(int id)
        {

            string msgError = "";

            var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "DiaChiByID", "@UserID", id);
            if (!string.IsNullOrEmpty(msgError))
            {
                throw new Exception(msgError);
            }
            return dt.ConvertTo<DiaChiModel>().FirstOrDefault();
        }

        public bool Update(DiaChiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "tbl_DiaChiUpdate", "@DiaChiID", model.DiaChiID,
                "@ThanhPho", model.ThanhPho,
                "@Huyen", model.Huyen,
                "@Xa", model.Xa,
                "@GhiChu", model.GhiChu,
                "@UserID", model.UserID);
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
