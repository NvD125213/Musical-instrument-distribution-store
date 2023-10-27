using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DAL.Interface
{
    public interface IHoaDonResponsitory 
    {
        DonHangModel GetDatabyID(int id);
        bool Create(DonHangModel model);
        bool Update(DonHangModel model);
        public List<ThongKe> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao);

    }
}
