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
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class SanPhamResponsitory : ISanPhamResponsitory
    {

        private IDatabaseHelper _dbHelper;
        private IConfiguration _config;


        public SanPhamResponsitory(IDatabaseHelper dbhelper, IConfiguration config)
        {
            _dbHelper = dbhelper;
            _config = config;
        }
        public BanChayModel GetBanChay()
        {

            BanChayModel a = new BanChayModel();

            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_3_kq_sanpham");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                
                a.TopSanPham = dt.ConvertTo<ChiTietBanChayModel>().FirstOrDefault();

                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPhamModel GetSanPhambyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_get_by_id",
                     "@MaHoaDon", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPhamModel> SearchTheoDM(int pageIndex, int pageSize, out long total, string tensp, int danhmuc)
        {

            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SearchSanPham",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenSP", tensp,
                    "@DanhMuc", danhmuc
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "SearchSanPhamQuaGia",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@MaxPrice", giaMax,
                    "@MinPrice", giaMin
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
