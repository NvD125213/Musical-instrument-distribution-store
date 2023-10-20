using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DanhMucModel
    {
        [Key]
        public int DanhMucID { get; set; }
        [Required]
        public string TenDM { get; set; }
        public string SeoTitle { get; set; }
        public bool TrangThai { get; set; }
        public bool ThuTu { get; set; }
        public int ParentID { get; set; }

        public List<DanhMucModel> DMConList { get; set; }

       

    }
   
}
