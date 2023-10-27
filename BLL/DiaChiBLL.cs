using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DataModel;

namespace BLL
{
    public class DiaChiBLL : IDIaChiResponsitory
    {
        private IDIaChiResponsitory _responsitory;
        public DiaChiBLL(IDIaChiResponsitory responsitory)
        {
            _responsitory = responsitory;
        }
        public bool Create(DiaChiModel model)
        {
            return _responsitory.Create(model);
        }

        public bool Delete(DiaChiModel model)
        {
            return _responsitory.Delete(model);
        }

        public DiaChiModel DiaChiByID(int id)
        {
            return _responsitory.DiaChiByID(id);
        }

        public bool Update(DiaChiModel model)
        {
            return _responsitory.Update(model);
        }
    }
}
