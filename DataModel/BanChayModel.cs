using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BanChayModel
    {
        public ChiTietBanChayModel TopSanPham { get; set; }

    }
    public class ChiTietBanChayModel
    {
        public List<ChiTietDonHangModel> list_json_sanphambanchay { get; set; }
        public List<SanPhamModel> list_json_sanphammoive { get; set; }
        public List<SanPhamModel> list_json_sanphamhot { get; set; }
    }
}
