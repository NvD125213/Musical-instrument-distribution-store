using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DAL.Interface
{
    public interface ISanPhamResponsitory
    {
        SanPhamModel GetSanPhambyID(int id);
      
        List<SanPhamModel> SearchTheoDM(int pageIndex, int pageSize, out long total, string tensp, int danhmuc);

        List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin);

        public BanChayModel GetBanChay();
    }
}
