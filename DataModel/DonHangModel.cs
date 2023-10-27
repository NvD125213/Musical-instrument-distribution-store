using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DonHangModel
    {
        [Key]
        public int DonHangID { get; set; }
        [Required]
        public DateTime NgayDat { get; set; }
        public string TenKH { get; set; }
        public bool TrangThai { get; set; }
        public int TinhTrang { get; set; }
     
        public decimal TongGia { get; set; }
        public List<ChiTietDonHangModel> list_json_chitietdonhang { get; set;  }
      
        [ForeignKey("ThanhToan")]
        public int ThanhToanID { get; set; }
        [ForeignKey("DiaChiID")]
        public int DiaChiID { get; set; }


    }
    public class ChiTietDonHangModel
    {
        [ForeignKey("tbl_DonHang")]
        public int DonHangID { get; set; }
        [ForeignKey("tbl_SanPham")]
        public int SanPhamID { get; set; }
       
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        
        

    }
}
