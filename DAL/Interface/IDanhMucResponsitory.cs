using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DAL.Interface
{
    public interface IDanhMucResponsitory
    {
       DanhMucModel GetData(int id);
    }
}
