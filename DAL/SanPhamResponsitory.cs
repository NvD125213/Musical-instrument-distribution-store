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
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_3_kq_sanpham]");
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
        private List<ChiTietDonHangModel> ConvertDataTableToChiTietDonHangModel(DataTable dataTable)
        {
            List<ChiTietDonHangModel> chiTietDonHangList = new List<ChiTietDonHangModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                ChiTietDonHangModel chiTietDonHang = new ChiTietDonHangModel
                {
                    TenSanPham = row["TenSanPham"].ToString(),
                    SoLuong = Convert.ToInt32(row["SoLuong"])
                };
                chiTietDonHangList.Add(chiTietDonHang);
            }

            return chiTietDonHangList;
        }
        private List<SanPhamModel> ConvertDataTableToSanPhamModel(DataTable dataTable)
        {
            List<SanPhamModel> sanPhamList = new List<SanPhamModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                SanPhamModel sanPham = new SanPhamModel
                {
                    Ten = row["Ten"].ToString()
                };
                sanPhamList.Add(sanPham);
            }

            return sanPhamList;
        }

    }
}
