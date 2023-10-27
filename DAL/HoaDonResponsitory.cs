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
    public class HoaDonResponsitory : IHoaDonResponsitory
    {
        private IDatabaseHelper _res;
        public HoaDonResponsitory(IDatabaseHelper res)
        {
            _res = res;
        }

        public bool Create(DonHangModel model)
        {
            string msgError = "";
            try
            {
                var result = _res.ExecuteScalarSProcedureWithTransaction(out msgError, "HoaDonCreate",
                "@TenKH", model.TenKH,
                "@NgayDat", model.NgayDat,
                "@TrangThai", model.TrangThai,
                "@DiaChiID", model.DiaChiID,
                "@ThanhToanID", model.ThanhToanID,
                "@TongGia", model.TongGia,
                "@list_json_chitiethoadon", model.list_json_chitietdonhang != null ? MessageConvert.SerializeObject(model.list_json_chitietdonhang) : null);
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

        public DonHangModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _res.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadon_get_by_id",
                     "@ID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonHangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ThongKe> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            throw new NotImplementedException();
        }

        public bool Update(DonHangModel model)
        {

            string msgError = "";
            try
            {
               var a= model.list_json_chitietdonhang != null ? MessageConvert.SerializeObject(model.list_json_chitietdonhang) : null;
                var result = _res.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_Cthoa_don_update]",
                "@DonHangID", model.DonHangID,
                "@list_json_chitiethoadon", model.list_json_chitietdonhang != null ? MessageConvert.SerializeObject(model.list_json_chitietdonhang) : null);
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
