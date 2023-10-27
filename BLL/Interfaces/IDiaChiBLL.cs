using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BLL.Interfaces
{
    public interface IDiaChiBLL
    {
        bool Create(DiaChiModel model);
        bool Update(DiaChiModel model);
        bool Delete(DiaChiModel model);
        DiaChiModel DiaChiByID(int id);
    }
}
